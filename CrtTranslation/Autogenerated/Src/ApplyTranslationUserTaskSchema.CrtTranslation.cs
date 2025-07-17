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

	#region Class: ApplyTranslationUserTask

	[DesignModeProperty(Name = "LanguageId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c4599dfdb6cb455eb245b033b4b50ab3", CaptionResourceItem = "Parameters.LanguageId.Caption", DescriptionResourceItem = "Parameters.LanguageId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "IsForceUpdate", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c4599dfdb6cb455eb245b033b4b50ab3", CaptionResourceItem = "Parameters.IsForceUpdate.Caption", DescriptionResourceItem = "Parameters.IsForceUpdate.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseSpecifiedLanguageOnly", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c4599dfdb6cb455eb245b033b4b50ab3", CaptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", DescriptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ApplySessionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "c4599dfdb6cb455eb245b033b4b50ab3", CaptionResourceItem = "Parameters.ApplySessionId.Caption", DescriptionResourceItem = "Parameters.ApplySessionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ApplyTranslationUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ApplyTranslationUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("c4599dfd-b6cb-455e-b245-b033b4b50ab3");
		}

		#endregion

		#region Properties: Public

		public virtual Guid LanguageId {
			get;
			set;
		}

		public virtual bool IsForceUpdate {
			get;
			set;
		}

		public virtual bool UseSpecifiedLanguageOnly {
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
			if (!HasMapping("LanguageId")) {
				writer.WriteValue("LanguageId", LanguageId, Guid.Empty);
			}
			if (!HasMapping("IsForceUpdate")) {
				writer.WriteValue("IsForceUpdate", IsForceUpdate, false);
			}
			if (!HasMapping("UseSpecifiedLanguageOnly")) {
				writer.WriteValue("UseSpecifiedLanguageOnly", UseSpecifiedLanguageOnly, false);
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
				case "LanguageId":
					LanguageId = reader.GetGuidValue();
				break;
				case "IsForceUpdate":
					IsForceUpdate = reader.GetBoolValue();
				break;
				case "UseSpecifiedLanguageOnly":
					UseSpecifiedLanguageOnly = reader.GetBoolValue();
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

