namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: IApplyTranslationsParametersRepositorySchema

	/// <exclude/>
	public class IApplyTranslationsParametersRepositorySchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IApplyTranslationsParametersRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IApplyTranslationsParametersRepositorySchema(IApplyTranslationsParametersRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0e3a0a56-963d-49ec-bc63-26b00fcf3abf");
			Name = "IApplyTranslationsParametersRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2f244451-ec5e-494f-9790-8d930a80007c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,85,193,106,220,48,16,61,39,144,127,24,210,75,10,197,190,183,238,194,146,132,197,183,208,77,233,89,177,198,174,168,44,9,73,78,48,165,255,222,145,108,175,21,175,179,109,211,176,151,245,120,230,189,121,79,51,50,40,214,162,51,172,66,184,71,107,153,211,181,207,174,181,170,69,211,89,230,133,86,217,189,101,202,201,248,255,226,252,231,197,249,89,231,132,106,96,223,59,143,237,167,197,51,213,74,137,85,72,118,217,14,21,90,81,81,14,101,189,179,216,80,20,74,229,209,214,68,248,17,202,173,49,178,79,240,221,29,179,212,15,37,184,47,104,180,19,94,219,30,98,185,233,30,164,168,64,76,213,127,91,76,44,183,202,11,223,207,177,98,89,57,23,110,136,41,72,60,203,243,28,10,215,181,45,179,253,102,10,124,53,156,121,4,231,89,131,160,107,96,1,7,124,210,66,118,168,205,151,197,133,9,44,16,252,254,124,25,43,247,232,28,21,149,252,114,83,228,241,237,122,178,194,167,35,173,251,208,195,243,186,71,45,248,216,98,76,143,41,87,187,142,162,207,233,62,192,58,156,187,85,29,113,190,196,246,126,56,199,117,107,110,80,146,129,96,14,78,66,173,237,104,144,27,136,223,192,154,40,113,160,90,19,118,178,195,29,122,7,21,83,21,74,168,37,107,222,236,168,44,250,206,42,183,185,78,176,139,124,138,134,180,7,173,101,224,47,221,54,1,27,242,145,255,179,146,113,12,3,209,40,8,249,60,142,255,231,118,217,26,109,253,4,2,37,207,142,252,31,250,78,149,188,86,129,177,186,162,124,16,28,105,69,107,129,246,72,198,107,79,105,155,130,36,4,217,201,77,27,27,154,1,210,221,158,219,85,116,3,144,7,47,193,46,23,241,110,66,93,95,198,24,60,48,255,121,134,7,127,146,77,123,18,254,123,210,92,165,91,19,54,228,148,117,211,116,222,136,120,85,211,187,1,229,7,246,32,78,42,5,166,56,60,50,217,97,72,92,246,178,24,252,25,190,8,42,143,47,158,228,230,13,226,190,81,15,147,91,7,29,87,163,37,191,134,207,8,42,62,124,73,194,99,140,133,223,111,200,19,105,50,200,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0e3a0a56-963d-49ec-bc63-26b00fcf3abf"));
		}

		#endregion

	}

	#endregion

}

