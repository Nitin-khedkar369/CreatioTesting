namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Runtime.Serialization;

	#region Class: LookupValueSummary

	/// <summary>
	/// Represents summary information about a specific lookup value, including value and modification metadata.
	/// </summary>
	[DataContract]
	[Serializable]
	public class LookupValueSummary
	{
		#region Properties: Public

		/// <summary>
		/// Gets or sets the unique identifier of the lookup value.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the schema unique identifier of the lookup value schema.
		/// </summary>
		[DataMember(Name = "schemaUId")]
		public Guid SchemaUId { get; set; }

		/// <summary>
		/// Gets or sets the checksum of the lookup value
		/// </summary>
		[DataMember(Name = "checksum")]
		public string Checksum { get; set; }

		/// <summary>
		/// Gets or sets the last modification date of the lookup value
		/// </summary>
		[DataMember(Name = "modifiedOn")]
		public string ModifiedOn { get; set; }

		#endregion
	}

	#endregion
}

