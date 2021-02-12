using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class GameData
    {
        public int UserId { get; set; }
        public int Turns { get; set; }
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public int Timer { get; set; }
        public string JSONData { get; set; }
    }
}