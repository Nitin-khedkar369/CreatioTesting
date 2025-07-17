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

	#region Class: ClearUnusedReferencesUserTask

	[DesignModeProperty(Name = "ApplySessionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "a352ed6b63ae41648f7508da6cff70e5", CaptionResourceItem = "Parameters.ApplySessionId.Caption", DescriptionResourceItem = "Parameters.ApplySessionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ClearUnusedReferencesUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ClearUnusedReferencesUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("a352ed6b-63ae-4164-8f75-08da6cff70e5");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ApplySessionId {
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
			if (!HasMapping("ApplySessionId")) {
				writer.WriteValue("ApplySessionId", ApplySessionId, Guid.Empty);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ApplySessionId":
					ApplySessionId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

