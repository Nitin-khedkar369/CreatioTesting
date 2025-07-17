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

	#region Class: CorrectInvalidChangedTranslationStatus

	[DesignModeProperty(Name = "LanguageId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9fca842100e94afc9c14d41e8c69fa71", CaptionResourceItem = "Parameters.LanguageId.Caption", DescriptionResourceItem = "Parameters.LanguageId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "UseSpecifiedLanguageOnly", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9fca842100e94afc9c14d41e8c69fa71", CaptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", DescriptionResourceItem = "Parameters.UseSpecifiedLanguageOnly.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ApplySessionId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "9fca842100e94afc9c14d41e8c69fa71", CaptionResourceItem = "Parameters.ApplySessionId.Caption", DescriptionResourceItem = "Parameters.ApplySessionId.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class CorrectInvalidChangedTranslationStatus : ProcessUserTask
	{

		#region Constructors: Public

		public CorrectInvalidChangedTranslationStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("9fca8421-00e9-4afc-9c14-d41e8c69fa71");
		}

		#endregion

		#region Properties: Public

		public virtual Guid LanguageId {
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

