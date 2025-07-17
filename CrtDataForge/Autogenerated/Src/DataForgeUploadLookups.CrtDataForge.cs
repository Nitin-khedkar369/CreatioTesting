namespace Terrasoft.Core.Process.Configuration
{
	using Terrasoft.Configuration.DataForge;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;

	#region Class: DataForgeUploadLookups

	/// <exclude/>
	public partial class DataForgeUploadLookups
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			IDataForgeService dataForgeService = ClassFactory.Get<IDataForgeServiceFactory>().Create();
			dataForgeService.InitializeLookups(context.CancellationToken);
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

