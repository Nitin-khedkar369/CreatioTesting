namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: ILookupHandler

	/// <summary>
	/// Provides functionality to identify and extract lookup definitions and values.
	/// </summary>
	public interface ILookupHandler
	{
		/// <summary>
		/// Determines whether the given entity represents a lookup schema.
		/// </summary>
		/// <param name="entity">The entity to evaluate.</param>
		/// <returns><c>true</c> if the entity is a lookup schema; otherwise, <c>false</c>.</returns>
		bool IsLookup(Entity entity);

		/// <summary>
		/// Determines whether the given entity is a lookup value.
		/// </summary>
		/// <param name="entity">The entity to evaluate.</param>
		/// <returns><c>true</c> if the entity is a lookup value; otherwise, <c>false</c>.</returns>
		bool IsLookupValue(Entity entity);

		/// <summary>
		/// Constructs a complete lookup definition from the specified lookup schema entity,
		/// </summary>
		/// <param name="entity">The lookup schema entity.</param>
		/// <returns>A populated <see cref="LookupDefinition"/> object.</returns>
		LookupDefinition GetLookupDefinition(Entity entity);

		/// <summary>
		/// Constructs a definition of a single lookup value (record) from the given entity.
		/// </summary>
		/// <param name="entity">The entity representing a lookup record.</param>
		/// <returns>A populated <see cref="LookupValueDefinition"/> object.</returns>
		LookupValueDefinition GetLookupValueDefinition(Entity entity);

		/// <summary>
		/// Retrieves a collection of full lookup definitions for the specified lookup schema identifiers.
		/// </summary>
		/// <param name="ids">The unique identifiers of the lookup schemas.</param>
		/// <returns>A list of <see cref="LookupDefinition"/> objects.</returns>
		List<LookupDefinition> GetLookupDefinitions(IEnumerable<Guid> ids = null);

		/// <summary>
		/// Retrieves summary information for all available lookup schemas.
		/// </summary>
		/// <returns>A list of <see cref="LookupSummary"/> objects.</returns>
		List<LookupSummary> GetLookupSummaries();

		/// <summary>
		/// Retrieves summary information for all lookup values across all lookup schemas.
		/// </summary>
		/// <returns>A list of <see cref="LookupValueSummary"/> objects.</returns>
		List<LookupValueSummary> GetLookupValueSummaries();

		/// <summary>
		/// Retrieves all lookup definitions that include the specified lookup value entity.
		/// </summary>
		/// <param name="lookupValue">The entity representing the lookup value.</param>
		/// <returns>A list of <see cref="LookupDefinition"/> objects that reference the given value.</returns>
		List<LookupDefinition> GetLookupDefinitionsForValue(Entity lookupValue);

		/// <summary>
		/// Retrieves lookup value definitions for the specified collection of lookup entity identifiers.
		/// </summary>
		/// <param name="lookupsIds">The unique identifiers of the lookup entiteis.</param>
		/// <returns>A list of <see cref="LookupValueDefinition"/> objects associated with the provided lookups.</returns>
		List<LookupValueDefinition> GetLookupValueDefinitionsForLookups(IEnumerable<Guid> lookupsIds);

		//// <summary>
		/// Retrieves all lookup value definitions associated with the given entity,
		/// whether it's a lookup schema or a lookup value.
		/// </summary>
		/// <param name="entity">The lookup schema or lookup value entity.</param>
		/// <returns>A list of <see cref="LookupValueDefinition"/> objects associated with the entity.</returns>
		List<LookupValueDefinition> GetLookupValueDefinitions(Entity entity);

	}

	#endregion

	#region Class: LookupHandler

	/// <summary>
	/// Resolves lookup metadata and value definitions.
	/// </summary>
	[DefaultBinding(typeof(ILookupHandler))]
	internal class LookupHandler : ILookupHandler
	{

		#region Constants: Private

		private const string LookupSchemaName = "Lookup";
		private const string BaseLookupSchemaName = "BaseLookup";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("DataForge");
		private readonly UserConnection _userConnection;
		private readonly IChecksumProvider _checksumProvider;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates a new instance of <see cref="LookupHandler"/>.
		/// </summary>
		public LookupHandler(UserConnection userConnection, IChecksumProvider checksumProvider) {
			_userConnection = userConnection;
			_checksumProvider = checksumProvider;
		}

		#endregion

		#region Methods: Private

		private EntityCollection QueryEntities(string schemaName, Action<EntitySchemaQuery> configure = null) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, schemaName);
			esq.AddAllSchemaColumns();
			configure?.Invoke(esq);
			return esq.GetEntityCollection(_userConnection);
		}

		private EntitySchema GetAssociatedSchema(Entity lookupEntity) {
			var schemaUId = lookupEntity.GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			EntitySchema schema = _userConnection.EntitySchemaManager.FindInstanceByUId(schemaUId);
			if (schema == null) {
				_log.Warn($"Associated schema not found for UId: {schemaUId}");
			}
			return schema;
		}

		private string GetDescription(string name, string description) {
			if (string.IsNullOrWhiteSpace(description)) {
				return null;
			}
			string trimmed = description.Trim();
			return string.Equals(name, trimmed, StringComparison.InvariantCultureIgnoreCase)
				? null
				: trimmed;
		}

		private (Guid Id, string Name, string Description, string ModifiedOn, string Checksum) ExtractData(
				Entity entity) {
			string name;
			var id = entity.GetTypedColumnValue<Guid>("Id");
			try {
				name = entity.GetTypedColumnValue<string>("Name");
			} catch (ItemNotFoundException) {
				EntitySchemaColumn schemaPrimaryDisplayColumn = entity.Schema.PrimaryDisplayColumn;
				name = schemaPrimaryDisplayColumn != null && entity.GetIsColumnValueLoaded(schemaPrimaryDisplayColumn)
					? entity.PrimaryDisplayColumnValue
					: null;
			}
			string description;
			try {
				description = GetDescription(name, entity.GetTypedColumnValue<string>("Description"));
			} catch (ItemNotFoundException) {
				description = string.Empty;
			}
			var modifiedOn = entity.GetTypedColumnValue<DateTime>("ModifiedOn").ToString("o");
			string checksum = _checksumProvider.GetChecksum(name, description ?? string.Empty);
			return (id, name, description, modifiedOn, checksum);
		}

		private (Guid Id, Guid SchemaUId, string ModifiedOn, string Checksum) ExtractSummary(Entity entity) {
			var id = entity.GetTypedColumnValue<Guid>("Id");
			var schemaUId = entity.Schema.UId;
			var name = entity.GetTypedColumnValue<string>("Name");
			var description = GetDescription(name, entity.GetTypedColumnValue<string>("Description"));
			var modifiedOn = entity.GetTypedColumnValue<DateTime>("ModifiedOn").ToString("o");
			var checksum = _checksumProvider.GetChecksum(name, description ?? string.Empty);
			return (id, schemaUId, modifiedOn, checksum);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public bool IsLookup(Entity entity) =>
			entity.Schema.Name == LookupSchemaName;

		/// <inheritdoc/>
		public bool IsLookupValue(Entity entity) =>
			entity.Schema.ParentSchema.Name == BaseLookupSchemaName;

		/// <inheritdoc/>
		public LookupDefinition GetLookupDefinition(Entity entity) {
			var (id, name, desc, mod, chk) = ExtractData(entity);
			if (name == null) {
				return null;
			}
			var definition = new LookupDefinition {
				Id = id,
				Name = name,
				Description = desc,
				ModifiedOn = mod,
				Checksum = chk
			};
			EntitySchema associated = GetAssociatedSchema(entity);
			if (associated != null) {
				definition.ValuesSchemaName = associated.Name;
				definition.ValuesSchemaUId = associated.UId;
			}
			return definition;
		}

		/// <inheritdoc/>
		public LookupValueDefinition GetLookupValueDefinition(Entity entity) {
			var (id, name, desc, mod, chk) = ExtractData(entity);
			if (name == null) {
				return null;
			}
			return new LookupValueDefinition {
				Id = id,
				Name = name,
				Description = desc,
				ModifiedOn = mod,
				Checksum = chk,
				SchemaUId = entity.Schema.UId
			};
		}

		/// <inheritdoc/>
		public List<LookupDefinition> GetLookupDefinitions(IEnumerable<Guid> ids = null) {
			return QueryEntities(LookupSchemaName, esq => {
				if (ids != null && ids.Any()) {
					esq.Filters.Add(esq.CreateFilterWithParameters(
						FilterComparisonType.Equal,
						"Id",
						ids.Select(i => i.ToString()).ToList()
					));
				}
			})
			.Select(e => GetLookupDefinition(e))
			.Where(d => d != null)
			.ToList();
		}

		public List<LookupDefinition> GetLookupDefinitionsForValue(Entity lookupValue) {
			EntitySchema lookupValueSchema = lookupValue.Schema;
			EntityCollection entities = QueryEntities(LookupSchemaName, esq => {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysEntitySchemaUId",
					lookupValueSchema.UId));
			});
			return entities.Select(e => {
				var (id, name, desc, mod, chk) = ExtractData(e);
				if (name == null) {
					return null;
				}
				var definition = new LookupDefinition {
					Id = id,
					Name = name,
					Description = desc,
					ModifiedOn = mod,
					Checksum = chk
				};
				EntitySchema associated = GetAssociatedSchema(e);
				if (associated != null) {
					definition.ValuesSchemaName = associated.Name;
					definition.ValuesSchemaUId = associated.UId;
				}
				return definition;
			}).Where(d => d != null).ToList();
		}

		/// <inheritdoc/>
		public List<LookupSummary> GetLookupSummaries() {
			EntitySchema lookupSchema = _userConnection.EntitySchemaManager.FindInstanceByName(LookupSchemaName);
			if (lookupSchema == null) {
				return new List<LookupSummary>();
			}
			return QueryEntities(LookupSchemaName)
				.Select(entity => {
					var (id, schemaUId, modifiedOn, checksum) = ExtractSummary(entity);
					return new LookupSummary {
						Id = id,
						SchemaUId = schemaUId,
						ModifiedOn = modifiedOn,
						Checksum = checksum
					};
				})
				.ToList();
		}

		/// <inheritdoc/>
		public List<LookupValueSummary> GetLookupValueSummaries() {
			var summaries = new List<LookupValueSummary>();

			EntitySchema lookupSchema = _userConnection.EntitySchemaManager.FindInstanceByName(LookupSchemaName);
			if (lookupSchema == null) {
				_log.Warn($"Schema '{LookupSchemaName}' not found.");
				return summaries;
			}

			foreach (Entity schemaEntity in QueryEntities(LookupSchemaName)) {
				EntitySchema assoc = GetAssociatedSchema(schemaEntity);
				if (string.IsNullOrWhiteSpace(assoc?.Name)) continue;

				foreach (Entity entity in QueryEntities(assoc.Name)) {
					try {
						var (id, schemaUId, modifiedOn, checksum) = ExtractSummary(entity);
						var summary = new LookupValueSummary {
							Id = id,
							SchemaUId = schemaUId,
							ModifiedOn = modifiedOn,
							Checksum = checksum
						};
						summaries.Add(summary);
					} catch (Exception ex) {
						_log.Error("ExtractSummary failed", ex);
					}
				}
			}
			return summaries;
		}

		/// <inheritdoc/>
		public List<LookupValueDefinition> GetLookupValueDefinitionsForLookups(IEnumerable<Guid> lookupsIds) {
			var lookupValueDefinitions = new List<LookupValueDefinition>();
			var processedSchemas = new HashSet<Guid>();

			EntityCollection lookups = QueryEntities(LookupSchemaName, esq =>
				esq.Filters.Add(
					esq.CreateFilterWithParameters(
						FilterComparisonType.Equal, "Id", lookupsIds.Select(i => i.ToString()).ToList()
						)
					)
			);

			foreach (Entity entity in lookups) {
				var associated = GetAssociatedSchema(entity);
				if (associated == null || processedSchemas.Contains(associated.Id)) continue;

				List<LookupValueDefinition> lookupDefinition = QueryEntities(associated.Name)
					.Select(es => GetLookupValueDefinition(es))
					.Where(d => d != null && !string.IsNullOrWhiteSpace(d.Name))
					.ToList();

				lookupValueDefinitions.AddRange(lookupDefinition);
				processedSchemas.Add(associated.Id);
			}

			return lookupValueDefinitions;
		}

		/// <inheritdoc/>
		public List<LookupValueDefinition> GetLookupValueDefinitions(Entity entity) {
			string schemaName = null;

			if (IsLookupValue(entity)) {
				schemaName = entity.Schema?.Name;
			} else if (IsLookup(entity)) {
				EntitySchema associated = GetAssociatedSchema(entity);
				if (associated != null) {
					schemaName = associated.Name;
				}
			}

			if (string.IsNullOrEmpty(schemaName)) {
				return new List<LookupValueDefinition>();
			}

			if (_userConnection.EntitySchemaManager.FindInstanceByName(schemaName) == null) {
				return new List<LookupValueDefinition>();
			}

			return QueryEntities(schemaName)
				.Select(e => GetLookupValueDefinition(e))
				.Where(d => d != null)
				.ToList();
		}

		#endregion

	}

	#endregion

}

