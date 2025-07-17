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

	#region Class: CleanApplyTranslationSessions

	[DesignModeProperty(Name = "ClearRunning", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "daf1092463d147a09b096477a95f6654", CaptionResourceItem = "Parameters.ClearRunning.Caption", DescriptionResourceItem = "Parameters.ClearRunning.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class CleanApplyTranslationSessions : ProcessUserTask
	{

		#region Constructors: Public

		public CleanApplyTranslationSessions(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("daf10924-63d1-47a0-9b09-6477a95f6654");
		}

		#endregion

		#region Properties: Public

		public virtual bool ClearRunning {
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
			if (!HasMapping("ClearRunning")) {
				writer.WriteValue("ClearRunning", ClearRunning, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ClearRunning":
					ClearRunning = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

