namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using Terrasoft.Configuration.Translation;
	using Terrasoft.Core.Process;

	#region Class: InitializePersistentApplyTranslation

	/// <exclude/>
	public partial class InitializePersistentApplyTranslation
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ApplyTranslationProcessExtension.InitializeApplyParametersRepository(context, ApplySessionId,
				Guid.Parse(OwnerUId));
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
