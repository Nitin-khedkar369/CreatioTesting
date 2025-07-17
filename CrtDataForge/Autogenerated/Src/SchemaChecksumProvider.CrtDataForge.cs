namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	#region Interface: ISchemaChecksumProvider

	/// <summary>
	/// Provides functionality to retrieve checksums for entity schemas.
	/// </summary>
	public interface ISchemaChecksumProvider
	{
		/// <summary>
		/// Retrieves checksums for all schemas managed by EntitySchemaManager.
		/// </summary>
		/// <returns>
		/// A dictionary where the key is the schema name and the value is the MD5 hash of the schema's checksum.
		/// </returns>
		Dictionary<string, string> GetChecksums();

		/// <summary>
		/// Retrieves the checksum for a single schema by its name.
		/// </summary>
		/// <param name="schemaName">The name of the schema to retrieve the checksum for.</param>
		/// <returns>
		/// The MD5 hash of the schema's checksum, or <c>null</c> if not found.
		/// </returns>
		string GetChecksum(string schemaName);
	}

	#endregion

	#region Class: SchemaChecksumProvider

	/// <summary>
	/// Default implementation of <see cref="ISchemaChecksumProvider"/> that retrieves checksums from the SysSchema table.
	/// </summary>
	[DefaultBinding(typeof(ISchemaChecksumProvider))]
	internal class SchemaChecksumProvider : ISchemaChecksumProvider
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("DataForge");
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="SchemaChecksumProvider"/> class with the specified user connection.
		/// </summary>
		/// <param name="userConnection">The user connection context for database operations.</param>
		public SchemaChecksumProvider(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Retrieves checksums for all schemas managed by EntitySchemaManager.
		/// Processes each schema's checksum and returns the result as an MD5 hash.
		/// </summary>
		/// <returns>
		/// A dictionary mapping schema names to their computed MD5 hash checksums.
		/// </returns>
		public Dictionary<string, string> GetChecksums() {
			var schemas = new Dictionary<string, string>();
			Select select = new Select(_userConnection);
			select.From("SysSchema")
				.Column("Name")
				.Column("Checksum")
				.Where("ManagerName").IsEqual(Column.Parameter("EntitySchemaManager"))
				.OrderByAsc("UId");

			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						try {
							var name = reader.GetColumnValue<string>("Name");
							var checksum = reader.GetColumnValue<string>("Checksum");

							if (schemas.TryGetValue(name, out var existing)) {
								schemas[name] = existing + checksum;
							} else {
								schemas[name] = checksum;
							}
						} catch (Exception ex) {
							_log.Error("Error processing schema row", ex);
						}
					}
				}
			}

			return schemas.ToDictionary(
				s => s.Key,
				s => FileUtilities.GetMD5HashFromString(s.Value)
			);
		}

		/// <summary>
		/// Retrieves the checksum for a specific schema by its name.
		/// Returns the result as an MD5 hash.
		/// </summary>
		/// <param name="schemaName">The name of the schema for which to retrieve the checksum.</param>
		/// <returns>
		/// The computed MD5 hash of the schema's checksum, or <c>null</c> if not found.
		/// </returns>
		public string GetChecksum(string schemaName) {
			try {
				Select select = new Select(_userConnection);
				select
					.Top(1)
					.Column("Checksum")
					.From("SysSchema")
					.Where("ManagerName").IsEqual(Column.Parameter("EntitySchemaManager"))
					.And("Name").IsEqual(Column.Parameter(schemaName));

				var rawChecksum = select.ExecuteScalar<string>();
				return rawChecksum != null
					? FileUtilities.GetMD5HashFromString(rawChecksum)
					: null;
			} catch (Exception ex) {
				_log.Error($"Error retrieving checksum for schema: {schemaName}", ex);
				return null;
			}
		}

		#endregion
	}

	#endregion
}

