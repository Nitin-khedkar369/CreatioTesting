 namespace Terrasoft.Configuration.Translation
{
	using Common;
	using Core;
	using Core.DB;
	using Core.Factories;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Text;
	using Newtonsoft.Json;
	using global::Common.Logging;

	#region  Class: ApplyTranslationsParametersRepository

	/// <inheritdoc />
	[DefaultBinding(typeof(IApplyTranslationsParametersRepository))]
	public class ApplyTranslationsParametersRepository : IApplyTranslationsParametersRepository 
	{

		#region Constants: Private

		private readonly UserConnection _userConnection;
		private readonly string _applyParametersSchemaName = "ApplyTranslationParameters";
		private readonly string _parametersColumnName = "ApplyParameters";
		private readonly string _sessionSchemaName = "ApplySession";
		private readonly string _sessionColumnName = "ApplySessionId";

		#endregion

		#region Constructors: Public

		public ApplyTranslationsParametersRepository(UserConnection userConnection) => _userConnection = userConnection;

		#endregion

		#region Methods: Private

		private static T ConvertToObject<T>(byte[] value) where T : class {
			return value == null
				? null
				: JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value));
		}

		private static QueryColumnExpression SerializeAndConvertToQueryColumnExpression<T>(T value) where T : class =>
			Column.Parameter(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));

		private ApplyTranslationParameters GetApplyParameters(IDataReader record) {
			var parameters = ConvertToObject<ApplyTranslationParameters>(
				record.GetColumnValue<byte[]>(_parametersColumnName)) ?? new ApplyTranslationParameters();
			parameters.ApplySessionId = record.GetColumnValue<Guid>("Id");
			parameters.ApplyStage = record.GetColumnValue<ApplyTranslationsStagesEnum>("Stage");
			return parameters;
		}

		private (Guid processId, ApplyTranslationParameters parameters) GetApplyParametersWithProcessId(
				IDataReader record) {
			var parameters = ConvertToObject<ApplyTranslationParameters>(
				record.GetColumnValue<byte[]>(_parametersColumnName));
			parameters.ApplySessionId = record.GetColumnValue<Guid>("Id");
			parameters.ApplyStage = record.GetColumnValue<ApplyTranslationsStagesEnum>("Stage");
			var processId = record.GetColumnValue<Guid>("ProcessId");
			parameters.SetProcessId(processId);
			return (processId, parameters);
		}

		private Update CreateUpdateApplyParametersQuery(Guid applySessionId) {
			var currentContactId = _userConnection.CurrentUser.ContactId;
			var currentDateTime = _userConnection.CurrentUser.GetCurrentDateTime();
			return new Update(_userConnection, _applyParametersSchemaName)
				.Set("ModifiedOn", Column.Parameter(currentDateTime))
				.Set("ModifiedById", Column.Parameter(currentContactId))
				.Where("Id").IsEqual(Column.Parameter(applySessionId)) as Update;
		}

		private Select GetSelectQuery() => new Select(_userConnection)
			.Column("Id")
			.Column(_parametersColumnName)
			.Column("Stage")
			.From(_applyParametersSchemaName);

		private void DeleteCanceledSessionId(Guid applySessionId) {
			var delete = new Delete(_userConnection)
				.From(_sessionSchemaName)
				.Where("Id").IsEqual(Column.Parameter(applySessionId));
			delete.Execute();
		}

		private Insert GetInsertApplySession(Guid applySessionId) => new Insert(_userConnection)
			.Into(_sessionSchemaName).Values().Set("Id", Column.Parameter(applySessionId));

		private Update GetUpdateApplySession(Guid applySessionId) => new Update(_userConnection, _sessionSchemaName)
			.Where("Id").IsEqual(Column.Parameter(applySessionId)) as Update;
		
		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public void Add(ApplyTranslationParameters applyTranslationParameters) {
			var currentContactId = _userConnection.CurrentUser.ContactId;
			var currentDateTime = _userConnection.CurrentUser.GetCurrentDateTime();
			var insert = new Insert(_userConnection)
				.Into(_applyParametersSchemaName)
				.Set("Id", Column.Parameter(applyTranslationParameters.ApplySessionId))
				.Set("CreatedOn", Column.Parameter(currentDateTime))
				.Set("ModifiedOn", Column.Parameter(currentDateTime))
				.Set("CreatedById", Column.Parameter(currentContactId))
				.Set("ModifiedById", Column.Parameter(currentContactId))
				.Set("Stage", Column.Parameter(applyTranslationParameters.ApplyStage))
				.Set(_parametersColumnName, SerializeAndConvertToQueryColumnExpression(applyTranslationParameters));
			try {
				insert.Execute();
			} catch (SqlException sqlException) {
				var logger = LogManager.GetLogger("Translation");
				logger.Error(sqlException.Errors, sqlException);
				throw;
			}
		}

		/// <inheritdoc />
		public void Delete(Guid applySessionId) {
			var delete = new Delete(_userConnection)
				.From(_applyParametersSchemaName)
				.Where("Id").IsEqual(Column.Parameter(applySessionId));
			delete.Execute();
			DeleteCanceledSessionId(applySessionId);
		}

		/// <inheritdoc />
		public ApplyTranslationParameters Get(Guid applySessionId) {
			var selectQuery = GetSelectQuery();
			selectQuery.Where("Id")
				.IsEqual(new QueryParameter(_sessionColumnName, applySessionId));
			var parametersExists = selectQuery.ExecuteSingleRecord(GetApplyParameters, out var applyParameters);
			if (parametersExists) {
				return applyParameters;
			}
			throw new ItemNotFoundException($"{_applyParametersSchemaName} with ApplySessionId {applySessionId}");
		}

		/// <inheritdoc />
		public void Update(ApplyTranslationParameters parameters) {
			var update = CreateUpdateApplyParametersQuery(parameters.ApplySessionId)
				.Set("Stage", Column.Parameter(parameters.ApplyStage))
				.Set(_parametersColumnName, SerializeAndConvertToQueryColumnExpression(parameters));
			update.Execute();
		}

		/// <inheritdoc />
		public void UpdateApplyStage(Guid applySessionId, ApplyTranslationsStagesEnum newApplyTranslationsStage) {
			var update = CreateUpdateApplyParametersQuery(applySessionId);
			update = update.Set("Stage", Column.Parameter(newApplyTranslationsStage)) as Update;
			update.Execute();
		}

		/// <inheritdoc />
		public void Update(Guid id, IDictionary<string, object> changedValues) {
			throw new NotImplementedException();
		}

		public void BulkUpdate(IEnumerable<Guid> keyCollection, IDictionary<string, object> changedValues) {
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public IEnumerable<ApplyTranslationParameters> GetAll() {
			var select = GetSelectQuery();
			return select.ExecuteEnumerable(GetApplyParameters).ToList();
		}
		
		/// <inheritdoc />
		public Dictionary<Guid, ApplyTranslationParameters> GetWithProcessIncomplete() {
			var select = new Select(_userConnection)
					.Column(_applyParametersSchemaName, "Id")
					.Column(_applyParametersSchemaName, _parametersColumnName)
					.Column(_applyParametersSchemaName, "Stage")
					.Column(_sessionSchemaName, "ProcessId")
				.From(_applyParametersSchemaName).As(_applyParametersSchemaName)
				.InnerJoin(_sessionSchemaName).As(_sessionSchemaName)
					.On(_sessionSchemaName, "Id").IsEqual(_applyParametersSchemaName, "Id")
				.Where(_sessionSchemaName, "ProcessId").Not().IsNull()
				.And(_applyParametersSchemaName, "Stage")
					.IsNotEqual(new QueryParameter("completeStageId", ApplyTranslationsStagesEnum.Completed)) as Select;
			return select.ExecuteEnumerable(GetApplyParametersWithProcessId).
				ToDictionary(t => t.processId, t => t.parameters);
		}

		/// <inheritdoc />
		public bool GetIsApplySessionCanceled(Guid applySessionId) {
			var select = new Select(_userConnection)
				.Top(1).
					Column("session", "IsCanceled").
				From(_sessionSchemaName).As("session").
				InnerJoin(_applyParametersSchemaName).As("param").
					On("param", "Id").
				IsEqual("session", "Id").
				Where("session", "Id").
					IsEqual(Column.Parameter(applySessionId)) as Select;
			return select.ExecuteScalar<bool>();
		}

		/// <inheritdoc />
		public void CancelApplySession(Guid applySessionId) {
			var update = GetUpdateApplySession(applySessionId);
			update.Set("IsCanceled", Column.Parameter(true));
			if (update.Execute() == 0) {
				var insert = GetInsertApplySession(applySessionId);
				insert.Set("IsCanceled", Column.Parameter(true));
				insert.Execute();
			}
		}

		/// <inheritdoc />
		public void UpdateApplyProcessId(Guid applySessionId, Guid processId) {
			var update = GetUpdateApplySession(applySessionId);
			update.Set("ProcessId", Column.Parameter(processId));
			if (update.Execute() == 0) {
				var insert = GetInsertApplySession(applySessionId);
				insert.Set("ProcessId", Column.Parameter(processId));
				insert.Execute();
			}
		}

		#endregion

	}

	#endregion

}

