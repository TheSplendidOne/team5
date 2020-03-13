using System;
using thegame.Models;

namespace thegame.Services
{
    public class TestData
    {
        public static GameDto AGameDto(Vec movingObjectPosition, int complexityLevel)
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
            var testBoard = new GameBoard(width, height,  boardData, colorCount);
            var result = testBoard.GetDto();
            return result;
        }
    }
}