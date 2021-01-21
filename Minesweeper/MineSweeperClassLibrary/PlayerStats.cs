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
using System.Text;

namespace MineSweeperClassLibrary
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public PlayerStats() { }

        public PlayerStats(string playerInitials, TimeSpan time, double difficultyLevel, int boardSize)
        {
            this.PlayerInitials = playerInitials;
            this.time = time;
            this.DifficultyLevel = difficultyLevel;
            this.BoardSize = boardSize;            
        }

        public string PlayerInitials { get; set; }
        public double DifficultyLevel { get; set; }
        public int BoardSize { get; set; }
        public TimeSpan time { get; set; }

        // Override the ToString to output all information for save file
        public override string ToString()
        {
            return this.PlayerInitials + ", " + this.time + ", " + this.BoardSize + ", " + this.DifficultyLevel;
        }

        // Implement ICompareable. Sort by time and then initials
        public int CompareTo(PlayerStats obj)
        {
            if (this.time == obj.time)
            {
                return this.PlayerInitials.CompareTo(obj.PlayerInitials);
            }

            return this.time.CompareTo(obj.time);
        }
    }
}
