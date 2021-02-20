using Minesweeper.Models;
using Minesweeper.Services.Data;
using Minesweeper.Services.Game;
using MineSweeperClassLibrary;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{

    // Controller for actions related to the running of Minesweeper game
    [CustomAuthorization] // Authorization filter for logged in users
    [CustomLogging] // Custom logging attribute for entry and exit to controller
    public class GameController : Controller
    {
        // Static instance of GameService for controlling all aspects of game play
        private static readonly GameService gameService = new GameService();
        
        // Action method for starting the game page
        // POST: Game
        [HttpPost]
        public ActionResult Game()
        {
            // Get size and difficulty from POST data 
            int size = int.Parse(Request["size"].ToString());
            int difficulty = int.Parse(Request["difficulty"].ToString());

            gameService.StartGame(size, difficulty); // Start game service

            return View("Game", gameService);
        }

        // Action method for responding to a player's left mouse click using Ajax.
        // POST: OnLeftMouesClick
        [HttpPost]
        public ActionResult OnLeftMouseClick(string mine)
        {
            // Send clicked cell's grid coordinates and take a turn
            gameService.TakeTurn(mine);

            // Returns partial view for Ajax
            return PartialView("_GameBoard", gameService);
        }

        // Action method for responding to a player's right moues click using Ajax.
        // POST: OnRightMouseClick
        [HttpPost]
        public ActionResult OnRightMouseClick(string mine)
        {
            // Send clicked cell's grid coordinates to flag cell
            gameService.FlagCell(mine);

            // Returns partial view for Ajax
            return PartialView("_GameBoard", gameService);
        }

        // Method for reseting the game
        public ActionResult ResetGame()
        {
            gameService.ResetGame();
            gameService.StartGame();

            return View("Game", gameService);
        }

        // Method for adding player score to highScore table
        public ActionResult PlayerStats(string time)
        {
            gameService.SaveScore(time);

            // Returns partial view for Ajax
            return PartialView("_GameBoard", gameService);
        }

        // Save a game. Requires current game time and turns
        public ActionResult OnSave(int time, int turnsCount)
        {
            gameService.SaveGame(time, turnsCount);

            // Returns partial view for Ajax
            return PartialView("_GameBoard", gameService);
        }

        // Load a game.
        public ActionResult OnLoad()
        {
            gameService.LoadGame();

            // Returns partial view for Ajax
            return PartialView("_GameBoard", gameService);
        }
    }
}