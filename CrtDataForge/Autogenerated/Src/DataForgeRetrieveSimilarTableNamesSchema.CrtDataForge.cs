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

	#region Class: DataForgeRetrieveSimilarTableNames

	[DesignModeProperty(Name = "Input", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "44ff6d00df244b0c90ba632dd3ff105e", CaptionResourceItem = "Parameters.Input.Caption", DescriptionResourceItem = "Parameters.Input.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Output", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "44ff6d00df244b0c90ba632dd3ff105e", CaptionResourceItem = "Parameters.Output.Caption", DescriptionResourceItem = "Parameters.Output.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class DataForgeRetrieveSimilarTableNames : ProcessUserTask
	{

		#region Constructors: Public

		public DataForgeRetrieveSimilarTableNames(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("44ff6d00-df24-4b0c-90ba-632dd3ff105e");
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
			if (!HasMapping("Input")) {
				writer.WriteValue("Input", Input, null);
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

