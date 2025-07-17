namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ApplyTranslationsStagesEnumSchema

	/// <exclude/>
	public class ApplyTranslationsStagesEnumSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ApplyTranslationsStagesEnumSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ApplyTranslationsStagesEnumSchema(ApplyTranslationsStagesEnumSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4af9b4d-936f-43e4-a7c4-6acbb3350321");
			Name = "ApplyTranslationsStagesEnum";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,144,79,75,4,49,12,197,207,51,48,223,161,224,85,22,255,11,130,7,89,86,217,131,32,235,234,189,182,111,134,64,39,29,210,142,160,226,119,55,237,120,144,245,150,228,247,146,188,132,237,136,52,89,7,179,135,136,77,177,207,171,117,228,158,134,89,108,166,200,171,189,88,78,161,198,93,251,213,181,93,219,28,9,6,77,205,134,231,241,198,236,224,162,248,141,167,252,24,61,170,96,154,223,2,57,3,229,230,110,154,194,199,159,33,233,57,219,1,169,244,170,82,7,54,205,150,41,147,13,244,73,60,152,91,115,122,92,138,235,0,203,47,60,39,248,29,122,8,216,33,41,61,171,244,73,162,166,233,62,138,67,221,160,228,188,146,127,251,148,92,84,242,0,134,30,5,53,144,201,233,149,25,156,149,94,86,250,10,161,254,176,241,106,177,18,69,224,242,150,223,213,164,63,144,92,255,74,198,41,32,195,23,135,39,165,244,189,188,10,236,151,111,149,84,107,63,54,30,114,48,113,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4af9b4d-936f-43e4-a7c4-6acbb3350321"));
		}

		#endregion

	}

	#endregion

}

