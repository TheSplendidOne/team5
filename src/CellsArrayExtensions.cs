using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thegame.Models;
using thegame.Services;

namespace thegame
{
    public static class CellsArrayExtensions
    {
        public static int[,] ToIndexArray(this CellDto[] cells, String[] palette)
        {
            int axisX = cells.Select<CellDto, int>(x => x.Pos.X).Max();
            int axisY = cells.Select<CellDto, int>(y => y.Pos.Y).Max();

            int[,] indexArray = new int[axisX, axisY];

            foreach (CellDto cell in cells)
            {
                indexArray[cell.Pos.X, cell.Pos.Y] = ColorPaletteGenerator.IndexInPalette(palette, cell.Content);
            }

            return indexArray;
        }
    }
}
