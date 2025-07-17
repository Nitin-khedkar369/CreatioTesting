namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IDataStructureHandler

	/// <summary>
	/// Provides functionality for retrieving structured and summarized metadata representations of entity schemas.
	/// </summary>
	public interface IDataStructureHandler
	{
		/// <summary>
		/// Retrieves detailed metadata definitions for the specified entity schemas.
		/// </summary>
		/// <param name="skipSimilarToName">If true, omits captions or descriptions that match column or table names.</param>
		/// <param name="tryMapSqlTypes">If true, attempts to map internal types to SQL-compatible types.</param>
		/// <param name="items">The entity schema items to process.</param>
		/// <returns>A list of <see cref="TableDefinition"/> objects representing table metadata.</returns>
		List<TableDefinition> GetTableDefinitions(
			bool skipSimilarToName = true,
			bool tryMapSqlTypes = false,
			params ISchemaManagerItem<EntitySchema>[] items);

		/// <summary>
		/// Retrieves detailed metadata definitions for the specified entity schemas.
		/// </summary>
		/// <param name="skipSimilarToName">If true, omits captions or descriptions that match column or table names.</param>
		/// <param name="tryMapSqlTypes">If true, attempts to map internal types to SQL-compatible types.</param>
		/// <param name="items">A collection of schema manager items to process. If null, all schemas will be used.</param>
		/// <returns>A list of <see cref="TableDefinition"/> objects representing table metadata.</returns>
		List<TableDefinition> GetTableDefinitions(
			bool skipSimilarToName = true,
			bool tryMapSqlTypes = false,
			IEnumerable<ISchemaManagerItem<EntitySchema>> items = null);

		/// <summary>
		/// Retrieves simplified summaries for the specified entity schemas.
		/// </summary>
		/// <param name="items">The schema manager items to summarize.</param>
		/// <returns>A list of <see cref="TableSummary"/> objects representing schema summaries.</returns>
		List<TableSummary> GetTableSummaries(params ISchemaManagerItem<EntitySchema>[] items);

		/// <summary>
		/// Retrieves simplified summaries for the specified entity schemas.
		/// </summary>
		/// <param name="items">A collection of schema manager items to summarize. If null, all schemas will be used.</param>
		/// <returns>A list of <see cref="TableSummary"/> objects representing schema summaries.</returns>
		List<TableSummary> GetTableSummaries(IEnumerable<ISchemaManagerItem<EntitySchema>> items = null);

		/// <summary>
		/// Retrieves detailed metadata definition for a single entity schema.
		/// </summary>
		/// <param name="item">The entity schema item to process.</param>
		/// <param name="skipSimilarToName">If true, omits captions or descriptions that match column or table names.</param>
		/// <param name="tryMapSqlTypes">If true, attempts to map internal types to SQL-compatible types.</param>
		/// <returns>A <see cref="TableDefinition"/> object representing table metadata, or null if the schema is invalid or not processed.</returns>
		TableDefinition GetTableDefinition(
			ISchemaManagerItem<EntitySchema> item,
			bool skipSimilarToName = true,
			bool tryMapSqlTypes = false);

	}

	#endregion

	#region Class: DataStructureHandler

	[DefaultBinding(typeof(IDataStructureHandler))]
	internal class DataStructureHandler : IDataStructureHandler
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("DataForge");
		private readonly ISchemaChecksumProvider _checksumProvider;
		private readonly ITableMetadataBuilder _tableMetadataBuilder;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="DataStructureHandler"/> class with the specified dependencies.
		/// </summary>
		/// <param name="userConnection">The user connection context for database and user-specific operations.</param>
		/// <param name="checksumProvider">The provider responsible for retrieving schema checksums.</param>
		/// <param name="tableMetadataBuilder">The builder used to construct table metadata structures.</param>
		public DataStructureHandler(
			UserConnection userConnection,
			ISchemaChecksumProvider checksumProvider,
			ITableMetadataBuilder tableMetadataBuilder) {
			_userConnection = userConnection;
			_checksumProvider = checksumProvider;
			_tableMetadataBuilder = tableMetadataBuilder;
		}

		#endregion

		#region Methods: Private

		private List<T> ProcessSchemas<T>(
			IEnumerable<ISchemaManagerItem<EntitySchema>> items,
			Func<EntitySchema, string, T> builderFunc,
			string errorPrefix) {

			var schemas = (items?.Any() == true
					? items
					: _userConnection.EntitySchemaManager.GetItems())
				.Select(i => i.SafeInstance)
				.Where(s => s != null && !s.IsVirtual)
				.ToList();

			var checksums = _checksumProvider.GetChecksums();
			var result = new List<T>();

			foreach (var schema in schemas) {
				try {
					var checksum = checksums.TryGetValue(schema.Name, out var h) ? h : null;
					result.Add(builderFunc(schema, checksum));
				} catch (Exception ex) {
					_log.Error($"{errorPrefix} {schema.Name}", ex);
				}
			}

			return result;
		}

		private List<TableDefinition> GetTableDefinitionsCore(
			bool skipSimilarToName,
			bool tryMapSqlTypes,
			IEnumerable<ISchemaManagerItem<EntitySchema>> items) {

			return ProcessSchemas(items,
				(schema, checksum) => _tableMetadataBuilder.BuildDefinition(schema, checksum, skipSimilarToName, tryMapSqlTypes),
				"Error processing table");
		}

		private List<TableSummary> GetTableSummariesCore(
			IEnumerable<ISchemaManagerItem<EntitySchema>> items) {

			return ProcessSchemas(items,
				(schema, checksum) => _tableMetadataBuilder.BuildSummary(schema, checksum),
				"Error building summary for");
		}


		#endregion

		#region Methods: Public

		/// <summary>
		/// Retrieves detailed table definitions for the given entity schemas.
		/// </summary>
		/// <param name="skipSimilarToName">If true, omits redundant captions or descriptions.</param>
		/// <param name="tryMapSqlTypes">If true, maps internal types to SQL-compatible types.</param>
		/// <param name="items">The schema items to process.</param>
		/// <returns>A list of <see cref="TableDefinition"/> objects with complete metadata.</returns>
		public List<TableDefinition> GetTableDefinitions(
				bool skipSimilarToName = true,
				bool tryMapSqlTypes = false,
				params ISchemaManagerItem<EntitySchema>[] items) =>
			GetTableDefinitionsCore(skipSimilarToName, tryMapSqlTypes, items);

		/// <summary>
		/// Retrieves detailed table definitions for the given entity schemas.
		/// </summary>
		/// <param name="skipSimilarToName">If true, omits redundant captions or descriptions.</param>
		/// <param name="tryMapSqlTypes">If true, maps internal types to SQL-compatible types.</param>
		/// <param name="items">A collection of schema manager items to process. If null, all schemas will be included.</param>
		/// <returns>A list of <see cref="TableDefinition"/> objects with complete metadata.</returns>
		public List<TableDefinition> GetTableDefinitions(
				bool skipSimilarToName = true,
				bool tryMapSqlTypes = false,
				IEnumerable<ISchemaManagerItem<EntitySchema>> items = null) =>
			GetTableDefinitionsCore(skipSimilarToName, tryMapSqlTypes, items);

		/// <summary>
		/// Retrieves summarized metadata for the given entity schemas.
		/// </summary>
		/// <param name="items">The schema items to summarize.</param>
		/// <returns>A list of <see cref="TableSummary"/> objects representing schema summaries.</returns>
		public List<TableSummary> GetTableSummaries(params ISchemaManagerItem<EntitySchema>[] items) =>
			GetTableSummariesCore(items);

		/// <summary>
		/// Retrieves summarized metadata for the given entity schemas.
		/// </summary>
		/// <param name="items">A collection of schema manager items to summarize. If null, all schemas will be used.</param>
		/// <returns>A list of <see cref="TableSummary"/> objects representing schema summaries.</returns>
		public List<TableSummary> GetTableSummaries(IEnumerable<ISchemaManagerItem<EntitySchema>> items = null) =>
			GetTableSummariesCore(items);

		/// <summary>
		/// Retrieves detailed metadata definition for a single entity schema.
		/// </summary>
		/// <param name="item">The entity schema item to process.</param>
		/// <param name="skipSimilarToName">If true, omits captions or descriptions that match column or table names.</param>
		/// <param name="tryMapSqlTypes">If true, attempts to map internal types to SQL-compatible types.</param>
		/// <returns>A <see cref="TableDefinition"/> object representing table metadata, or null if the schema is invalid or not processed.</returns>
		public TableDefinition GetTableDefinition(
			ISchemaManagerItem<EntitySchema> item,
			bool skipSimilarToName = true,
			bool tryMapSqlTypes = false) =>
			 item == null
				? null
				: GetTableDefinitions(skipSimilarToName, tryMapSqlTypes, item).FirstOrDefault();

		#endregion
	}

	#endregion
}

