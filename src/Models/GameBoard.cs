using System;
using System.Collections.Generic;
using System.Text;
using thegame.Services;

namespace thegame.Models
{
    public class GameBoard
    {
        public IReadOnlyList<string> Palette { get; }
        public int[,] Content { get; }
        private readonly Guid id;

        public GameBoard(int sizeX, int sizeY, int[,] content, Guid id, IReadOnlyList<String> palette)
        {
            this.id = id;
            this.Palette = palette;
            SizeX = sizeX;
            SizeY = sizeY;
            this.Content = content;
        }

        public GameDto GetDto()
        {
            var cells = new CellDto[SizeX * SizeY];
            int index = 0;
            //rc.GetLength(0), src.GetLength(1)
            for (var i = 0; i < SizeX ; i++)
            for (var j = 0; j < SizeY; j++)
            {
                cells[index++] = new CellDto(
                    index.ToString(), 
                    new Vec(i, j),  
                    Palette[Content[i,j]], 
                    "", 
                    0 );
            }
            return new GameDto(cells, 
                false, 
                true, SizeX, 
                SizeY,id, 
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
                    return Content[vec.X, vec.Y];
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
                    Content[vec.X, vec.Y] = value;
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
