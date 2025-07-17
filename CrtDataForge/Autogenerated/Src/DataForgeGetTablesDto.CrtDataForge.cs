namespace Terrasoft.Configuration.DataForge
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Core.ServiceModelContract;

	/// <summary>
	/// Represents the response model for retrieving table names in the Data Forge service.
	/// </summary>
	[DataContract]
	public class DataForgeGetTablesResponse : BaseResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of table names retrieved from the Data Forge service.
		/// </summary>
		[DataMember(Name = "data")]
		public List<string> Data { get; set; }

		#endregion

	}

}

