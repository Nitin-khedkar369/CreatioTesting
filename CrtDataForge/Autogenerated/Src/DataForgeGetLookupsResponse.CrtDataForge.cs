 namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Core.ServiceModelContract;

	#region Class: DataForgeGetLookupsResponse

	/// <summary>
	/// Represents the response model for retrieving lookups in the Data Forge service.
	/// </summary>
	[DataContract]
	public class DataForgeGetLookupsResponse : BaseResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of lookups retrieved from the Data Forge service.
		/// </summary>
		[DataMember(Name = "data")]
		public List<LookupDefinitionResponse> Data { get; set; }

		#endregion

	}

	#endregion

	#region Class: LookupDefinitionResponse

	[DataContract]
	public class LookupDefinitionResponse
	{

		#region Properties: Public

		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "referenceSchemaName")]
		public string ReferenceSchemaName { get; set; }

		[DataMember(Name = "valueId")]
		public string ValueId { get; set; }

		[DataMember(Name = "valueName")]
		public string ValueName { get; set; }

		[DataMember(Name = "vectorSimilarityScore")]
		public double VectorSimilarityScore { get; set; }

		#endregion

	}

	#endregion

}

