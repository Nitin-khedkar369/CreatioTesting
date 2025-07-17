namespace Terrasoft.Configuration.DataForge
{
	using System;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core.Factories;

	#region Interface: IChecksumProvider

	/// <summary>
	/// Provides functionality to compute a checksum.
	/// </summary>
	public interface IChecksumProvider
	{
		/// <summary>
		/// Computes a checksum (MD5 hash) from the provided string values.
		/// Each string is normalized by trimming and converting to lowercase before hashing.
		/// </summary>
		/// <param name="values">One or more strings to include in the checksum calculation.</param>
		/// <returns>
		/// An MD5 hash of the normalized and concatenated values, or <c>null</c> if no values are provided.
		/// </returns>
		string GetChecksum(params string[] values);
	}

	#endregion

	#region Class: ChecksumProvider

	[DefaultBinding(typeof(IChecksumProvider))]
	internal class ChecksumProvider : IChecksumProvider
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("DataForge");

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public string GetChecksum(params string[] values) {
			if (values == null || values.Length == 0) {
				return null;
			}
			try {
				var normalized = values
					.Select(v => string.IsNullOrWhiteSpace(v) ? string.Empty : v.Trim().ToLowerInvariant())
					.ToArray();

				var concatenated = string.Join("|", normalized);

				return FileUtilities.GetMD5HashFromString(concatenated);
			} catch (Exception ex) {
				_log.Error("Error computing checksum.", ex);
				return null;
			}
		}

		#endregion
	}

	#endregion
}

