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

	#region Class: VerifyTranslationsUserTask

	[DesignModeProperty(Name = "IgnoreStaticContent", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0bd13bdc9de941fcb2166d9676faacc8", CaptionResourceItem = "Parameters.IgnoreStaticContent.Caption", DescriptionResourceItem = "Parameters.IgnoreStaticContent.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseSpecifiedLanguageOnly", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0bd13bdc9de941fcb2166d9676faacc8", CaptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", DescriptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "LanguageId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0bd13bdc9de941fcb2166d9676faacc8", CaptionResourceItem = "Parameters.LanguageId.Caption", DescriptionResourceItem = "Parameters.LanguageId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ApplySessionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0bd13bdc9de941fcb2166d9676faacc8", CaptionResourceItem = "Parameters.ApplySessionId.Caption", DescriptionResourceItem = "Parameters.ApplySessionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class VerifyTranslationsUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public VerifyTranslationsUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("0bd13bdc-9de9-41fc-b216-6d9676faacc8");
		}

		#endregion

		#region Properties: Public

		public virtual bool IgnoreStaticContent {
			get;
			set;
		}

		public virtual bool UseSpecifiedLanguageOnly {
			get;
			set;
		}

		public virtual Guid LanguageId {
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
			if (!HasMapping("IgnoreStaticContent")) {
				writer.WriteValue("IgnoreStaticContent", IgnoreStaticContent, false);
			}
			if (!HasMapping("UseSpecifiedLanguageOnly")) {
				writer.WriteValue("UseSpecifiedLanguageOnly", UseSpecifiedLanguageOnly, false);
			}
			if (!HasMapping("LanguageId")) {
				writer.WriteValue("LanguageId", LanguageId, Guid.Empty);
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
				case "IgnoreStaticContent":
					IgnoreStaticContent = reader.GetBoolValue();
				break;
				case "UseSpecifiedLanguageOnly":
					UseSpecifiedLanguageOnly = reader.GetBoolValue();
				break;
				case "LanguageId":
					LanguageId = reader.GetGuidValue();
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

