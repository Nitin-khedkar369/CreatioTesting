namespace Terrasoft.Core.Process
{

	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: DataStructureTransferFromCreatioMethodsWrapper

	/// <exclude/>
	public class DataStructureTransferFromCreatioMethodsWrapper : ProcessModel
	{

		public DataStructureTransferFromCreatioMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("LogNotAvailableFunctionalityExecute", LogNotAvailableFunctionalityExecute);
		}

		#region Methods: Private

		private bool LogNotAvailableFunctionalityExecute(ProcessExecutingContext context) {
			var log = LogManager.GetLogger("DataForge");
			log.Warn("Data Structure Transfer From Creatio Failed. Functionality Not Available");
			return true;
		}

		#endregion

	}

	#endregion

}

