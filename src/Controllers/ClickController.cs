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
            var game = TestData.AGameDto(userInput.ClickedPos ?? new Vec(1, 1));
            if (userInput.ClickedPos != null)
            {
                IReadOnlyList<String> palette = ColorPaletteGenerator.CreateHexPalette();
                Int32[,] cells = game.Cells.ToIndexArray(palette.ToArray());
                List<Vec> adjacentCells = DFS.GetAdjacentCells(
                    new Boolean[game.Width, game.Height],
                    userInput.ClickedPos,
                    new GameBoard(game.Width, game.Height,
                        cells, palette),
                    cells[0, 0]);

                foreach (CellDto cell in game.Cells.Where(cell => adjacentCells.Contains(cell.Pos)))
                {
                    cell.Type = palette[cells[userInput.ClickedPos.X, userInput.ClickedPos.Y]];
                }
            }
            return new ObjectResult(game);
        }
    }
}