using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Minesweeper.Services;
using Minesweeper.Services.Data;
using MineSweeperClassLibrary;

namespace MinesweeperRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        HighScoreDAO service = new HighScoreDAO();
        public CompositeResult GetScores(string id)
        {
            CompositeResult response = new CompositeResult();
            response.Error = false;
            response.Message = "";

            try
            {
                List<PlayerStats> scores = service.GetScoresForUser(int.Parse(id));
                if (scores.Count > 0) {
                    response.Scores = scores;
                } else
                {
                    response.Error = true;
                    response.Message = "No scores found";
                }
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
