namespace Terrasoft.Core.Process.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;

	#region Class: DataForgeGetTableRelationships

	[DesignModeProperty(Name = "SourceTable", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "64eb83bcdb5545de83f3747fcd5eb223", CaptionResourceItem = "Parameters.SourceTable.Caption", DescriptionResourceItem = "Parameters.SourceTable.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "TargetTable", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "64eb83bcdb5545de83f3747fcd5eb223", CaptionResourceItem = "Parameters.TargetTable.Caption", DescriptionResourceItem = "Parameters.TargetTable.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Output", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "64eb83bcdb5545de83f3747fcd5eb223", CaptionResourceItem = "Parameters.Output.Caption", DescriptionResourceItem = "Parameters.Output.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class DataForgeGetTableRelationships : ProcessUserTask
	{

		#region Constructors: Public

		public DataForgeGetTableRelationships(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("64eb83bc-db55-45de-83f3-747fcd5eb223");
		}

		#endregion

		#region Properties: Public

		public virtual string SourceTable {
			get;
			set;
		}

		public virtual string TargetTable {
			get;
			set;
		}

		public virtual string Output {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("SourceTable")) {
					writer.WriteValue("SourceTable", SourceTable, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("TargetTable")) {
					writer.WriteValue("TargetTable", TargetTable, null);
				}
			}
			if (UseFlowEngineMode) {
				if (!HasMapping("Output")) {
					writer.WriteValue("Output", Output, null);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "SourceTable":
					if (!UseFlowEngineMode) {
						break;
					}
					SourceTable = reader.GetStringValue();
				break;
				case "TargetTable":
					if (!UseFlowEngineMode) {
						break;
					}
					TargetTable = reader.GetStringValue();
				break;
				case "Output":
					if (!UseFlowEngineMode) {
						break;
					}
					Output = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

