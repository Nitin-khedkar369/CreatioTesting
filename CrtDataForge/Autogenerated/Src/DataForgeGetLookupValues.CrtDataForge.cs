namespace Terrasoft.Core.Process.Configuration
{
	using Common;
	using Newtonsoft.Json;
	using Terrasoft.Configuration.DataForge;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;

	#region Class: DataForgeGetLookupValues

	/// <exclude/>
	public partial class DataForgeGetLookupValues
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			Input.CheckArgumentNullOrWhiteSpace(nameof(Input));
			IDataForgeService dataForgeService = ClassFactory.Get<IDataForgeServiceFactory>().Create();
			DataForgeGetLookupsResponse response = dataForgeService.GetSimilarLookups(
				Input,
				context.CancellationToken);
			Output = response.Success ? JsonConvert.SerializeObject(response.Data) : "No result.";
			return true;
		}

		#endregion

	}

	#endregion

}

