using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {

        [HttpPost]
        public IActionResult Index([FromBody]int index)
        {
            var guid = Guid.NewGuid();
            var newGame = CreateGame(guid, index);
            GamesRepo.Games.Add(guid, newGame);
            return new ObjectResult(newGame.GetDto());
        }
        public static GameBoard CreateGame(Guid guid, int complexityLevel)
            {
                int width, height, colorCount;
                switch (complexityLevel)
                {
                    case 2:
                        width = 20;
                        height = 20;
                        colorCount = 12;
                        break;
                    case 1:
                        width = 15;
                        height = 15;
                        colorCount = 9;
                        break;
                    case 0:
                    default:
                        width = 10;
                        height = 10;
                        colorCount = 6;
                        break;
                }

                var boardData = RandomFieldGenerator.Create(width, height, colorCount);
                return new GameBoard(width, height, boardData, guid, ColorPaletteGenerator.CreateHexPalette(colorCount));
            }
    }
}

