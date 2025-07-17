namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: GetTableRelationshipsResponseSchema

	/// <exclude/>
	public class GetTableRelationshipsResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetTableRelationshipsResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetTableRelationshipsResponseSchema(GetTableRelationshipsResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("429b46cb-1e8b-401c-b183-8f3f576d8714");
			Name = "GetTableRelationshipsResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("195cc880-8d9a-40cf-93a3-71c8d932bd30");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,83,77,107,2,49,16,61,175,208,255,16,236,165,5,89,104,143,106,61,84,173,23,45,178,74,47,210,67,118,29,215,64,54,187,36,179,82,43,254,247,78,178,126,173,90,145,218,75,8,153,247,94,222,204,75,20,79,192,100,60,2,54,6,173,185,73,103,232,183,83,53,19,113,174,57,138,84,249,29,142,252,45,213,49,220,85,86,119,21,47,55,66,197,108,180,52,8,9,33,165,132,200,194,140,223,3,5,90,68,141,99,76,144,43,20,9,248,35,170,114,41,190,157,234,30,117,120,173,118,168,133,136,96,144,78,65,146,15,212,60,66,2,19,252,94,67,76,76,214,85,121,82,103,67,142,243,1,36,33,232,241,50,3,7,152,88,167,91,206,39,29,100,121,40,69,196,128,8,39,120,207,246,226,77,172,88,113,108,9,222,7,104,132,47,246,194,158,106,78,242,4,208,157,198,64,229,103,218,175,11,87,160,166,133,177,146,201,182,228,198,28,186,188,232,48,178,232,18,216,218,179,247,109,245,134,58,205,200,155,0,43,234,72,27,127,86,177,32,61,188,83,148,228,173,138,212,96,245,209,217,221,232,151,155,103,110,89,177,24,176,193,140,93,214,191,139,73,30,130,44,171,25,212,54,184,190,173,92,43,147,237,252,111,181,180,88,112,4,214,17,238,249,112,189,108,22,186,181,141,126,235,160,231,115,183,28,13,254,218,52,174,204,225,182,4,116,154,227,81,4,125,97,176,185,207,161,197,2,139,249,167,198,122,128,99,30,74,8,64,186,223,101,230,34,51,1,253,107,218,94,254,27,69,199,23,249,172,206,94,185,129,189,220,45,147,201,104,2,230,204,100,118,153,219,250,31,167,66,103,63,232,168,9,93,206,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("429b46cb-1e8b-401c-b183-8f3f576d8714"));
		}

		#endregion

	}

	#endregion

}

