namespace Terrasoft.Core.Process.Configuration
{

	using Newtonsoft.Json;
	using Terrasoft.Configuration.DataForge;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;

	#region Class: DataForgeGetTableRelationships

	/// <exclude/>
	public partial class DataForgeGetTableRelationships
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			IDataForgeService dataForgeService = ClassFactory.Get<IDataForgeServiceFactory>().Create();
			GetTableRelationshipsResponse response = dataForgeService.GetTableRelationships(
				SourceTable,
				TargetTable,
				context.CancellationToken);
			Output = response.Success ? JsonConvert.SerializeObject(response.Paths) : "No result.";
			return true;
		}

		#endregion

	}

	#endregion

}
