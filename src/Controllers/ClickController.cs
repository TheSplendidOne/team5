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
            var maxColorId = -1;
            if (userInput.KeyPressed.ToString().ToUpper() == "I")
            {
                var palette = game.Palette;
                var maxCount = -1;
      
                for (var i = 0; i < palette.Count; i++)
                {
                    var prevContentState = (int[,]) game.Content.Clone();
                    ReColourCells(game, i);
                    var newCount = GetAdjacentCells(game, i).Count;
                    if (newCount > maxCount)
                    {
                        maxCount = newCount;
                        maxColorId = i;
                    }
                    game.SetContent(prevContentState);
                }
            }
            else
            {
                maxColorId = game.Content[userInput.ClickedPos.X, userInput.ClickedPos.Y];
           
            }
            var adjacentCellCount = ReColourCells(game, maxColorId);
            var result = game.GetDto();
            result.IsFinished = adjacentCellCount == game.SizeX * game.SizeY;
            result.Score = adjacentCellCount;
            return new ObjectResult(result);

            return new ObjectResult(
                ReColourCells(game, maxColorId));
        }

        private int ReColourCells(GameBoard game, int color)
        {
            var result = game.GetDto();
            var adjacentCells = GetAdjacentCells(game, game[new Vec(0, 0)]);
            adjacentCells.Add(new Vec(0, 0));
            foreach (var cell in result.Cells.Where(cell => adjacentCells.Contains(cell.Pos)))
            {
                cell.Type = game.Palette[color];
            }
            

            foreach (var adjacentCell in adjacentCells)
            {
                game.Content[adjacentCell.X, adjacentCell.Y] = color;
            }

            return GetAdjacentCells(game, game[new Vec(0, 0)]).Count + 1;
 
        }

        private IList<Vec> GetAdjacentCells(GameBoard game, int color)
        {
            return DFS.GetAdjacentCells(
                new Boolean[game.SizeX, game.SizeY],
                new Vec(0, 0), 
                game,
                color);
        }
    }
    
}