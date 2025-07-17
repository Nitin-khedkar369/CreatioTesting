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

	#region Class: DataForgeGetLookupValues

	[DesignModeProperty(Name = "Input", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7f1e57b085ec47248d0abce45734550f", CaptionResourceItem = "Parameters.Input.Caption", DescriptionResourceItem = "Parameters.Input.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Output", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "7f1e57b085ec47248d0abce45734550f", CaptionResourceItem = "Parameters.Output.Caption", DescriptionResourceItem = "Parameters.Output.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class DataForgeGetLookupValues : ProcessUserTask
	{

		#region Constructors: Public

		public DataForgeGetLookupValues(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("7f1e57b0-85ec-4724-8d0a-bce45734550f");
		}

		#endregion

		#region Properties: Public

		public virtual string Input {
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
				if (!HasMapping("Input")) {
					writer.WriteValue("Input", Input, null);
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
				case "Input":
					if (!UseFlowEngineMode) {
						break;
					}
					Input = reader.GetStringValue();
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

