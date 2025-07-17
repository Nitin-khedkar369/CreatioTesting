namespace Terrasoft.Core.Process.Configuration
{

    using Terrasoft.Core;
    using Terrasoft.Core.Factories;
    using Terrasoft.Core.Process;
    using Terrasoft.Configuration.Translation;

    #region Class: GenerateStaticContentForChangedSchemasUserTask

    /// <exclude/>
    public partial class GenerateStaticContentForChangedSchemasUserTask
    {

        #region Methods: Private

		private void BuildConfiguration() {
            if (!GlobalAppSettings.UseStaticFileContent) {
                return;
            }
            var configurationBuilder = ClassFactory.Get<Terrasoft.Core.ConfigurationBuild.IAppConfigurationBuilder>();
			configurationBuilder.BuildChanged();
        }

		#endregion

		#region Methods: Protected

        protected override bool InternalExecute(ProcessExecutingContext context) {
            ApplyTranslationProcessExtension.UpdateApplyProcessStage(context, ApplySessionId,
                ApplyTranslationsStagesEnum.GenerateStaticContent);
			BuildConfiguration();
			return true;
        }

        #endregion

        #region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

        public override void CancelExecuting(params object[] parameters) {
            ApplyTranslationProcessExtension.CancelApplySession(UserConnection, ApplySessionId);
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