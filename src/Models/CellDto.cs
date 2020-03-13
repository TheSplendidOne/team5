using thegame.Services;
using System.Linq;

namespace thegame.Models
{
    public class CellDto
    {
        /// <summary>
        /// Frontend animate transition of the cell from old to new state.
        /// </summary>
        /// <param name="id">Id is used to identificate cell to apply right animation</param>
        /// <param name="pos">Logical position of the cell in the game grid. Upper left corner is `new Vec(0, 0)`</param>
        /// <param name="type">Frontend apply images and other styling to the cell according to this type</param>
        /// <param name="content">Frontend can put this text in the cell</param>
        /// <param name="zIndex">Frontend render cells with higher zIndex above cells with lower zIndex</param>
        public CellDto(string id, Vec pos, string type, string content, int zIndex)
        {
            Id = id;
            Pos = pos;
            Type = type;
            Content = content;
            ZIndex = zIndex;
        }

        public int[,] ToIndexArray(this CellDto[] cells, ColorPaletteGenerator palette)
        {
            int axisX = cells.Select<CellDto, int>(x => x.Pos.X).Max();
            int axisY = cells.Select<CellDto, int>(y => y.Pos.Y).Max();

            int[,] indexArray = new int[axisX, axisY];

            foreach (CellDto cell in cells)
            {
                indexArray[cell.Pos.X, cell.Pos.Y] = palette.IndexInPalette(cell.Content);
            }

            return indexArray;
        }

        public string Id;
        public Vec Pos;
        public int ZIndex;
        public string Type;
        public string Content;
    }
}