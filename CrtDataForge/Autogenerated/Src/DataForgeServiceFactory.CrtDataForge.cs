namespace Terrasoft.Configuration.DataForge
{
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Factories;
	using Terrasoft.OAuthIntegration;


	#region Interface: IDataForgeServiceFactory

	/// <summary>
	/// Defines a factory for creating <see cref="IDataForgeService"/> instances
	/// </summary>
	public interface IDataForgeServiceFactory
	{
		/// <summary>
		/// Creates an instance of <see cref="IDataForgeService"/> using the
		/// implementation name specified in system settings, and resolves required dependencies.
		/// </summary>
		/// <returns>
		/// An initialized <see cref="IDataForgeService"/> implementation.
		/// </returns>
		IDataForgeService Create();
	}

	#endregion

	[DefaultBinding(typeof(IDataForgeServiceFactory))]
	public class DataForgeServiceFactory : IDataForgeServiceFactory
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public DataForgeServiceFactory(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public IDataForgeService Create() {
			string implementationName = SysSettings.GetValue(
				_userConnection,
				"DataForgeServiceName",
				"DefaultDataForgeService");

			IIdentityServiceWrapper identityServiceWrapper = IdentityServiceWrapperHelper.GetInstance();

			return ClassFactory.Get<IDataForgeService>(
				implementationName,
				new ConstructorArgument("identityServiceWrapper", identityServiceWrapper)
			);
		}

		#endregion

	}
}

