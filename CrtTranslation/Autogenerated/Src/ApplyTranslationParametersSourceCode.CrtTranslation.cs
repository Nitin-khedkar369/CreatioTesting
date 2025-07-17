 namespace Terrasoft.Configuration.Translation 
{
	using System;
	using System.Runtime.Serialization;
	using System.Threading;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;

	#region Class: ApplyTranslationParameters

	/// <inheritdoc />
	/// <summary>
	/// An instance of this class represents file import parameters.
	/// </summary>
	[DataContract]
	[Serializable]
	public class ApplyTranslationParameters : EntityData {

		#region Constructors: Public

		/// <summary>
		/// Creates instance of type <see cref="ApplyTranslationParameters"/>.
		/// </summary>
		public ApplyTranslationParameters() { }

		/// <summary>
		/// Creates instance of type <see cref="ApplyTranslationParameters"/>.
		/// </summary>
		/// <param name="applySessionId">Apply session identifier.</param>
		public ApplyTranslationParameters(Guid applySessionId) => ApplySessionId = applySessionId;

		public ApplyTranslationParameters(ApplyTranslationParameters source) {
			ApplySessionId = source.ApplySessionId;
			ApplyStage = source.ApplyStage;
			ApplyCancellationToken = source.ApplyCancellationToken;
		}

		#endregion

		#region Fields: Public

		/// <summary>
		/// Apply session identifier.
		/// </summary>
		public Guid ApplySessionId {
			get => Id;
			set => Id = value;
		}

		#endregion

		#region Field: Private

		[NonSerialized]
		private IApplyTranslationsParametersRepository _repository;

		#endregion

		#region Properties: Public

		public ApplyTranslationsStagesEnum ApplyStage { get; set; }

		public Guid ApplyTranslationProcessId { get; private set; }

		[NonSerialized]
		private CancellationToken _applyCancellationToken;

		/// <summary>
		/// Cancel import process
		/// </summary>
		public CancellationToken ApplyCancellationToken {
			get => _applyCancellationToken;
			set => _applyCancellationToken = value;
		}

		#endregion

		#region Methods: Private

		private IApplyTranslationsParametersRepository GetRepository(UserConnection userConnection) {
			return _repository ??
				(_repository = ClassFactory.Get<IApplyTranslationsParametersRepository>(new ConstructorArgument("userConnection", userConnection)));
		}

		#endregion

		#region Methods: Public

		public bool GetIsApplyTranslationCancelled(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			return ApplyCancellationToken.IsCancellationRequested ||
			 	GetRepository(userConnection).GetIsApplySessionCanceled(ApplySessionId);
		}

		/// <summary>
		/// Create copy of instance
		/// </summary>
		/// <returns></returns>
		public ApplyTranslationParameters Clone() => new ApplyTranslationParameters(this);

		public void SetProcessId(Guid applyTranslationProcessId) => ApplyTranslationProcessId = applyTranslationProcessId;

		#endregion

	}

	#endregion

}



