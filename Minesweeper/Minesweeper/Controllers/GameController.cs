using Minesweeper.Services.Game;
using MineSweeperClassLibrary;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    // Controller for actions related to the running of Minesweeper game
    public class GameController : Controller
    {
        // Static instance of GameService for controlling all aspects of game play
        private static GameService gameService = new GameService();

        // Action method for starting the game page
        // GET: Game
        public ActionResult Game()
        {
            if (Session["login"] == null)
            {
                return RedirectToRoute("Login");
            }

            gameService.StartGame();

            return View("Game", gameService);
        }

        // Action method for responding to a player's left mouse click
        // POST: OnLeftMouesClick
        [HttpPost]
        public ActionResult OnLeftMouseClick(string mine)
        {
            // Send clicked cell's grid coordinates and take a turn
            gameService.TakeTurn(mine);

            return View("Game", gameService);
        }

        // Action method for responding to a player's right moues click.
        // POST: OnRightMouseClick
        [HttpPost]
        public ActionResult OnRightMouseClick(string mine)
        {
            // Send clicked cell's grid coordinates to flag cell
            gameService.FlagCell(mine);

            return View("Game", gameService);
        }

        // Method for reseting the game
        public ActionResult ResetGame()
        {
            gameService.ResetGame();
            gameService.StartGame();

            return View("Game", gameService);
        }
    }
}