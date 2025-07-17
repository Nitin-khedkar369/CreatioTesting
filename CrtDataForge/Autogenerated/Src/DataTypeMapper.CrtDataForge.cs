namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IDataTypeMapper

	/// <summary>
	/// Provides functionality to map entity schema column data types to corresponding SQL types or original type names.
	/// </summary>
	public interface IDataTypeMapper
	{
		/// <summary>
		/// Maps an entity schema column's data type to either its original type name or a corresponding SQL type.
		/// </summary>
		/// <param name="column">The entity schema column to map the data type for.</param>
		/// <param name="tryMapSqlTypes">Indicates whether to attempt mapping to SQL data types.</param>
		/// <returns>The mapped data type as a string, either the SQL type or original type name.</returns>
		string MapDataType(EntitySchemaColumn column, bool tryMapSqlTypes);
	}

	#endregion

	#region Class: DataTypeMapper

	[DefaultBinding(typeof(IDataTypeMapper))]
	internal class DataTypeMapper : IDataTypeMapper
	{
		#region Fields: Private

		private readonly IDictionary<string, string> _sqlTypeMapping = new Dictionary<string, string> {
			{"RichText", "nvarchar"},
			{"ShortText", "nvarchar"},
			{"File", "varbinary"},
			{"WebText", "nvarchar"},
			//{"Lookup", "Lookup"},
			{"Time", "time"},
			{"PhoneText", "string"},
			{"ImageLookup", "uniqueidentifier"},
			{"Integer", "int"},
			{"Float1", "decimal"},
			{"DateTime", "datetime2"},
			{"Date", "date"},
			{"Float8", "decimal"},
			{"Image", "varbinary"},
			{"MaxSizeText", "nvarchar"},
			{"Binary", "varbinary"},
			{"Text", "nvarchar"},
			{"Float3", "decimal"},
			//{"Guid", "uniqueidentifier"},
			//{"ValueList", "ValueList"},
			{"Boolean", "bit"},
			{"Float2", "decimal"},
			{"Money", "decimal"},
			{"Float4", "decimal"},
			{"MediumText", "nvarchar"},
			{"HashText", "nvarchar"},
			{"Color", "nvarchar"},
			{"LongText", "nvarchar"},
			{"SecureText", "nvarchar"}
		};

		#endregion

		#region Methods: Public

		/// <summary>
		/// Maps an entity schema column's data type to either its original type name or a corresponding SQL type.
		/// </summary>
		/// <param name="column">The entity schema column to map the data type for.</param>
		/// <param name="tryMapSqlTypes">Indicates whether to attempt mapping to SQL data types.</param>
		/// <returns>The mapped data type as a string, either the SQL type or original type name.</returns>
		public string MapDataType(EntitySchemaColumn column, bool tryMapSqlTypes) {
			if (column == null) {
				throw new ArgumentNullException(nameof(column));
			}
			if (column.DataValueType == null) {
				throw new ArgumentException("Column DataValueType must not be null.", nameof(column));
			}

			string originalTypeName = column.DataValueType.Name;
			return tryMapSqlTypes && _sqlTypeMapping.TryGetValue(originalTypeName, out string mappedType)
				? mappedType
				: originalTypeName;
		}

		#endregion
	}

	#endregion
}
