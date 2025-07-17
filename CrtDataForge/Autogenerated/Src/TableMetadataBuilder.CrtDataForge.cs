namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: ITableMetadataBuilder

	/// <summary>
	/// Provides functionality for building table metadata structures from entity schemas.
	/// </summary>
	public interface ITableMetadataBuilder
	{
		/// <summary>
		/// Builds metadata for a table based on the provided entity schema and parameters.
		/// </summary>
		/// <param name="schema">The entity schema to build metadata from.</param>
		/// <param name="checksum">Checksum string representing the schema integrity.</param>
		/// <param name="skipSimilarToName">Whether to skip captions/descriptions similar to the name.</param>
		/// <param name="tryMapSqlTypes">Whether to attempt mapping to SQL data types.</param>
		/// <returns>
		/// <see cref="TableDefinition"/> containing the table's detailed metadata, including columns.
		/// </returns>
		TableDefinition BuildDefinition(EntitySchema schema, string checksum, bool skipSimilarToName, bool tryMapSqlTypes);

		/// <summary>
		/// Builds a summary metadata for a table based on the provided entity schema.
		/// </summary>
		/// <param name="schema">The entity schema to build summary from.</param>
		/// <param name="checksum">Checksum string representing the schema integrity.</param>
		/// <returns>
		/// <see cref="TableSummary"/> containing the table's summary metadata without columns.
		/// </returns>
		TableSummary BuildSummary(EntitySchema schema, string checksum);
	}

	#endregion

	#region Class: TableMetadataBuilder

	[DefaultBinding(typeof(ITableMetadataBuilder))]
	internal class TableMetadataBuilder : ITableMetadataBuilder
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("DataForge");
		private readonly IDataTypeMapper _dataTypeMapper;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TableMetadataBuilder"/> class with the specified data type mapper.
		/// </summary>
		/// <param name="dataTypeMapper">The mapper used for converting internal data types to SQL data types.</param>
		public TableMetadataBuilder(IDataTypeMapper dataTypeMapper) {
			_dataTypeMapper = dataTypeMapper;
		}

		#endregion

		#region Methods: Private

		private DateTime GetModifiedOn(EntitySchema instance) {
			var defValue = instance.ModifiedOnColumn?.DefValue;
			if (defValue != null &&
				defValue.Source != EntitySchemaColumnDefSource.None &&
				DateTime.TryParse(defValue.Value?.ToString(), out DateTime parsedDate)) {
				return parsedDate;
			}
			return DateTime.UtcNow;
		}

		private List<ColumnDataStructure> BuildColumns(EntitySchema instance, bool skipSimilarToName, bool tryMapSqlTypes) {
			var result = new List<ColumnDataStructure>();
			foreach (var column in instance.Columns) {
				try {
					bool hasReference = column.ReferenceSchema?.Name.IsNotNullOrWhiteSpace() ?? false;
					bool needsCaption = !string.IsNullOrWhiteSpace(column.Caption) &&
						column.Caption != column.ColumnValueName &&
						(!skipSimilarToName || !string.Equals(column.ColumnValueName, column.Caption.Value.Replace(" ", string.Empty), StringComparison.InvariantCultureIgnoreCase));

					bool needsDescription = !string.IsNullOrWhiteSpace(column.Description) &&
						(!skipSimilarToName || !string.Equals(column.ColumnValueName, column.Description.Value.Replace(" ", string.Empty), StringComparison.InvariantCultureIgnoreCase));

					result.Add(new ColumnDataStructure {
						Name = column.ColumnValueName,
						Type = _dataTypeMapper.MapDataType(column, tryMapSqlTypes),
						Caption = needsCaption ? column.Caption : null,
						Description = needsDescription ? column.Description : null,
						RefersTo = hasReference ? new TableReferenceDataStructure {
							Table = column.ReferenceSchema.Name,
							Column = column.ReferenceSchema.PrimaryColumn?.Name,
						} : null
					});
				} catch (Exception ex) {
					_log.Error($"Error processing column {column.Name} in table {instance.Name}", ex);
				}
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Builds metadata for a table based on the provided entity schema and parameters.
		/// </summary>
		/// <param name="instance">The entity schema to build metadata from.</param>
		/// <param name="checksum">Checksum string representing the schema integrity.</param>
		/// <param name="skipSimilarToName">Whether to skip captions/descriptions similar to the name.</param>
		/// <param name="tryMapSqlTypes">Whether to attempt mapping to SQL data types.</param>
		/// <returns>
		/// <see cref="TableDefinition"/> containing the table's detailed metadata, including columns.
		/// </returns>
		public TableDefinition BuildDefinition(EntitySchema instance, string checksum, bool skipSimilarToName, bool tryMapSqlTypes) {
			bool needsCaption = !string.IsNullOrWhiteSpace(instance.Caption) &&
				instance.Caption.ToString() != instance.Name &&
				(!skipSimilarToName || !string.Equals(instance.Name, instance.Caption.ToString().Replace(" ", string.Empty), StringComparison.InvariantCultureIgnoreCase));

			bool needsDescription = !string.IsNullOrWhiteSpace(instance.Description) &&
				(!skipSimilarToName || !string.Equals(instance.Name, instance.Description.ToString().Replace(" ", string.Empty), StringComparison.InvariantCultureIgnoreCase));

			DateTime modifiedOn = GetModifiedOn(instance);

			return new TableDefinition {
				Name = instance.Name,
				Caption = needsCaption ? instance.Caption.ToString() : null,
				Description = needsDescription ? instance.Description.ToString() : null,
				Checksum = checksum,
				ModifiedOn = modifiedOn.ToString("o"),
				Columns = BuildColumns(instance, skipSimilarToName, tryMapSqlTypes)
			};
		}

		/// <summary>
		/// Builds a summary metadata for a table based on the provided entity schema.
		/// </summary>
		/// <param name="instance">The entity schema to build summary from.</param>
		/// <param name="checksum">Checksum string representing the schema integrity.</param>
		/// <returns>
		/// <see cref="TableSummary"/> containing the table's summary metadata without columns.
		/// </returns>
		public TableSummary BuildSummary(EntitySchema instance, string checksum) {
			DateTime modifiedOn = GetModifiedOn(instance);

			return new TableSummary {
				Name = instance.Name,
				Checksum = checksum,
				ModifiedOn = modifiedOn.ToString("o")
			};
		}

		#endregion

	}

	#endregion
}

