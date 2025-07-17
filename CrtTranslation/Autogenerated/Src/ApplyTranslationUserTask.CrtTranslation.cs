namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using Terrasoft.Configuration.Translation;
	using Terrasoft.Core.Process;

	#region Class: ApplyTranslationUserTask

	/// <exclude/>
	public partial class ApplyTranslationUserTask
	{

		#region Methods: Private

		private void ApplyTranslations() {
			var service = new TranslationService(UserConnection);
			service.InitializeFaultToleranceBehavior();
			if (!UseSpecifiedLanguageOnly || LanguageId.Equals(Guid.Empty)){
				service.ApplyTranslation();	
				return;
			}
			ISysCultureInfo cultureInfo = ApplyTranslationProcessExtension.GetCultureInfo(UserConnection, LanguageId) ;
			service.ApplyTranslationForCulture(cultureInfo, IsForceUpdate);
			service.ResetFaultToleranceBehavior();
		}
		
		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ApplyTranslationProcessExtension.UpdateApplyProcessStage(context, ApplySessionId,
				ApplyTranslationsStagesEnum.ApplyTranslations);
			ApplyTranslations();
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