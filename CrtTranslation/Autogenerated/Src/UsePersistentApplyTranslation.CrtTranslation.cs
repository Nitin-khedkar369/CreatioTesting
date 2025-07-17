 namespace Terrasoft.Configuration.Translation
{
	using Creatio.FeatureToggling;

	#region Class: UsePersistentApplyTranslation

	internal class UsePersistentApplyTranslation : FeatureMetadata
	{

		#region Constructors: Public

		public UsePersistentApplyTranslation() {
			IsEnabled = true;
			Description = "Enables failover apply translation with persistance.";
		}

		#endregion

	}

	#endregion

}

