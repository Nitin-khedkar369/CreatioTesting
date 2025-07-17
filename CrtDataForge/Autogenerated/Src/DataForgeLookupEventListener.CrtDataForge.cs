using Creatio.FeatureToggling;
using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.Events;
using Terrasoft.Core.Factories;
using static Terrasoft.Configuration.DataForge.DataForgeFeatures;

namespace Terrasoft.Configuration.DataForge
{

	/// <summary>
	/// Listens to entity lifecycle events (insert, update, delete) 
	/// and synchronizes lookup and lookup value data with the DataForge service.
	/// </summary>
	[EntityEventListener(IsGlobal = true)]
	public class DataForgeLookupEventListener : BaseEntityEventListener
	{

		#region Fields: Private

		private ILookupHandler _lookupHandler;
		private IDataForgeService _dataForgeService;

		#endregion

		#region Methods: Private

		private void InitializeDependencies() {
			_lookupHandler = ClassFactory.Get<ILookupHandler>();
			_dataForgeService = ClassFactory.Get<IDataForgeServiceFactory>().Create();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles the logic to execute after an entity is inserted.
		/// Creates a lookup or lookup value in the DataForge service based on the entity type.
		/// </summary>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);

			if (!Features.GetIsEnabled<RealtimeLookupSync>()) {
				return;
			}

			Entity entity = (Entity)sender;

			InitializeDependencies();

			if (_lookupHandler.IsLookup(entity)) {
				_dataForgeService.UploadLookup(entity);
			} else if (_lookupHandler.IsLookupValue(entity)) {
				_dataForgeService.UpdateLookupsForValue(entity);
			}
		}

		/// <summary>
		/// Handles the logic to execute after an entity is updated.
		/// Updates the corresponding lookup or lookup value in the DataForge service.
		/// </summary>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);

			if (!Features.GetIsEnabled<RealtimeLookupSync>()) {
				return;
			}

			Entity entity = (Entity)sender;

			InitializeDependencies();

			if (_lookupHandler.IsLookup(entity)) {
				_dataForgeService.UploadLookup(entity);
			} else if (_lookupHandler.IsLookupValue(entity)) {
				_dataForgeService.UpdateLookupsForValue(entity);
			}
		}

		/// <summary>
		/// Handles the logic to execute after an entity is deleted.
		/// Deletes the corresponding lookup or lookup value from the DataForge service.
		/// </summary>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);

			if (!Features.GetIsEnabled<RealtimeLookupSync>()) {
				return;
			}

			Entity entity = (Entity)sender;

			InitializeDependencies();

			if (_lookupHandler.IsLookup(entity)) {
				_dataForgeService.DeleteLookup(entity.InstanceUId);
			} else if (_lookupHandler.IsLookupValue(entity)) {
				_dataForgeService.UpdateLookupsForValue(entity);
			}
		}

		#endregion
	}
}
