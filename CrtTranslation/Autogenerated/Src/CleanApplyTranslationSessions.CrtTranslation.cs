namespace Terrasoft.Core.Process.Configuration
{

	using Terrasoft.Core.DB;
	using Terrasoft.Core.Process;

	#region Class: CleanApplyTranslationSessions

	/// <exclude/>
	public partial class CleanApplyTranslationSessions
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var select = new Select(UserConnection)
				.Column("aps", "Id")
				.From("ApplySession").As("aps")
				.LeftOuterJoin("SysProcessLog").As("spl").On("aps", "ProcessId").IsEqual("spl", "Id")
				.LeftOuterJoin("SysProcessStatus").As("sps").On("spl", "StatusId").IsEqual("sps", "Id") as Select;
			if (!ClearRunning) {
				select = select.Where("sps", "Name").IsNotEqual(Column.Parameter("Running")) as Select;
			}
			var deleteParameters = new Delete(UserConnection)
				.From("ApplyTranslationParameters")
				.Where("Id").In(select);
			deleteParameters.Execute();
			var deleteSessions = new Delete(UserConnection)
				.From("ApplySession")
				.Where("Id").In(select);
			deleteSessions.Execute();
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}
