using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition)
        {
            var width = 10;
            var height = 10;
            var colorCount = 6;

            var boardData = RandomFieldGenerator.Create(width, height, colorCount);
            var testBoard = new GameBoard(2, 2,  boardData, colorCount);
            return testBoard.GetDto();
        }
    }
}