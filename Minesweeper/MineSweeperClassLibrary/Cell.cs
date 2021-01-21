/*
 * Minesweeper Milestone 3
 * Shawn Fradet
 * CST-227
 * 8/21/2020
 *
 * This is my own work.
 *
 * This is the Cell file for a Minesweeper game
 */

namespace MineSweeperClassLibrary
{
    public class Cell
    {
        public int Row { get; set; } = -1; // Row location of Cell
        public int Col { get; set; } = -1; // Column location of Cell
        public bool Visited { get; set; } = false; // Has the Cell been visited
        public bool Live { get; set; } = false; // Is the Cell a bomb
        public int LiveNeighbors { get; set; } = 0; // Quantity of neighbors that are bombs
        public bool IsFlagged { get; set; } = false; // Was the cell flagged
    }
}