using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = TestData.AGameDto(userInput.ClickedPos ?? new Vec(1, 1));
            if (userInput.ClickedPos != null)
                game.Board[new Vec(0, 0)] = userInput.ClickedPos.X;
            return new ObjectResult(game);
        }
    }
}