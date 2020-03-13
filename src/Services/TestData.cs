using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 2;
            var height = 2;
            var testBoard = new GameBoard(2, 2, new int[,] { { 0, 1 }, { 1, 1 } });
            return new GameDto(testBoard, true, true, width, height, Guid.Empty, movingObjectPosition.X == 0, movingObjectPosition.Y);
        }
    }
}