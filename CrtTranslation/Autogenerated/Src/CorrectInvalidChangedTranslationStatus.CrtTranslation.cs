namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using CoreSysSettings = Terrasoft.Core.Configuration.SysSettings;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.Translation;
	using global::Common.Logging;

	#region Class: CorrectInvalidChangedTranslationStatus

	/// <exclude/>
	public partial class CorrectInvalidChangedTranslationStatus
	{

		#region Fields: Private

		private ISysCultureInfoProvider _sysCultureInfoProvider;
		private ISysCultureInfoProvider SysCultureInfoProvider {
			get
			{
				_sysCultureInfoProvider = _sysCultureInfoProvider ?? ClassFactory.Get<SysCultureInfoProvider>(
					new ConstructorArgument("userConnection", UserConnection));
				return _sysCultureInfoProvider;
			}
		}

		private EntitySchema _sysTranslationSchema;
		private EntitySchema SysTranslationSchema {
			get
			{
				_sysTranslationSchema = _sysTranslationSchema ?? UserConnection.EntitySchemaManager
					.GetInstanceByName("SysTranslation");
				return _sysTranslationSchema;
			}
		}

		private readonly ILog _log = LogManager.GetLogger("Translation");

		#endregion

		#region Methods: Private

		private List<ISysCultureInfo> GetCultureInfoList() {
			if (!UseSpecifiedLanguageOnly || LanguageId.Equals(Guid.Empty)){
				return SysCultureInfoProvider.Read();
			}
			ISysCultureInfo cultureInfo = SysCultureInfoProvider.GetByLanguageId(LanguageId);
			return new List<ISysCultureInfo>{ cultureInfo };
		}

		private void SetCorrectIsChangedStatus(string key, string isChangedColumnName, bool isChanged) {
			Entity sysTranslationEntity = SysTranslationSchema.CreateEntity(UserConnection);
			Dictionary<string, object> conditions = new Dictionary<string, object> {
				{ "Key", key },
				{ isChangedColumnName, !isChanged }
			};
			if (!sysTranslationEntity.FetchFromDB(conditions)) {
				_log.DebugFormat("Key {0} not found in SysTranslation", key);
				return;
			}
			sysTranslationEntity.SetColumnValue(isChangedColumnName, isChanged);
			sysTranslationEntity.Save(false, false, false);
			_log.DebugFormat("For Key {0} {1} has been set to {2}", key, isChangedColumnName, isChanged);
		}

		private EntitySchemaQueryOptions GetPageableOptions() {
			return new EntitySchemaQueryOptions {
				PageableDirection = Core.DB.PageableSelectDirection.First,
				RowsOffset = 0,
				PageableRowCount = UserConnection.AppConnection.MaxEntityRowCount,
				PageableConditionValues = new Dictionary<string, object>()
			};
		}

		private HashSet<string> GetInvalidTranslations(Guid systemCultureInfoId) {
			HashSet<string> result = new HashSet<string>();
			EntitySchemaQuery esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "TranslationStatus");
			esq.AddColumn("TranslationKey");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"SysCulture", systemCultureInfoId));
			var options = GetPageableOptions();
			EntityCollection invalidSysTranslations;
			do {
				invalidSysTranslations = esq.GetEntityCollection(UserConnection, options);
				foreach (var entity in invalidSysTranslations) {
					if (entity is TranslationStatus translationStatus) {
						result.Add(translationStatus.TranslationKey);
					}
				}
				options.RowsOffset += invalidSysTranslations.Count;
				options.PageableDirection = Core.DB.PageableSelectDirection.Next;
				esq.ResetSelectQuery();
			} while (invalidSysTranslations.Count > 0);
			return result;
		}

		private HashSet<string> GetChangedTranslations(string isChangedColumnName) {
			HashSet<string> result = new HashSet<string>();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysTranslation") {
					PrimaryQueryColumn = {
						IsAlwaysSelect = true
					}
				};
			esq.AddColumn("Key");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				isChangedColumnName, true));
			var options = GetPageableOptions();
			EntityCollection changedTranslations;
			do {
				changedTranslations = esq.GetEntityCollection(UserConnection, options);
				foreach (var entity in changedTranslations) {
					if (entity is SysTranslation translation) {
						result.Add(translation.Key);
					}
				}
				options.RowsOffset += changedTranslations.Count;
				options.PageableDirection = Core.DB.PageableSelectDirection.Next;
				esq.ResetSelectQuery();
			} while (changedTranslations.Count > 0);
			return result;
		}

		private int GetConcurrencyLimit() {
			const double degreeMultiplier = 0.6;
			var maxDegreeOfParallelism = (int)Math.Ceiling(Environment.ProcessorCount * degreeMultiplier);
			if (!CoreSysSettings.TryGetValue(UserConnection, "TranslationUpdateTaskConcurrencyLimit",
					out object result)) {
				return maxDegreeOfParallelism;
			}
			if ((int)result != 0) {
				maxDegreeOfParallelism = (int)result;
			}
			return maxDegreeOfParallelism;
		}

		private ParallelOptions GetParallelOptions(CancellationToken cancellationToken) {
			return new ParallelOptions {
				MaxDegreeOfParallelism = GetConcurrencyLimit(),
				CancellationToken = cancellationToken
			};
		}

		private void SetIsChangedForInvalidTranslations(HashSet<string> invalidTranslations,
				ISysCultureInfo sysCultureInfo, CancellationToken ct) {
			var options = GetParallelOptions(ct);
			Parallel.ForEach(invalidTranslations, options, invalidTranslation => {
				SetCorrectIsChangedStatus(invalidTranslation, sysCultureInfo.IsChangedColumnName, true);
			});
		}

		private void RemoveIsChangedForInvalidTranslations(HashSet<string> invalidTranslations,
				ISysCultureInfo sysCultureInfo, CancellationToken ct) {
			var changedTranslations = GetChangedTranslations(sysCultureInfo.IsChangedColumnName);
			var options = GetParallelOptions(ct);
			Parallel.ForEach(changedTranslations, options, changedTranslation => {
				if (!invalidTranslations.Contains(changedTranslation)) {
					SetCorrectIsChangedStatus(changedTranslation, sysCultureInfo.IsChangedColumnName, false);
				}
			});
			GC.Collect(2, GCCollectionMode.Forced);
		}

		private void CorrectIsChangedTranslationStatusForCulture(ISysCultureInfo sysCultureInfo,
				CancellationToken ct) {
			try {
				var invalidTranslations = GetInvalidTranslations(sysCultureInfo.Id);
				RemoveIsChangedForInvalidTranslations(invalidTranslations, sysCultureInfo, ct);
				SetIsChangedForInvalidTranslations(invalidTranslations, sysCultureInfo, ct);
			} catch (OperationCanceledException) {
				_log.Info("Operation was canceled by user");
			} catch (Exception e) {
				const string errorMessage = "Error while correcting IsChanged status for culture {0}: {1}";
				_log.ErrorFormat(errorMessage, sysCultureInfo.Name, e);
				throw;
			} finally {
				GC.Collect(2, GCCollectionMode.Forced);
			}
		}

		private void CorrectIsChangedTranslationStatus(CancellationToken ct) {
			List<ISysCultureInfo> cultureInfoList = GetCultureInfoList();
			foreach (var sysCultureInfo in cultureInfoList) {
				if (ct.IsCancellationRequested) {
					return;
				}
				CorrectIsChangedTranslationStatusForCulture(sysCultureInfo, ct);
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ApplyTranslationProcessExtension.UpdateApplyProcessStage(context, ApplySessionId,
				ApplyTranslationsStagesEnum.CorrectInvalidTranslations);
			CorrectIsChangedTranslationStatus(context.CancellationToken);
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			ApplyTranslationProcessExtension.CancelApplySession(UserConnection, ApplySessionId);
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}