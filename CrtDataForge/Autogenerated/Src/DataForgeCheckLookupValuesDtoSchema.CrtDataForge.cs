namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DataForgeCheckLookupValuesDtoSchema

	/// <exclude/>
	public class DataForgeCheckLookupValuesDtoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DataForgeCheckLookupValuesDtoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DataForgeCheckLookupValuesDtoSchema(DataForgeCheckLookupValuesDtoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3f116160-cd02-476c-9cbf-c10398628378");
			Name = "DataForgeCheckLookupValuesDto";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("08c4faf5-b0b9-4f2f-8882-6a2d4b4ee8d8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,146,77,79,194,64,16,134,207,144,240,31,38,112,209,196,148,187,168,23,140,132,68,148,128,122,49,30,150,238,180,108,232,238,214,253,48,65,226,127,119,118,75,9,104,15,130,167,102,222,153,157,121,159,233,40,38,209,150,44,69,120,66,99,152,213,153,75,134,90,101,34,247,134,57,161,85,114,203,28,187,211,38,199,78,123,211,105,183,188,21,42,135,249,218,58,148,131,31,113,50,243,202,9,137,201,28,141,96,133,248,140,29,168,138,234,122,6,115,10,96,88,48,107,47,225,94,235,149,47,95,88,225,113,238,165,100,102,29,171,250,253,62,92,217,74,184,217,198,51,44,13,90,84,206,194,54,3,66,101,218,200,216,29,216,66,123,7,12,108,137,169,200,68,10,69,108,13,31,161,247,5,149,166,133,231,193,99,20,128,41,14,82,243,80,89,189,151,232,24,39,198,164,30,223,223,155,255,26,232,105,31,206,176,212,189,5,97,135,182,40,48,8,165,95,20,52,52,13,88,141,84,173,176,181,29,254,212,232,18,141,19,72,59,152,198,167,145,251,23,120,20,70,72,204,218,128,13,95,183,68,240,74,188,19,131,224,180,13,34,64,3,58,139,137,125,230,100,215,111,159,164,66,153,160,92,160,57,123,160,191,14,215,208,21,188,123,30,32,106,138,145,23,28,198,28,54,144,163,27,132,185,3,248,58,198,160,77,151,40,217,223,124,110,139,143,176,91,61,120,30,55,185,158,215,185,211,205,83,135,116,69,85,77,102,255,110,178,238,114,232,209,58,19,110,112,88,143,56,217,36,221,153,59,60,96,58,94,252,159,229,170,29,242,71,213,104,122,178,75,55,217,238,161,226,213,113,83,84,105,251,18,41,223,76,104,200,197,100,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3f116160-cd02-476c-9cbf-c10398628378"));
		}

		#endregion

	}

	#endregion

}

