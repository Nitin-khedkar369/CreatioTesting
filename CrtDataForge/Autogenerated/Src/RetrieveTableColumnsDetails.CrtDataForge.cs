namespace Terrasoft.Core.Process
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: RetrieveTableColumnsDetailsMethodsWrapper

	/// <exclude/>
	public class RetrieveTableColumnsDetailsMethodsWrapper : ProcessModel
	{

		public RetrieveTableColumnsDetailsMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("RetrieveColumnsDetailsExecute", RetrieveColumnsDetailsExecute);
		}

		#region Methods: Private

		private bool RetrieveColumnsDetailsExecute(ProcessExecutingContext context) {
			var tableName = Get<string>("TableName");
			
			var userConnection = context.UserConnection;
			
			var entitySchema = userConnection.EntitySchemaManager.GetInstanceByName(tableName);
			
			var compositeColumnsObjects = BuildColumnsList(entitySchema);
			
			Set("Output", compositeColumnsObjects);
			return true;
		}

			private CompositeObjectList<CompositeObject> BuildColumnsList(EntitySchema instance)
			{
			    var columnsList = new CompositeObjectList<CompositeObject>();
			
			    foreach (var column in instance.Columns)
			    {
			        var columnObject = new CompositeObject
			        {
			            { "ColumnName", column.ColumnValueName },
			        };
			
			        if (IsMeaningful(column.Caption, column.ColumnValueName))
			        {
			            columnObject.Add("ColumnCaption", column.Caption.ToString());
			        }
			
			        if (!string.IsNullOrWhiteSpace(column.Description) &&
			            !string.Equals(column.ColumnValueName, column.Description.ToString().Replace(" ", string.Empty),
			                StringComparison.InvariantCultureIgnoreCase))
			        {
			            columnObject.Add("ColumnDescription", column.Description.ToString());
			        }
			
			        columnObject.Add("ColumnType", column.DataValueType.Name);
			
			        if (column.ReferenceSchema != null && !string.IsNullOrWhiteSpace(column.ReferenceSchema.Name))
			        {
			            columnObject.Add("ColumnRefersToTable", column.ReferenceSchema.Name);
			        }
			
			        columnsList.Add(columnObject);
			    }
			    
			    return columnsList;
			}
			
			
			private bool IsMeaningful(object propertyValue, string reference)
			{
			    if (propertyValue == null)
			    {
			        return false;
			    }
			
			    string valueStr = propertyValue.ToString();
			    if (string.IsNullOrWhiteSpace(valueStr))
			    {
			        return false;
			    }
			
			    return !string.Equals(valueStr, reference, StringComparison.InvariantCultureIgnoreCase) &&
			           !string.Equals(reference, valueStr.Replace(" ", string.Empty), StringComparison.InvariantCultureIgnoreCase);
			}

		#endregion

	}

	#endregion

}

