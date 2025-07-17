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

	#region Class: DataForgeUploadDataStructure

	/// <exclude/>
	public partial class DataForgeUploadDataStructure : ProcessUserTask
	{

		#region Constructors: Public

		public DataForgeUploadDataStructure(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("3561598c-7af1-4a56-b30b-6a3727e22790");
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
			writer.WriteFinishObject();
		}

		#endregion

	}

	#endregion

}

