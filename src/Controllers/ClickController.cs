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
                var adjacentCells = GetAdjacentCells(game);
                adjacentCells.Add(new Vec(0, 0));
                foreach (var cell in result.Cells.Where(cell => adjacentCells.Contains(cell.Pos)))
                {
                    cell.Type = game.Palette[game.Content[userInput.ClickedPos.X, userInput.ClickedPos.Y]];
                }

     
                // game.Points += adjacentCells.Count - game.PreviousAdjacentCellsCount;
                // game.PreviousAdjacentCellsCount = adjacentCells.Count;

                foreach (var adjacentCell in adjacentCells)
                {
                    game.Content[adjacentCell.X, adjacentCell.Y] =
                        game.Content[userInput.ClickedPos.X, userInput.ClickedPos.Y];
                }

                var adjacentCellCount = GetAdjacentCells(game).Count + 1;
                result.IsFinished = adjacentCellCount == game.SizeX * game.SizeY;
                result.Score = adjacentCellCount;
            }

            return new ObjectResult(result);
        }
        private IList<Vec> GetAdjacentCells(GameBoard game)
        {
            return DFS.GetAdjacentCells(
                new Boolean[game.SizeX, game.SizeY],
                new Vec(0, 0), 
                game,
                game[new Vec(0, 0)]);
        }
    }
    
}