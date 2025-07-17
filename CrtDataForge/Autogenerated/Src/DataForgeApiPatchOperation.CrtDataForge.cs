using System;
using System.Runtime.Serialization;

namespace Terrasoft.Configuration.DataForge
{

	#region Enum: DataForgePatchOperationType

	/// <summary>
	/// Patch operation types for DataForge API.
	/// </summary>
	public enum DataForgePatchOperationType
	{
		None = 0,
		Add = 1,
		Remove = 2,
		Replace = 3
	}

	#endregion

	#region class DataForgeApiPatchOperation

	/// <summary>
	/// Patch operation structure for DataForge API.
	/// </summary>
	[DataContract]
	[Serializable]
	public sealed class DataForgeApiPatchOperation<T>
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="DataForgeApiPatchOperation{T}"/> class with the specified operation, path, and value.
		/// </summary>
		/// <param name="operation">The type of patch operation to perform.</param>
		/// <param name="path">The target path for the patch operation (JSON Pointer format).</param>
		/// <param name="value">The value to apply in the patch operation.</param> 
		public DataForgeApiPatchOperation(DataForgePatchOperationType operation, string path, T value) {
			Operation = operation.ToString().ToLowerInvariant();
			Path = path;
			Value = value;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the type of patch operation to perform.
		/// </summary>
		[DataMember(Name = "op")]
		public string Operation { get; set; }

		/// <summary>
		/// Gets or sets the target path for the patch operation, expressed in JSON Pointer syntax.
		/// </summary>
		[DataMember(Name = "path")]
		public string Path { get; set; }

		/// <summary>
		/// Gets or sets the value to be used in the patch operation.
		/// </summary>
		[DataMember(Name = "value")]
		public T Value { get; set; }

		#endregion

	}

	#endregion
}

