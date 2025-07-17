namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Requests;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.OAuthIntegration;

	#region Interface: IDataForgeService

	/// <summary>
	/// Provides methods for interacting with the Data Forge service for synchronizing data structures and lookups.
	/// </summary>
	public interface IDataForgeService
	{
		/// <summary>
		/// Checks the state of lookups in the Data Forge service.
		/// </summary>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		/// <returns>A <see cref="DataForgeCheckLookupsResponse"/> representing the result of the lookup state check.</returns>
		DataForgeCheckLookupsResponse CheckLookupsState(CancellationToken cancellationToken = default);

		/// <summary>
		/// Checks the state of the specified tables in the Data Forge service.
		/// </summary>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		/// <param name="schemaItems">Tables to check.</param>
		/// <returns>A <see cref="DataForgeCheckTablesResponse"/> representing the table state check result.</returns>
		DataForgeCheckTablesResponse CheckTablesState(CancellationToken cancellationToken = default, params ISchemaManagerItem<EntitySchema>[] schemaItems);

		/// <summary>
		/// Deletes a lookup by its identifier.
		/// </summary>
		/// <param name="id">Lookup identifier.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void DeleteLookup(Guid id, CancellationToken cancellationToken = default);

		/// <summary>
		/// Gets lookups similar to the provided query string.
		/// </summary>
		/// <param name="queryString">Search query.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		/// <returns>A <see cref="DataForgeGetLookupsResponse"/> containing similar lookups.</returns>
		DataForgeGetLookupsResponse GetSimilarLookups(string queryString, CancellationToken cancellationToken = default);

		/// <summary>
		/// Gets table names similar to the provided query string.
		/// </summary>
		/// <param name="queryString">Search query.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		/// <returns>A <see cref="DataForgeGetTablesResponse"/> containing similar table names.</returns>
		DataForgeGetTablesResponse GetSimilarTableNames(string queryString, CancellationToken cancellationToken = default);

		/// <summary>
		/// Gets relationships between two specified tables.
		/// </summary>
		/// <param name="sourceTable">Source table name.</param>
		/// <param name="targetTable">Target table name.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		/// <returns>A <see cref="GetTableRelationshipsResponse"/> with relationship information.</returns>
		GetTableRelationshipsResponse GetTableRelationships(string sourceTable, string targetTable, CancellationToken cancellationToken = default);

		/// <summary>
		/// Initializes all data structures in the Data Forge service.
		/// </summary>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void InitializeDataStructure(CancellationToken cancellationToken = default);

		/// <summary>
		/// Initializes all lookups in the Data Forge service.
		/// </summary>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void InitializeLookups(CancellationToken cancellationToken = default);

		/// <summary>
		/// Removes a table structure by schema.
		/// </summary>
		/// <param name="schema">Entity schema to remove.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void RemoveEntity(ISchemaManagerItem<EntitySchema> schema, CancellationToken cancellationToken = default);

		/// <summary>
		/// Updates lookups for the specified value entity.
		/// </summary>
		/// <param name="entity">Entity whose lookups should be updated.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void UpdateLookupsForValue(Entity entity, CancellationToken cancellationToken = default);

		/// <summary>
		/// Uploads table definitions for the given schema items.
		/// </summary>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		/// <param name="schemaItems">Schema items to upload.</param>
		void UploadDataStructure(CancellationToken cancellationToken = default, params ISchemaManagerItem<EntitySchema>[] schemaItems);

		/// <summary>
		/// Uploads a single entity (table) definition.
		/// </summary>
		/// <param name="schemaItem">Schema item to upload.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void UploadEntity(ISchemaManagerItem<EntitySchema> schemaItem, CancellationToken cancellationToken = default);

		/// <summary>
		/// Uploads a single lookup definition.
		/// </summary>
		/// <param name="entity">Lookup entity.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void UploadLookup(Entity entity, CancellationToken cancellationToken = default);

		/// <summary>
		/// Uploads multiple lookups by their identifiers.
		/// </summary>
		/// <param name="ids">Identifiers of lookups to upload.</param>
		/// <param name="cancellationToken">Cancellation token for the operation.</param>
		void UploadLookups(IReadOnlyList<Guid> ids, CancellationToken cancellationToken = default);
	}


	#endregion

	[DefaultBinding(typeof(IDataForgeService), Name = "DefaultDataForgeService")]
	public class DataForgeService : IDataForgeService
	{

		#region Class: ApiRoutes

		private static class ApiRoutes
		{

			#region Constants: Private

			private const string ApiV1Prefix = "/api/v1";

			#endregion

			#region Class: DataStructure

			public static class DataStructure
			{

				#region Constants: Private

				private const string Base = ApiV1Prefix + "/dataStructure";

				#endregion

				#region Constants: Public

				public const string InitializeAll = Base;
				public const string UpdateAll = Base;
				public const string SimilarTables = Base + "/tables/similar";
				public const string RelationshipsJson = Base + "/tables/relations/json";
				public const string RelationshipsCypher = Base + "/tables/relations/cypher";
				public const string State = Base + "/state";
				public const string Table = Base + "/table";

				#endregion

			}

			#endregion

			#region Class: Lookups

			public static class Lookups
			{

				#region Constants: Private

				private const string Base = ApiV1Prefix + "/lookups";

				#endregion

				#region Constants: Public

				public const string InitializeAll = Base;
				public const string UpdateAll = Base;
				public const string Lookup = Base + "/lookup";
				public const string State = Base + "/state";
				public const string SimilarLookups = Base + "/similar";

				#endregion

			}

			#endregion

		}

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("DataForge");
		private readonly IDataStructureHandler _dataStructureHandler;
		private readonly ILookupHandler _lookupHandler;
		private readonly UserConnection _userConnection;
		private readonly IHttpRequestClient _httpClient;
		private readonly IIdentityServiceWrapper _identityServiceWrapper;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="DataForgeService"/> class with the specified dependencies.
		/// </summary>
		/// <param name="dataStructureHandler">Service for retrieving and handling table data structures.</param>
		/// <param name="lookupHandler">Service for managing lookup definitions and values.</param>
		/// <param name="userConnection">The user connection context for accessing configuration and schema data.</param>
		/// <param name="httpRequestClient">The HTTP client used for sending requests to the Data Forge service.</param>
		/// <param name="identityServiceWrapper">The identity service wrapper for authenticating and authorizing outgoing HTTP requests.</param>
		public DataForgeService(
			IDataStructureHandler dataStructureHandler,
			ILookupHandler lookupHandler,
			UserConnection userConnection,
			IHttpRequestClient httpRequestClient,
			IIdentityServiceWrapper identityServiceWrapper) {
			_dataStructureHandler = dataStructureHandler;
			_lookupHandler = lookupHandler;
			_userConnection = userConnection;
			_httpClient = httpRequestClient;
			_identityServiceWrapper = identityServiceWrapper;
		}

		#endregion

		#region Properties: Private

		private Uri ServiceUrl {
			get {
				var value = (string)SysSettings.GetValue(_userConnection, "DataForgeServiceUrl");
				return new Uri(value);
			}
		}

		private int RequestTimeout {
			get {
				int value = SysSettings.GetValue(_userConnection, "DataForgeServiceQueryTimeout",
					30000);
				if (value < 0) {
					value = 0;
				}
				return value / 1000;
			}
		}

		private int LookupResultLimit {
			get {
				return SysSettings.GetValue(_userConnection,
					"DataForgeLookupResultLimit", 5);
			}
		}

		private int TableRelationshipsCountLimit {
			get {
				return SysSettings.GetValue(_userConnection,
					"DataForgeTableRelationshipsCountLimit", 5);
			}
		}

		private bool TableRelationshipsDetailsIncluded {
			get {
				return SysSettings.GetValue(_userConnection,
					"DataForgeTableRelationshipsDetailsIncluded", false);
			}
		}

		#endregion

		#region Methods: Private
		private HttpRequestConfig CreateRequest(
			string relativePath,
			HttpRequestMethod method,
			object body = null,
			Dictionary<string, string> queryParams = null,
			Guid? id = null,
			CancellationToken cancellationToken = default) {
			string path = id.HasValue ? $"{relativePath}/{id}" : relativePath;
			var url = new Uri(ServiceUrl, path);

			HttpRequestConfig request = new HttpRequestConfig {
				Url = url,
				Method = method,
				RequestTimeout = RequestTimeout,
				Body = body,
				CancellationToken = cancellationToken
			}.WithOAuth<DataForgeFeatures.UseOAuth>(_identityServiceWrapper, string.Empty);

			if (queryParams != null) {
				foreach (KeyValuePair<string, string> param in queryParams) {
					request.AddQueryParam(param.Key, param.Value);
				}
			}

			return request;
		}

		private HttpRequestConfig CreateGetTablesRequest(
			string queryString,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
				ApiRoutes.DataStructure.SimilarTables,
				HttpRequestMethod.GET,
				queryParams: new Dictionary<string, string> {
					{ "query", queryString }
				},
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateGetLookupsRequest(
			string queryString,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
			   ApiRoutes.Lookups.SimilarLookups,
				HttpRequestMethod.GET,
				queryParams: new Dictionary<string, string> {
					{ "query", queryString },
					{ "limit", LookupResultLimit.ToString() }
				},
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateInitializeDataStructureRequest(
			List<TableDefinition> tableDefinitions,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
				ApiRoutes.DataStructure.InitializeAll,
				HttpRequestMethod.POST,
				body: new DataForgeInitializeDataStructureRequestBody(tableDefinitions),
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateUpdateDataStructureRequest(
			List<TableDefinition> tableDefinitions,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
				ApiRoutes.DataStructure.UpdateAll,
				HttpRequestMethod.PATCH,
				body: new DataForgeUpdateDataStructureRequestBody(tableDefinitions),
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateUploadTableStructureRequest(
			TableDefinition tableDefinition,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
				ApiRoutes.DataStructure.Table,
				HttpRequestMethod.POST,
				body: new DataForgeUploadTableStructureRequestBody { Table = tableDefinition },
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateRemoveTableStructureRequest(
			string tableName,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
				$"{ApiRoutes.DataStructure.Table}/{tableName}",
				HttpRequestMethod.DELETE,
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateGetDataStructureStateRequest(
			List<TableSummary> tableSummaries,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
				ApiRoutes.DataStructure.State,
				HttpRequestMethod.POST,
				body: new DataForgeCheckTablesRequestBody { TableStates = tableSummaries },
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateGetTableRelationshipsRequest(
			string sourceTable,
			string targetTable,
			int limit,
			bool bidirectional,
			bool skipDetails,
			CancellationToken cancellationToken = default) =>
			CreateRequest(
				ApiRoutes.DataStructure.RelationshipsCypher,
				HttpRequestMethod.GET,
				queryParams: new Dictionary<string, string> {
					{ "sourceTable", sourceTable },
					{ "targetTable", targetTable },
					{ "limit", limit.ToString() },
					{ "bidirectional", bidirectional.ToString() },
					{ "skipDetails", skipDetails.ToString() }
				},
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateGetLookupsStateRequest(
			List<LookupSummary> lookupSummaries,
			List<LookupValueSummary> lookupValueSummaries,
			CancellationToken cancellationToken = default) =>
			CreateRequest(ApiRoutes.Lookups.State,
				HttpRequestMethod.POST,
				body: new DataForgeCheckLookupsRequestBody {
					Lookups = lookupSummaries,
					LookupValues = lookupValueSummaries
				},
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateInitializeLookupsRequest(
			List<LookupDefinition> lookupDefinitions,
			List<LookupValueDefinition> lookupValuesDefinitions,
			CancellationToken cancellationToken = default) =>
			CreateRequest(ApiRoutes.Lookups.InitializeAll,
				HttpRequestMethod.POST,
				body: new InitializeLookupsRequestBody {
					Lookups = lookupDefinitions,
					LookupValues = lookupValuesDefinitions
				},
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateUpdateLookupsRequest(
			List<LookupDefinition> lookupDefinitions,
			List<LookupValueDefinition> lookupValuesDefinitions,
			CancellationToken cancellationToken = default) =>
			CreateRequest(ApiRoutes.Lookups.UpdateAll,
				HttpRequestMethod.PATCH,
				body: new UpdateLookupsRequestBody(lookupDefinitions, lookupValuesDefinitions),
				cancellationToken: cancellationToken);

		private HttpRequestConfig CreateDeleteLookupRequest(Guid id, CancellationToken cancellationToken = default) =>
			CreateRequest(
				ApiRoutes.Lookups.Lookup,
				HttpRequestMethod.DELETE,
				id: id,
				cancellationToken: cancellationToken);

		private T ProcessResponse<T>(IHttpResponse response) {
			if (response.IsTimedOut) {
				_log.Error("DataForgeService request timed out.");
				throw new TimeoutException("DataForge service request timed out.");
			}

			if (response.Exception != null || !response.IsSuccessStatusCode) {
				string error = response.Exception?.Message ?? response.ReasonPhrase;
				_log.Error($"DataForgeService request failed: {error}");
				throw new InvalidOperationException($"DataForge service request failed: {error}");
			}

			if (string.IsNullOrWhiteSpace(response.Content)) {
				return default;
			}

			try {
				return JsonConvert.DeserializeObject<T>(response.Content);
			} catch (Exception ex) {
				_log.Error($"DataForgeService response deserialization failed: {ex.Message}");
				throw new InvalidOperationException("Failed to parse DataForge service response.", ex);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Retrieves similar table names based on the provided query string.
		/// </summary>
		/// <param name="queryString">The search query used to find similar table names.</param>
		/// <returns>
		/// A <see cref="DataForgeGetTablesResponse"/> object containing the list of table names,
		/// success flag, and error information if applicable.
		/// </returns>
		public DataForgeGetTablesResponse GetSimilarTableNames(string queryString, CancellationToken cancellationToken = default) {
			DataForgeGetTablesResponse dfResponse = new DataForgeGetTablesResponse();

			try {
				HttpRequestConfig request = CreateGetTablesRequest(queryString, cancellationToken);
				IHttpResponse response = _httpClient.Send(request);
				List<string> result = ProcessResponse<List<string>>(response);

				if (result != null) {
					dfResponse.Data = result;
					dfResponse.Success = true;
				}
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during GetSimilarTableNames: {ex.Message}");
				dfResponse.Success = false;
				dfResponse.ErrorInfo = new ErrorInfo {
					Message = ex.Message,
					StackTrace = ex.StackTrace
				};
			}

			return dfResponse;
		}

		/// <summary>
		/// Retrieves similar lookups based on the provided query string.
		/// </summary>
		/// <param name="queryString">The search query used to find similar table names.</param>
		/// <returns>
		/// A <see cref="DataForgeGetLookupsResponse"/> object containing the list of retrieved lookups,
		/// success flag, and error information if applicable.
		/// </returns>
		public DataForgeGetLookupsResponse GetSimilarLookups(string queryString, CancellationToken cancellationToken = default) {
			DataForgeGetLookupsResponse dfResponse = new DataForgeGetLookupsResponse();

			try {
				HttpRequestConfig request = CreateGetLookupsRequest(queryString, cancellationToken);
				IHttpResponse response = _httpClient.Send(request);
				List<LookupDefinitionResponse> result = ProcessResponse<List<LookupDefinitionResponse>>(response);

				if (result != null) {
					dfResponse.Data = result;
					dfResponse.Success = true;
				}
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during GetSimilarLookups: {ex.Message}");
				dfResponse.Success = false;
				dfResponse.ErrorInfo = new ErrorInfo {
					Message = ex.Message,
					StackTrace = ex.StackTrace
				};
			}

			return dfResponse;
		}

		/// <summary>
		/// Retrieves the relationships between two specified tables from the DataForge service.
		/// </summary>
		/// <param name="sourceTable">The name of the source table to check for relationships.</param>
		/// <param name="targetTable">The name of the target table to check for relationships.</param>
		/// <returns>
		/// A <see cref="GetTableRelationshipsResponse"/> object containing relationship details or error information.
		/// </returns>
		public GetTableRelationshipsResponse GetTableRelationships(
			string sourceTable,
			string targetTable,
			CancellationToken cancellationToken = default) {
			var dfResponse = new GetTableRelationshipsResponse();
			try {
				HttpRequestConfig request = CreateGetTableRelationshipsRequest(
					sourceTable,
					targetTable,
					TableRelationshipsCountLimit,
					true,
					!TableRelationshipsDetailsIncluded,
					cancellationToken);
				IHttpResponse response = _httpClient.Send(request);
				List<string> result = ProcessResponse<List<string>>(response);

				if (result != null) {
					dfResponse.Paths = result;
					dfResponse.Success = true;
				}
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during GetTableRelationships: {ex.Message}");
				dfResponse.Success = false;
				dfResponse.ErrorInfo = new ErrorInfo {
					Message = ex.Message,
					StackTrace = ex.StackTrace,
				};
			}

			return dfResponse;
		}

		/// <inheritdoc/>
		public void InitializeDataStructure(CancellationToken cancellationToken = default) {
			try {
				List<TableDefinition> tableDataStructures = _dataStructureHandler.GetTableDefinitions(false, true);
				HttpRequestConfig request = CreateInitializeDataStructureRequest(
					tableDataStructures,
					cancellationToken);
				IHttpResponse response = _httpClient.SendWithJsonBody(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during InitializeDataStructure: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public void UploadDataStructure(CancellationToken cancellationToken = default, params ISchemaManagerItem<EntitySchema>[] schemaItems) {
			try {
				List<TableDefinition> tableDataStructures = _dataStructureHandler.GetTableDefinitions(false, true, schemaItems);
				HttpRequestConfig request = CreateUpdateDataStructureRequest(
					tableDataStructures,
					cancellationToken);
				IHttpResponse response = _httpClient.SendWithJsonBody(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during UploadDataStructure: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public DataForgeCheckTablesResponse CheckTablesState(
			CancellationToken cancellationToken = default,
			params ISchemaManagerItem<EntitySchema>[] schemaItems) {
			DataForgeCheckTablesResponse response = new DataForgeCheckTablesResponse();
			try {
				List<TableSummary> tableSummaries = _dataStructureHandler.GetTableSummaries(schemaItems);
				HttpRequestConfig request = CreateGetDataStructureStateRequest(tableSummaries, cancellationToken);
				IHttpResponse httpResponse = _httpClient.SendWithJsonBody(request);
				DataForgeCheckTablesResponse processedResponse = ProcessResponse<DataForgeCheckTablesResponse>(httpResponse);

				if (processedResponse != null) {
					response.TableNames = processedResponse?.TableNames;
					response.Success = true;
				}
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during CheckTablesState: {ex.Message}");
				response.Success = false;
				response.ErrorInfo = new ErrorInfo {
					Message = ex.Message,
					StackTrace = ex.StackTrace
				};
			}

			return response;
		}

		/// <inheritdoc/>
		public void UploadEntity(ISchemaManagerItem<EntitySchema> schemaItem, CancellationToken cancellationToken = default) {
			try {
				TableDefinition tableDefinition = _dataStructureHandler.GetTableDefinition(schemaItem, false, true);
				HttpRequestConfig request = CreateUploadTableStructureRequest(tableDefinition, cancellationToken);
				IHttpResponse response = _httpClient.SendWithJsonBody(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during UploadTableStructure: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public void RemoveEntity(ISchemaManagerItem<EntitySchema> schema, CancellationToken cancellationToken = default) {
			try {
				string tableName = schema.Name;
				if (string.IsNullOrWhiteSpace(tableName)) {
					throw new ArgumentNullException(nameof(tableName), "Table name cannot be null or empty.");
				}
				HttpRequestConfig request = CreateRemoveTableStructureRequest(tableName, cancellationToken);
				IHttpResponse response = _httpClient.Send(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during RemoveTableStructure: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public DataForgeCheckLookupsResponse CheckLookupsState(CancellationToken cancellationToken = default) {
			DataForgeCheckLookupsResponse response = new DataForgeCheckLookupsResponse();
			try {
				List<LookupSummary> lookupSummaries = _lookupHandler.GetLookupSummaries();
				List<LookupValueSummary> lookupValueSummaries = _lookupHandler.GetLookupValueSummaries();
				HttpRequestConfig request = CreateGetLookupsStateRequest(
					lookupSummaries,
					lookupValueSummaries,
					cancellationToken);
				IHttpResponse httpResponse = _httpClient.SendWithJsonBody(request);
				DataForgeCheckLookupsResponse processedResponse = ProcessResponse<DataForgeCheckLookupsResponse>(httpResponse);

				if (processedResponse != null) {
					response.LookupIds = processedResponse?.LookupIds;
					response.Success = true;
				}
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during CheckLookupsState: {ex.Message}");
				response.Success = false;
				response.ErrorInfo = new ErrorInfo {
					Message = ex.Message,
					StackTrace = ex.StackTrace
				};
			}

			return response;
		}

		/// <inheritdoc/>
		public void InitializeLookups(CancellationToken cancellationToken = default) {
			try {
				List<LookupDefinition> lookupDefinitions = _lookupHandler.GetLookupDefinitions();
				List<Guid> ids = lookupDefinitions.Select(ld => ld.Id).ToList();
				List<LookupValueDefinition> lookupValueDefinitions = _lookupHandler.GetLookupValueDefinitionsForLookups(ids);
				HttpRequestConfig request = CreateInitializeLookupsRequest(
					lookupDefinitions,
					lookupValueDefinitions,
					cancellationToken);
				IHttpResponse response = _httpClient.SendWithJsonBody(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during UploadLookups: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public void UploadLookups(IReadOnlyList<Guid> ids, CancellationToken cancellationToken = default) {
			try {
				List<LookupDefinition> lookupDefinitions = _lookupHandler.GetLookupDefinitions(ids);
				List<LookupValueDefinition> lookupValueDefinitions = _lookupHandler.GetLookupValueDefinitionsForLookups(ids);
				HttpRequestConfig request = CreateUpdateLookupsRequest(
					lookupDefinitions,
					lookupValueDefinitions,
					cancellationToken);
				IHttpResponse response = _httpClient.SendWithJsonBody(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during UploadLookups: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public void UploadLookup(Entity entity, CancellationToken cancellationToken = default) {
			try {
				LookupDefinition lookupDefinition = _lookupHandler.GetLookupDefinition(entity);
				if (lookupDefinition == null) {
					_log.Error("Failed to get lookup definition for the provided entity.");
					return;
				}
				List<LookupValueDefinition> lookupValueDefinitions = _lookupHandler.GetLookupValueDefinitions(entity);
				HttpRequestConfig requestConfig = CreateUpdateLookupsRequest(
					new List<LookupDefinition> { lookupDefinition },
					lookupValueDefinitions,
					cancellationToken);
				IHttpResponse response = _httpClient.SendWithJsonBody(requestConfig);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during UpdateLookup: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public void DeleteLookup(Guid id, CancellationToken cancellationToken = default) {
			try {
				HttpRequestConfig request = CreateDeleteLookupRequest(id, cancellationToken);
				IHttpResponse response = _httpClient.Send(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during DeleteLookup: {ex.Message}");
			}
		}

		/// <inheritdoc/>
		public void UpdateLookupsForValue(Entity entity, CancellationToken cancellationToken = default) {
			try {
				List<LookupDefinition> lookupDefinitions = _lookupHandler.GetLookupDefinitionsForValue(entity);
				List<LookupValueDefinition> lookupValueDefinitions = _lookupHandler.GetLookupValueDefinitions(entity);
				HttpRequestConfig request = CreateUpdateLookupsRequest(lookupDefinitions, lookupValueDefinitions, cancellationToken);
				IHttpResponse response = _httpClient.SendWithJsonBody(request);
				ProcessResponse<object>(response);
			} catch (Exception ex) {
				_log.Error($"DataForgeService encountered an error during UpdateLookupValue: {ex.Message}");
			}
		}

		#endregion

	}
}

