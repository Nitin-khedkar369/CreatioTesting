namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DataForgeGetLookupsResponseSchema

	/// <exclude/>
	public class DataForgeGetLookupsResponseSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DataForgeGetLookupsResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DataForgeGetLookupsResponseSchema(DataForgeGetLookupsResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7c2fcb76-ff52-4682-aabb-952e8faea18a");
			Name = "DataForgeGetLookupsResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b820ca9a-eace-4f3c-8ba5-b9b28481b75a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,157,148,49,111,219,48,16,133,231,4,200,127,56,164,75,187,200,123,156,102,72,140,26,1,146,32,176,10,47,69,7,134,60,41,68,41,82,56,82,6,92,163,255,189,71,74,178,99,91,54,212,78,6,239,30,223,189,143,164,5,86,84,232,107,33,17,190,35,145,240,174,8,217,131,179,133,46,27,18,65,59,155,205,68,16,223,28,149,120,117,185,185,186,188,104,188,182,37,228,107,31,176,154,30,172,121,167,49,40,227,54,159,205,209,34,105,121,164,89,52,54,232,10,179,156,187,194,232,223,105,202,78,245,49,6,37,213,74,75,124,118,10,13,231,10,36,100,96,49,203,63,17,150,188,19,30,140,240,254,6,182,49,231,24,158,156,251,213,212,126,193,100,156,4,147,124,50,153,192,173,111,170,74,208,250,174,91,47,176,38,244,104,131,135,240,142,64,157,30,170,56,13,10,71,92,10,164,113,21,131,153,214,20,180,77,226,56,15,210,64,240,109,198,172,159,50,249,48,230,71,212,245,193,127,114,161,110,222,140,150,32,99,234,115,161,225,6,238,133,199,29,195,197,38,113,108,185,95,201,213,72,65,35,195,191,38,211,182,127,8,154,10,236,239,129,121,60,118,172,70,251,0,174,216,82,117,160,168,160,32,87,157,33,60,70,108,25,159,177,122,67,250,252,194,239,9,190,194,181,226,210,245,151,8,220,19,63,241,196,219,22,114,134,133,182,58,222,123,143,119,215,78,219,64,137,97,26,83,78,225,79,135,139,86,181,196,105,221,86,15,138,7,79,225,212,144,164,61,127,33,167,183,142,61,254,161,195,208,106,255,40,230,141,86,240,168,134,112,135,182,199,255,232,190,129,231,203,226,39,153,4,35,77,20,122,73,186,142,80,131,94,179,93,127,172,37,97,129,132,86,98,46,223,177,18,47,167,98,46,142,117,99,71,172,132,105,240,81,13,218,46,219,222,63,89,157,204,184,236,187,163,237,248,59,231,40,215,149,54,130,116,88,231,146,63,87,251,214,202,241,47,194,114,72,249,159,79,157,107,127,1,153,125,247,90,179,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7c2fcb76-ff52-4682-aabb-952e8faea18a"));
		}

		#endregion

	}

	#endregion

}

