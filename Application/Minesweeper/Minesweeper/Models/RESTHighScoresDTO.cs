using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Minesweeper.Models
{
	// Class for storing data retrieved from high score REST service
	[DataContract]
    public class RESTHighScoresDTO
    {
		[DataMember]
		public bool Error { get; set; } // Error true/false

		[DataMember]
		public string Message { get; set; } // String to hold messages

		[DataMember]
		public List<PlayerStats> Scores { get; set; } // List of high scores
	}
}