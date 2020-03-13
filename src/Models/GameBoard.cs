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

        public int SizeX;
        public int SizeY;
        public int[,] Content;
    }
}
