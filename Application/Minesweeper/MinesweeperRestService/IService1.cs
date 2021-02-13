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
    public interface IService1
	{
		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScores")]
		CompositeResult GetScores();
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
