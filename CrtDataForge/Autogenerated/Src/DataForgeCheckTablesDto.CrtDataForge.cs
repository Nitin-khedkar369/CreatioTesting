namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Core.ServiceModelContract;

	#region Class: DataForgeCheckTablesRequestBody

	/// <summary>
	/// Represents the request body for checking data structures from the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class DataForgeCheckTablesRequestBody
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of table data structures to be checked.
		/// </summary>
		[DataMember(Name = "tableStates")]
		public List<TableSummary> TableStates { get; set; }

		#endregion
	}

	#endregion

	#region Class: TableSummary

	/// <summary>
	/// Represents the structure and metadata of a database table.
	/// </summary>
	[DataContract]
	[Serializable]
	public class TableSummary
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the name of the table.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the checksum of the table schema.
		/// </summary>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		/// <summary>
		/// Gets or sets the last modified date of the table schema.
		/// </summary>
		[DataMember(Name = "modifiedOn")]
		public string ModifiedOn { get; set; }

		#endregion

	}

	#endregion

	#region Class: DataForgeCheckTablesResponse

	/// <summary>
	/// Represents the response body containing the list of table names from the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class DataForgeCheckTablesResponse : BaseResponse
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of table names.
		/// </summary>
		[DataMember(Name = "tableNames")]
		public List<string> TableNames { get; set; }

		#endregion

	}

	#endregion

}
