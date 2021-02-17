using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MinesweeperRestService.Models
{
	// Data transfer object for high score REST service. 
	[DataContract]
    public class RestDTO
    {
		[DataMember]
		public bool Error { get; set; } // Error true/false

		[DataMember]
		public string Message { get; set; } // String for messages

		[DataMember]
		public List<PlayerStats> Scores { get; set; } // List of high scores
	}
}