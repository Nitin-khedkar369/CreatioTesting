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

	#region Class: SetForceUpdateUserTask

	[DesignModeProperty(Name = "UseSpecifiedLanguageOnly", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c092557656e648c3a78497e3364fe20b", CaptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", DescriptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "LanguageId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c092557656e648c3a78497e3364fe20b", CaptionResourceItem = "Parameters.LanguageId.Caption", DescriptionResourceItem = "Parameters.LanguageId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsForceUpdate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c092557656e648c3a78497e3364fe20b", CaptionResourceItem = "Parameters.IsForceUpdate.Caption", DescriptionResourceItem = "Parameters.IsForceUpdate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ApplySessionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c092557656e648c3a78497e3364fe20b", CaptionResourceItem = "Parameters.ApplySessionId.Caption", DescriptionResourceItem = "Parameters.ApplySessionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class SetForceUpdateUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public SetForceUpdateUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("c0925576-56e6-48c3-a784-97e3364fe20b");
		}

		#endregion

		#region Properties: Public

		public virtual bool UseSpecifiedLanguageOnly {
			get;
			set;
		}

		public virtual Guid LanguageId {
			get;
			set;
		}

		public virtual bool IsForceUpdate {
			get;
			set;
		}

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
			if (!HasMapping("UseSpecifiedLanguageOnly")) {
				writer.WriteValue("UseSpecifiedLanguageOnly", UseSpecifiedLanguageOnly, false);
			}
			if (!HasMapping("LanguageId")) {
				writer.WriteValue("LanguageId", LanguageId, Guid.Empty);
			}
			if (!HasMapping("IsForceUpdate")) {
				writer.WriteValue("IsForceUpdate", IsForceUpdate, false);
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
				case "UseSpecifiedLanguageOnly":
					UseSpecifiedLanguageOnly = reader.GetBoolValue();
				break;
				case "LanguageId":
					LanguageId = reader.GetGuidValue();
				break;
				case "IsForceUpdate":
					IsForceUpdate = reader.GetBoolValue();
				break;
				case "ApplySessionId":
					ApplySessionId = reader.GetGuidValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

