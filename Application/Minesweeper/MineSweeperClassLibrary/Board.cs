/*
 * Minesweeper Milestone 3
 * Shawn Fradet
 * CST-227
 * 8/30/2020
 *
 * This is my own work.
 *
 * This is the Board file for a minesweeper console game.
 */

using System;

namespace MineSweeperClassLibrary
{
    public class Board
    {
        public int Size { get; set; } // Size of the board, Size x Size
        public Cell[,] Grid { get; set; } // Array of Cells for board
        public double Difficulty { get; set; } // Difficultly of game as percentage

        // Board constructor. Takes size as an argument
        public Board(int size, int difficulty)
        {
            this.Size = size;
            this.Grid = new Cell[Size, Size]; // Set Cell array to Size x Size

            // Set percentage of bombs by difficulty
            if (difficulty == 1) { Difficulty = .15; }
            if (difficulty == 2) { Difficulty = .17; }
            if (difficulty == 3) { Difficulty = .19; }

            // Step through Cell array and create new Cell in each index
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new Cell
                    {
                        Row = row,
                        Col = col
                    };
                }
            }
        }

        // Method for planting bombs in the Board
        public void SetupLiveNeighbors()
        {
            int cells = Size * Size; // Find number of cells in board

            // Multiply number of cells by difficultly percentage and round up for bomb count
            int bombs = (int)Math.Ceiling(cells * Difficulty);
            // Create new random number generator
            var rand = new Random();

            int count = 0; // Counter for bombs

            // Randomly generate (x,y) coordinates and place bomb on board if not already a bomb.
            while (count < bombs)
            {
                int randRow = rand.Next(Size);
                int randCol = rand.Next(Size);
                if (Grid[randRow, randCol].Live != true)
                {
                    Grid[randRow, randCol].Live = true;
                    count++;
                }
            }
        }

        // Find the a Cell's number of neighbors that are bombs.
        public void CalculateLiveNeighbors()
        {
            // Step through each Cell in Grid and check valid neighbors for bombs.
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (IsValid(row - 1, col - 1) && Grid[row - 1, col - 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row - 1, col) && Grid[row - 1, col].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row - 1, col + 1) && Grid[row - 1, col + 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row, col - 1) && Grid[row, col - 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row, col + 1) && Grid[row, col + 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row + 1, col - 1) && Grid[row + 1, col - 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row + 1, col) && Grid[row + 1, col].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row + 1, col + 1) && Grid[row + 1, col + 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                }
            }
        }

        // Method that checks if a Grid location is valid
        public bool IsValid(int row, int col)
        {
            // Check if cell is within the array
            if (row >= 0 && row < Size && col >= 0 && col < Size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method for recursively opening up all cells with no live neighbors
        public void FloodFill(int row, int col)
        {
            // Check Cell, if valid, not visited, and no live neighbors mark as visited and check neighbors
            if (IsValid(row, col) && Grid[row, col].Visited != true && Grid[row, col].LiveNeighbors == 0)
            {
                Grid[row, col].Visited = true;
                // Check surrounding eight cells
                FloodFill(row + 1, col);
                FloodFill(row, col + 1);
                FloodFill(row - 1, col);
                FloodFill(row, col - 1);
                
                FloodFill(row + 1, col + 1);
                FloodFill(row - 1, col + 1);
                FloodFill(row + 1, col - 1);
                FloodFill(row - 1, col - 1);
            }
            // If live neighbors, mark as visited
            else if (IsValid(row, col) && Grid[row, col].Visited != true)
            {
                Grid[row, col].Visited = true;
            }
        }

    }
}