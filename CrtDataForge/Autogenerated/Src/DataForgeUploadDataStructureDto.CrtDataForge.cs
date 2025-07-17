namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;

	#region Class: DataForgeInitializeDataStructureRequestBody

	/// <summary>
	/// Represents the request body for uploading data structures to the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class DataForgeInitializeDataStructureRequestBody
	{

		#region Constructors: Public

		public DataForgeInitializeDataStructureRequestBody(List<TableDefinition> tableDefinitions) {
			Tables = tableDefinitions;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of table data structures to be uploaded.
		/// </summary>
		[DataMember(Name = "tables")]
		public List<TableDefinition> Tables { get; }

		#endregion
	}

	#endregion

	#region Class: DataForgeUpdateDataStructureRequestBody

	/// <summary>
	/// Represents the request body for uploading data structures to the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class DataForgeUpdateDataStructureRequestBody
	{

		#region Constructors: Public

		public DataForgeUpdateDataStructureRequestBody(List<TableDefinition> tableDefinitions) {
			Tables = tableDefinitions
				.Select(td =>
					new DataForgeApiPatchOperation<TableDefinition>(
						DataForgePatchOperationType.Replace,
						$"/table/{td.Name}",
						td))
				.ToList();
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the list of table data structures to be uploaded.
		/// </summary>
		[DataMember(Name = "tables")]
		public List<DataForgeApiPatchOperation<TableDefinition>> Tables { get; }

		#endregion

	}

	#endregion

	#region Class DataForgeUploadTableStructureRequestBody

	/// <summary>
	/// Represents the request body for uploading a single table data structure to the Data Forge service.
	/// </summary>
	[DataContract]
	[Serializable]
	public class DataForgeUploadTableStructureRequestBody
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the table data structures to be uploaded.
		/// </summary>
		[DataMember(Name = "table")]
		public TableDefinition Table { get; set; }

		#endregion

	}

	#endregion

	#region Class: TableDataStructure

	/// <summary>
	/// Represents the structure and metadata of a database table.
	/// </summary>
	[DataContract]
	[Serializable]
	public class TableDefinition
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the name of the table.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the display caption of the table.
		/// </summary>
		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		/// <summary>
		/// Gets or sets the description of the table.
		/// </summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

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

		/// <summary>
		/// Gets or sets the list of column definitions for the table.
		/// </summary>
		[DataMember(Name = "columns")]
		public List<ColumnDataStructure> Columns { get; set; }

		#endregion

	}

	#endregion

	#region Class: ColumnDataStructure

	/// <summary>
	/// Represents the structure and metadata of a table column.
	/// </summary>
	[DataContract]
	[Serializable]
	public class ColumnDataStructure
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the name of the column.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the data type of the column.
		/// </summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the display caption of the column.
		/// </summary>
		[DataMember(Name = "caption")]
		public string Caption { get; set; }

		/// <summary>
		/// Gets or sets the description of the column.
		/// </summary>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the name of the table that this column refers to, if any.
		/// </summary>
		[DataMember(Name = "refersTo")]
		public TableReferenceDataStructure RefersTo { get; set; }

		#endregion

	}

	#endregion

	#region Class: TableReferenceDataStructure

	/// <summary>
	/// Represents a reference to a table and its associated column.
	/// </summary>
	[DataContract]
	[Serializable]
	public class TableReferenceDataStructure
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the name of the referenced table.
		/// </summary>
		[DataMember(Name = "table")]
		public string Table { get; set; }

		/// <summary>
		/// Gets or sets the name of the referenced column.
		/// </summary>
		[DataMember]
		public string Column { get; set; }

		#endregion

	}

	#endregion

}

