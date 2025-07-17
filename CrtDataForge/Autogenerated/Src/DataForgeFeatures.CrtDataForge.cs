namespace Terrasoft.Configuration.DataForge
{
	using Creatio.FeatureToggling;

	#region Class: DataForgeFeatures

	/// <summary>
	/// Contains feature flags and related configurations for the Data Forge service.
	/// </summary>
	public class DataForgeFeatures
	{

		#region Class: UseOAuth

		/// <summary>
		/// Represents the feature flag for enabling OAuth authentication in the Data Forge service.
		/// </summary>
		public class UseOAuth : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="UseOAuth"/> class with default settings.
			/// </summary>
			public UseOAuth() {
				IsEnabled = false;
				Description = "Use OAuth authentication for Data Forge service";
			}

			#endregion

		}

		#endregion

		#region Class: RealtimeSchemaSync

		/// <summary>
		/// Represents the feature flag for enabling real-time detection and processing of data model modifications.
		/// When enabled, the system will automatically detect and apply changes to the data model,
		/// such as added, updated, or removed entities, without requiring manual intervention or restart.
		/// </summary>
		public class RealtimeSchemaSync : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="RealtimeSchemaSync"/> class with default settings.
			/// </summary>
			public RealtimeSchemaSync() {
				IsEnabled = false;
				Description = "Enable real-time detection and processing of data model modifications";
			}

			#endregion

		}

		#endregion

		#region Class: RealtimeLookupSync

		/// <summary>
		/// Represents the feature flag for enabling real-time detection and processing of lookup modifications.
		/// When enabled, the system will automatically detect and apply changes to lookup definitions and values,
		/// such as added, updated, or removed lookups, without requiring manual intervention or restart.
		/// </summary>
		public class RealtimeLookupSync : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="RealtimeLookupSync"/> class with default settings.
			/// </summary>
			public RealtimeLookupSync() {
				IsEnabled = false;
				Description = "Enable real-time detection and processing of lookup modifications";
			}

			#endregion

		}

		#endregion

		#region Class: BulkSchemaSync

		/// <summary>
		/// Represents the feature flag for enabling bulk synchronization of data model.
		/// When enabled, the system allows synchronization of data model items in bulk.
		/// </summary>
		public class BulkSchemaSync : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="BulkSchemaSync"/> class with default settings.
			/// </summary>
			public BulkSchemaSync() {
				IsEnabled = false;
				Description = "Enable bulk synchronization of data model";
			}

			#endregion

		}

		#endregion

		#region Class: BulkLookupSync

		/// <summary>
		/// Represents the feature flag for enabling bulk synchronization of lookup definitions and values.
		/// When enabled, the system allows synchronization of lookup definitions and values in bulk.
		/// </summary>
		public class BulkLookupSync : FeatureMetadata
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="BulkLookupSync"/> class with default settings.
			/// </summary>
			public BulkLookupSync() {
				IsEnabled = false;
				Description = "Enable bulk synchronization for lookup definitions and values";
			}

			#endregion

		}

		#endregion

	}

	#endregion

}

