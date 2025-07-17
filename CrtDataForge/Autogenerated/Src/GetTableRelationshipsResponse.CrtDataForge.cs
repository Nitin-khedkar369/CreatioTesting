namespace Terrasoft.Configuration.DataForge
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Core.ServiceModelContract;

	#region Enum: PathMemberType

	[DataContract]
	public enum PathMemberType
	{
		[EnumMember]
		Vertex = 1,

		[EnumMember]
		Edge = 2
	}

	#endregion

	#region Class: PathMember

	[DataContract]
	public class PathMember
	{

		#region Properties: Public

		[DataMember(Name = "type")]
		public PathMemberType Type { get; set; }

		[DataMember(Name = "label")]
		public string Label { get; set; }

		[DataMember(Name = "properties")]
		private Dictionary<string, string> Properties { get; set; }

		#endregion

	}

	#endregion

	#region Class: Path

	[DataContract]
	public class Path
	{

		#region Properties: Public

		[DataMember(Name = "route")]
		public List<PathMember> Route { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetTableRelationshipsResponse

	[DataContract]
	public class GetTableRelationshipsResponse : BaseResponse
	{

		#region Properties: Public

		[DataMember(Name = "paths")]
		public List<string> Paths { get; set; }

		#endregion

	}

	#endregion

}

