 namespace Terrasoft.Configuration.Translation
{
	using Quartz;
	using Quartz.Impl.Triggers;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using global::Common.Logging;

	#region Class: ApplyTranslationAppEventListener

	/// <summary>
	/// An application event listener that restart not completed apply translation.
	/// </summary>
	/// <seealso cref="Terrasoft.Web.Common.AppEventListenerBase"/>
	public class ApplyTranslationAppEventListener : AppEventListenerBase
	{

		#region Constants: Private

		private const string FileImportTriggerName = "RestartApplyTranslationTrigger";
		private const string JobGroupName = "RestartApplyTranslation";

		#endregion

		#region Fields: Private

		private static readonly ILog Logger = LogManager.GetLogger("Translation");
		private readonly IAppSchedulerWraper _schedulerWrapper = ClassFactory.Get<IAppSchedulerWraper>();

		#endregion

		#region Methods: Private

		private static AppConnection GetAppConnection(AppEventContext context) {
			return (AppConnection)context.Application["AppConnection"];
		}

		private void RestartUncompletedApplyTranslation(UserConnection userConnection) {
			const string jobName = JobGroupName;
			Logger.InfoFormat("Try to scheduled to restart uncompleted apply translation ScheduledJob with job name {0}", jobName);
			if (_schedulerWrapper.DoesJobExist(jobName, JobGroupName)) {
				_schedulerWrapper.RemoveJob(jobName, JobGroupName);
			}
			IJobDetail job = _schedulerWrapper.CreateClassJob<ApplyTranslationBackgroundProcessor>(jobName,
				JobGroupName, userConnection, isSystemUser: true);
			ITrigger trigger = new SimpleTriggerImpl(FileImportTriggerName, JobGroupName);
			var date = _schedulerWrapper.Instance.ScheduleJob(job, trigger);
			Logger.InfoFormat("Scheduled to restart uncompleted apply translation ScheduledJob with job name {0} at {1:yyyy-MM-ddTHH:mm:ssZ} UTC",
				jobName, date.UtcDateTime);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Start import who not been ended.
		/// </summary>
		/// <param name="context">Application event context.</param>
		public override void OnAppStart(AppEventContext context) {
			Logger.InfoFormat("Try to run restart uncompleted apply translation");
			var appConnection = GetAppConnection(context);
			var systemUserConnection = appConnection.SystemUserConnection;
			var usePersistentApplyTranslation = systemUserConnection.GetIsFeatureEnabled("UsePersistentApplyTranslation");
			Logger.InfoFormat("IsFeature UsePersistentApplyTranslation is: {0}", usePersistentApplyTranslation);
			if (usePersistentApplyTranslation) {
				RestartUncompletedApplyTranslation(systemUserConnection);
			}
		}

		#endregion

	}

	#endregion

}

