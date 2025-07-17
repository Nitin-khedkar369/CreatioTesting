namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: DataForgeGetTablesDtoSchema

	/// <exclude/>
	public class DataForgeGetTablesDtoSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DataForgeGetTablesDtoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DataForgeGetTablesDtoSchema(DataForgeGetTablesDtoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e6c9149a-be1b-42f5-9e34-82733d2189b1");
			Name = "DataForgeGetTablesDto";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("18d347b6-8c17-4213-92f4-7f5294bb1a8f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,125,144,79,79,195,48,12,197,207,155,180,239,96,141,11,92,218,251,54,118,0,196,46,12,77,219,110,136,67,214,186,37,82,254,84,118,58,105,76,124,119,156,180,133,1,18,151,40,118,158,223,243,47,78,89,228,70,21,8,123,36,82,236,171,144,221,123,87,233,186,37,21,180,119,217,131,10,234,209,83,141,147,241,121,50,30,181,172,93,13,187,19,7,180,162,52,6,139,40,227,108,133,14,73,23,243,223,154,109,235,130,182,152,237,228,85,25,253,158,92,191,85,151,177,148,84,71,93,224,218,151,104,100,143,64,170,8,34,22,121,158,231,176,224,214,90,69,167,101,95,111,177,33,100,116,129,33,188,33,200,189,145,85,16,108,28,135,202,147,180,2,105,60,198,164,160,14,6,193,69,96,208,46,13,68,54,72,112,192,93,112,54,36,229,23,81,47,81,55,108,243,42,141,166,61,24,93,64,97,20,51,124,125,208,10,195,62,102,240,118,216,99,6,119,138,113,40,101,240,156,80,70,87,132,181,252,2,108,200,55,72,65,35,207,96,147,60,187,247,223,172,169,33,246,12,130,196,216,227,26,205,1,124,245,3,172,231,197,18,42,242,246,31,200,191,148,29,230,26,237,1,233,250,89,220,224,22,166,165,180,166,55,145,121,128,126,146,212,5,75,138,171,151,157,247,25,106,12,243,184,215,28,62,122,64,116,101,199,152,234,212,149,227,19,100,38,62,203,110,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6c9149a-be1b-42f5-9e34-82733d2189b1"));
		}

		#endregion

	}

	#endregion

}

