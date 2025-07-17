namespace Terrasoft.Configuration.Translation
{
	using System;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;

	#region Class: ApplyTranslationProcessExtension

	public static class ApplyTranslationProcessExtension
	{

		#region Methods: Private

		private static IApplyTranslationsParametersRepository GetApplyParametersRepository(UserConnection userConnection) {
			return ClassFactory.Get<IApplyTranslationsParametersRepository>(
				new ConstructorArgument("userConnection", userConnection));
		}

		#endregion

		#region Methods: Public

		public static void InitializeApplyParametersRepository(ProcessExecutingContext context, Guid applySessionId,
				Guid applyProcessId) {
			if (applySessionId == Guid.Empty) {
				return;
			}
			var repository = GetApplyParametersRepository(context.UserConnection);
			var parameters = new ApplyTranslationParameters(applySessionId) {
				ApplyStage = ApplyTranslationsStagesEnum.Initializing,
				ApplyCancellationToken = context.CancellationToken
			};
			repository.Add(parameters);
			repository.UpdateApplyProcessId(applySessionId, applyProcessId);
		}

		public static void UpdateApplyProcessStage(ProcessExecutingContext context, Guid applySessionId,
				ApplyTranslationsStagesEnum applyStage) {
			if (applySessionId == Guid.Empty) {
				return;
			}
			var repository = GetApplyParametersRepository(context.UserConnection);
			repository.UpdateApplyStage(applySessionId, applyStage);
		}

		public static void CancelApplySession(UserConnection userConnection, Guid applySessionId) {
			if (applySessionId == Guid.Empty) {
				return;
			}
			var repository = GetApplyParametersRepository(userConnection);
			repository.CancelApplySession(applySessionId);
			repository.Delete(applySessionId);
		}

		public static ISysCultureInfo GetCultureInfo(UserConnection userConnection, Guid languageId) {
			var provider = new SysCultureInfoProvider(userConnection);
			return provider.GetByLanguageId(languageId);
		}

		public static void Delete(UserConnection userConnection, Guid applySessionId) {
			if (applySessionId == Guid.Empty) {
				return;
			}
			var repository = GetApplyParametersRepository(userConnection);
			repository.Delete(applySessionId);
		}

		#endregion

	}

	#endregion

}

