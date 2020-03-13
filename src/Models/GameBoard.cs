using System;
using System.Collections.Generic;
using System.Text;
using thegame.Services;

namespace thegame.Models
{
    public class GameBoard
    {
        private readonly IReadOnlyList<string> palette;
        private readonly int[,] content;
        public GameBoard(int sizeX, int sizeY, int[,] content, IReadOnlyList<String> palette)
        {
            this.palette = palette;
            SizeX = sizeX;
            SizeY = sizeY;
            this.content = content;
        }

        public GameDto GetDto()
        {
            var cells = new CellDto[SizeX * SizeY];
            int index = 0;
            //rc.GetLength(0), src.GetLength(1)
            for (var i = 0; i < SizeX ; i++)
            for (var j = 0; i < SizeY; j++)
            {
                cells[index++] = new CellDto(
                    "", 
                    new Vec(i, j),  
                    palette[content[i,j]], 
                    "", 
                    0 );
            }
            return new GameDto(cells, 
                false, 
                true, SizeX, 
                SizeY, new Guid(), 
                false, 
                0);
        }

        public int this[Vec vec]
        {
            get
            {
                if (0 <= vec.X && vec.X < SizeX
                               && 0 <= vec.Y && vec.Y < SizeY)
                {
                    return content[vec.X, vec.Y];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (0 <= vec.X && vec.X < SizeX
                               && 0 <= vec.Y && vec.Y < SizeY)
                {
                    content[vec.X, vec.Y] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int SizeX;
        public int SizeY;
    }
}
