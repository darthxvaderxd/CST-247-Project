using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MinesweeperRestService.Models;

namespace Minesweeper
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IScoreService
	{
		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScoresById/{id}")]
        RestDTO GetScoresById(string id);

		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetScoresByUsername/{id}")]
		RestDTO GetScoresByUsername(string id);

		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetTopTenScores/{boardSize}/{difficulty}")]
		RestDTO GetTopTenScores(string boardSize, string difficulty);
	}

}
