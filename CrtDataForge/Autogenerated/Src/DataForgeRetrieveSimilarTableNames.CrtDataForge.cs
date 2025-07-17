namespace Terrasoft.Core.Process.Configuration
{
	using Terrasoft.Common;
	using Terrasoft.Configuration.DataForge;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;


	#region Class: DataForgeRetrieveSimilarTableNames
	/// <exclude/>
	public partial class DataForgeRetrieveSimilarTableNames
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			Input.CheckArgumentNullOrWhiteSpace(nameof(Input));
			IDataForgeService dataForgeService = ClassFactory.Get<IDataForgeServiceFactory>().Create();
			DataForgeGetTablesResponse response = dataForgeService.GetSimilarTableNames(
				Input,
				context.CancellationToken);
			Output = response.Success
				? string.Join(",", response.Data)
				: "No result.";
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

