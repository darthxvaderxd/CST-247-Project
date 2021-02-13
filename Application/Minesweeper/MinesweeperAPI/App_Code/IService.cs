using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
	[OperationContract]
	[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Test/{id}")]
	string Test(string id);

	[OperationContract]
	[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScores")]
	CompositeResult GetScores();
}

[DataContract]
public class CompositScore
{
	[DataMember]
	public int Id { get; set; }

	[DataMember]
	public int Timespan { get; set; }

	[DataMember]
	public int Difficulty { get; set; }

	[DataMember]
	public int Size { get; set; }

}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeResult
{
	[DataMember]
	public bool Error { get; set; }

	[DataMember]
	public string Message { get; set; }

	[DataMember]
	public List<CompositScore> Scores { get; set; }
}
