namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UsePersistentApplyTranslationSchema

	/// <exclude/>
	public class UsePersistentApplyTranslationSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UsePersistentApplyTranslationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UsePersistentApplyTranslationSchema(UsePersistentApplyTranslationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("12b74447-5bd0-486a-8dbe-684d36ac2a43");
			Name = "UsePersistentApplyTranslation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,143,65,106,195,48,16,69,215,54,248,14,67,186,105,55,62,64,66,22,197,109,161,139,66,22,238,1,38,242,88,21,40,35,49,35,183,148,208,187,87,150,2,33,155,172,52,250,252,121,255,15,48,158,72,35,26,130,145,68,80,195,156,250,33,240,236,236,34,152,92,224,126,20,100,245,101,238,218,115,215,54,139,58,182,48,8,173,90,255,150,159,69,104,12,214,250,172,239,186,54,91,30,132,108,246,195,224,81,117,11,159,74,7,18,117,154,136,211,115,140,254,247,6,154,23,28,39,18,70,15,102,221,184,191,0,91,184,132,126,80,194,9,19,102,192,185,96,174,193,129,53,201,98,82,144,156,127,88,142,222,153,234,136,101,190,159,240,248,4,235,161,77,243,174,175,140,71,79,19,236,33,227,104,87,212,23,82,35,46,150,46,123,216,84,139,194,140,206,135,111,18,192,21,151,253,215,198,63,46,125,65,172,121,200,134,250,77,33,253,93,74,19,79,181,119,249,87,245,86,204,218,63,79,46,110,174,171,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("12b74447-5bd0-486a-8dbe-684d36ac2a43"));
		}

		#endregion

	}

	#endregion

}

