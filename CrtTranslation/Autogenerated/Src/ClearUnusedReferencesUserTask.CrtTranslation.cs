namespace Terrasoft.Core.Process.Configuration
{

	using Terrasoft.Configuration.Translation;
	using Terrasoft.Core.Process;

	#region Class: ClearUnusedReferencesUserTask

	/// <exclude/>
	public partial class ClearUnusedReferencesUserTask
	{
		#region Methods: Private

		private void ClearUnusedReferences() {
			var translationService = new TranslationService(UserConnection);
			translationService.ClearUnusedReference();
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ApplyTranslationProcessExtension.UpdateApplyProcessStage(context, ApplySessionId,
				ApplyTranslationsStagesEnum.CleanUnusedReferences);
			ClearUnusedReferences();
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
