﻿using MineSweeperClassLibrary;

namespace Minesweeper.Services.Game
{
    // Service for Game related functions
    public class GameService
    {
        public Board gameBoard = new Board(10, 1); // Class with game functions
        public bool gameOver = false; // Boolean for if game is over
        public bool isWinner = false; // Boolean for if the player won

        // Method for starting a new game
        public void StartGame()
        {
            gameBoard.SetupLiveNeighbors(); // Place bombs in grid
            gameBoard.CalculateLiveNeighbors(); // Calculate live neighbor count for cells
        }

        // Method for handling one turn. Takes cell coordinates as input
        public void TakeTurn(string cell)
        {
            // Get row and column from input and set to integers
            string[] strArr = cell.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            // If cell is not flagged proceed with turn
            if (!gameBoard.Grid[r, c].IsFlagged)
            {
                // Flood fill board
                gameBoard.FloodFill(r, c);

                // Check if user clicked on a bomb or cleared the board completing game.
                if (gameBoard.Grid[r, c].Live || allCellsVisited())
                {
                    gameOver = true;
                }

                // Check if payer won the game through clearing the board.
                if (allCellsVisited())
                {
                    isWinner = true;
                }
            }
        }

        // Method for flagging a cell.
        public void FlagCell(string mine)
        {
            // Get row and column and set to integers
            string[] strArr = mine.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            // Toggle flagged boolean back and forth
            gameBoard.Grid[r, c].IsFlagged = !gameBoard.Grid[r, c].IsFlagged;
        }

        // Method for checking if all cells have been visited
        private bool allCellsVisited()
        {
            bool allVisited = true; // Boolean to check if all tiles are visited

            for (int row = 0; row < gameBoard.Size; row++)
            {
                for (int col = 0; col < gameBoard.Size; col++)
                {
                    // Step through all tiles. If tile is not a bomb and not visited, allVisited is false.
                    if (!gameBoard.Grid[row, col].Visited && !gameBoard.Grid[row, col].Live)
                    {
                        allVisited = false;
                    }
                }
            }
            return allVisited;
        }

        // Method to reset the game.
        public void ResetGame()
        {
            gameBoard = new Board(10, 1);
            gameOver = false;
            isWinner = false;
        }
    }
}