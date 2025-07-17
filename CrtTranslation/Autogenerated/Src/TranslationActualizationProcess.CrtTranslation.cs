namespace Terrasoft.Core.Process
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Configuration.Translation;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: TranslationActualizationProcessMethodsWrapper

	/// <exclude/>
	public class TranslationActualizationProcessMethodsWrapper : ProcessModel
	{

		public TranslationActualizationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			ActualizeTranslation(context);
			return true;
		}

			public virtual void ActualizeTranslation(ProcessExecutingContext context) {
			    var userConnection = context.UserConnection;
			    var service = new TranslationService(userConnection);
			    service.ActualizeTranslation();
			}

		#endregion

	}

	#endregion

}

