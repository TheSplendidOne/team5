using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/click")]
    public class ClickController : Controller
    {
        [HttpPost]
        public IActionResult Click(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = GamesRepo.Games[gameId];
            var result = game.GetDto();
            if (userInput.ClickedPos != null)
            {
                List<Vec> adjacentCells = DFS.GetAdjacentCells(
                    new Boolean[game.SizeX, game.SizeY],
                    userInput.ClickedPos,
                    game,
                    game[userInput.ClickedPos]);
                foreach (CellDto cell in result.Cells.Where(cell => adjacentCells.Contains(cell.Pos)))
                {
                    cell.Type = game.palette[game.content[userInput.ClickedPos.X, userInput.ClickedPos.Y]];
                }
            }
            return new ObjectResult(result);
        }
    }
}