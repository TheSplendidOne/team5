using System;
using System.Collections.Generic;
using System.Text;

namespace thegame.Models
{
    class GameBoard
    {
        public GameBoard(int sizeX, int sizeY, int[,] content)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            Content = content;
        }

        public int GetColorOfCell(Vec vec)
        {
            if (0 <= vec.X && vec.X < SizeX
             && 0 <= vec.Y && vec.Y < SizeY)
            {
                return Content[vec.X, vec.Y];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int SizeX;
        public int SizeY;
        public int[,] Content;
    }
}
