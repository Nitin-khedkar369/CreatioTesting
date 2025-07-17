namespace Terrasoft.Core.Process.Configuration
{

	using Terrasoft.Configuration.Translation;
	using Terrasoft.Core.Process;

	#region Class: CleanApplyTranslationsProcessData

	/// <exclude/>
	public partial class CleanApplyTranslationsProcessData
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ApplyTranslationProcessExtension.Delete(UserConnection, ApplySessionId);
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
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

