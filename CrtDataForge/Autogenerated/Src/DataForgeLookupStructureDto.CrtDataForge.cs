namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;

	#region Class: InitializeLookupsRequestBody

	/// <summary>
	/// Represents the request body for initializing lookup data to the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class InitializeLookupsRequestBody
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of lookup data structures to be uploaded.
		/// </summary>
		[DataMember(Name = "lookups")]
		public List<LookupDefinition> Lookups { get; set; }

		/// <summary>
		/// Gets or sets the list of lookup values to be uploaded.
		/// </summary>
		[DataMember(Name = "lookupValues")]
		public List<LookupValueDefinition> LookupValues { get; set; }

		#endregion

	}

	#endregion

	#region Class: UpdateLookupsRequestBody

	/// <summary>
	/// Represents the request body for updating lookup data to the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class UpdateLookupsRequestBody
	{

		#region Constructors: Public

		public UpdateLookupsRequestBody(IReadOnlyList<LookupDefinition> lookups,
			IReadOnlyList<LookupValueDefinition> lookupValues) {
			Lookups = lookups
				.Select(ld =>
					new DataForgeApiPatchOperation<LookupDefinition>(
						DataForgePatchOperationType.Replace,
						$"/lookup/{ld}",
						ld))
				.ToList();
			LookupValues = lookupValues
				.Select(lvd =>
					new DataForgeApiPatchOperation<LookupValueDefinition>(
						DataForgePatchOperationType.Replace,
						$"/lookupValue/{lvd.SchemaUId}/{lvd.Id}",
						lvd))
				.ToList();
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of lookup data structures to be updated.
		/// </summary>
		[DataMember(Name = "lookups")]
		public List<DataForgeApiPatchOperation<LookupDefinition>> Lookups { get; }

		/// <summary>
		/// Gets or sets the list of lookup values to be updated.
		/// </summary>
		[DataMember(Name = "lookupValues")]
		public List<DataForgeApiPatchOperation<LookupValueDefinition>> LookupValues { get; }

		#endregion

	}

	#endregion

	#region Class: LookupDefinition

	/// <summary>
	/// Represents the structure and metadata of a lookup.
	/// </summary>
	[DataContract]
	[Serializable]
	public class LookupDefinition
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the unique identifier of the lookup.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the lookup.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of the lookup.
		/// </summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the checksum of the lookup.
		/// </summary>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		/// <summary>
		/// Gets or sets the last modified date of the lookup.
		/// </summary>
		[DataMember(Name = "modifiedOn")]
		public string ModifiedOn { get; set; }

		/// <summary>
		/// Gets or sets the schema name of the lookup values.
		/// </summary>
		[DataMember(Name = "valuesSchemaName")]
		public string ValuesSchemaName { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the lookup values schema.
		/// </summary>
		[DataMember(Name = "valuesSchemaUId")]
		public Guid ValuesSchemaUId { get; set; }

		#endregion

	}

	#endregion

	#region Class: LookupValueDefinition

	/// <summary>
	/// Represents the structure and metadata of a lookup value.
	/// </summary>
	[DataContract]
	[Serializable]
	public class LookupValueDefinition
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the unique identifier of the lookup value.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the lookup value.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of the lookup value.
		/// </summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the checksum of the lookup value.
		/// </summary>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		/// <summary>
		/// Gets or sets the last modified date of the lookup value.
		/// </summary>
		[DataMember(Name = "modifiedOn")]
		public string ModifiedOn { get; set; }

		/// <summary>
		/// Gets or sets the unique identifier of the lookup value schema.
		/// </summary>
		[DataMember(Name = "schemaUId")]
		public Guid SchemaUId { get; set; }

		#endregion

	}

	#endregion
}

