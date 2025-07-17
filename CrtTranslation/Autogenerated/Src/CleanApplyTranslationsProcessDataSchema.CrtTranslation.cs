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

	#region Class: CleanApplyTranslationsProcessData

	[DesignModeProperty(Name = "ApplySessionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "df452e33a15c47498d60ff97d746fb94", CaptionResourceItem = "Parameters.ApplySessionId.Caption", DescriptionResourceItem = "Parameters.ApplySessionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class CleanApplyTranslationsProcessData : ProcessUserTask
	{

		#region Constructors: Public

		public CleanApplyTranslationsProcessData(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("df452e33-a15c-4749-8d60-ff97d746fb94");
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

