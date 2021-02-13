/*
 * Minesweeper Milestone 6
 * Shawn Fradet
 * CST-227
 * 9/20/2020
 *
 * This is my own work.
 *
 * This class represents a Players game information
 */
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MineSweeperClassLibrary
{
    [DataContract]
    public class PlayerStats : IComparable<PlayerStats>
    {
        [DataMember]
        public string PlayerInitials { get; set; }
        [DataMember]
        public double DifficultyLevel { get; set; }
        [DataMember]
        public int BoardSize { get; set; }
        [DataMember]
        public TimeSpan Time { get; set; }
        [DataMember]
        public string TimeSpanString { get; set; }

        public PlayerStats() { }

        public PlayerStats(string playerInitials, TimeSpan time, double difficultyLevel, int boardSize)
        {
            this.PlayerInitials = playerInitials;
            this.Time = time;
            this.DifficultyLevel = difficultyLevel;
            this.BoardSize = boardSize;
        }

        // Override the ToString to output all information for save file
        public override string ToString()
        {
            return this.PlayerInitials + ", " + this.Time;
        }

        // Implement ICompareable. Sort by time and then initials
        public int CompareTo(PlayerStats obj)
        {
            if (this.Time == obj.Time)
            {
                return this.PlayerInitials.CompareTo(obj.PlayerInitials);
            }

            return this.Time.CompareTo(obj.Time);
        }
    }
}
