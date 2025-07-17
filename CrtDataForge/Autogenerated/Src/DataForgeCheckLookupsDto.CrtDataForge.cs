namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Core.ServiceModelContract;

	#region Class: DataForgeCheckLookupsRequestBody

	/// <summary>
	/// Represents the request body for checking lookup data via the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class DataForgeCheckLookupsRequestBody
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the collection of lookup summaries to be checked.
		/// </summary>
		[DataMember(Name = "lookups")]
		public List<LookupSummary> Lookups { get; set; }

		/// <summary>
		/// Gets or sets the collection of lookup values summaries to be checked.
		/// </summary>
		[DataMember(Name = "lookupValues")]
		public List<LookupValueSummary> LookupValues { get; set; }

		#endregion
	}

	#endregion

	#region Class: LookupSummary

	/// <summary>
	/// Represents summary information about a lookup, including structure and modification metadata.
	/// </summary>
	[DataContract]
	[Serializable]
	public class LookupSummary
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the unique identifier of the lookup.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }


		/// <summary>
		/// Gets or sets the schema unique identifier of the lookup value.
		/// </summary>
		[DataMember(Name = "schemaUId")]
		public Guid SchemaUId { get; set; }


		/// <summary>
		/// Gets or sets the checksum of the lookup
		/// </summary>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		/// <summary>
		/// Gets or sets the last modification date of the lookup
		/// </summary>
		[DataMember(Name = "modifiedOn")]
		public string ModifiedOn { get; set; }

		#endregion
	}

	#endregion

	#region Class: DataForgeCheckLookupsResponse

	/// <summary>
	/// Represents the response from the Data Forge service containing the list of lookup IDs that require updates or were validated.
	/// </summary>
	[DataContract]
	[Serializable]
	public class DataForgeCheckLookupsResponse : BaseResponse
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of lookup IDs returned by the check.
		/// </summary>
		[DataMember(Name = "lookupIds")]
		public List<Guid> LookupIds { get; set; }

		#endregion
	}

	#endregion
}

