using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MinesweeperRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IScoreService
	{
		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScoresById/{id}")]
		CompositeResult GetScoresById(string id);

		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScoresByUsername/{id}")]
		CompositeResult GetScoresByUsername(string id);
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
		public List<PlayerStats> Scores { get; set; }
	}
}
