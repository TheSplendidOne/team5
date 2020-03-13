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
                    new Vec(0, 0), 
                    game,
                    game[new Vec(0, 0)]);
                adjacentCells.Add(new Vec(0, 0));
                foreach (CellDto cell in result.Cells.Where(cell => adjacentCells.Contains(cell.Pos)))
                {
                    cell.Type = game.palette[game.content[userInput.ClickedPos.X, userInput.ClickedPos.Y]];
                }

                foreach (var adjacentCell in adjacentCells)
                {
                    game.content[adjacentCell.X, adjacentCell.Y] =
                        game.content[userInput.ClickedPos.X, userInput.ClickedPos.Y];
                }
            }
            return new ObjectResult(result);
        }
    }
}