namespace Terrasoft.Core.Process.Configuration
{

	using System;
	using Terrasoft.Configuration.Translation;
	using Terrasoft.Core.Process;

	#region Class: SetForceUpdateUserTask

	/// <exclude/>
	public partial class SetForceUpdateUserTask
	{

		#region Methods: Private

		private void SetForceUpdate() {
			if (!IsForceUpdate || !UseSpecifiedLanguageOnly || LanguageId.Equals(Guid.Empty)) {
				return;
			}
			var cultureInfo = ApplyTranslationProcessExtension.GetCultureInfo(UserConnection, LanguageId); 
			var translationProvider = new TranslationProvider(UserConnection, new TranslationLogger(UserConnection));
			translationProvider.SetForceUpdate(cultureInfo);
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ApplyTranslationProcessExtension.UpdateApplyProcessStage(context, ApplySessionId,
				ApplyTranslationsStagesEnum.ProcessForceApply);
			SetForceUpdate();
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
