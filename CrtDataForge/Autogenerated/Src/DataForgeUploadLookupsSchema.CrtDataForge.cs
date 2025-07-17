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

	#region Class: DataForgeUploadLookups

	/// <exclude/>
	public partial class DataForgeUploadLookups : ProcessUserTask
	{

		#region Constructors: Public

		public DataForgeUploadLookups(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("2995dc4f-eede-44c5-abee-327363806d3a");
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

