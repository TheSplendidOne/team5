using System;
using System.Collections.Generic;
using System.Text;
using thegame.Models;

namespace thegame
{
    public static class DFS
    {
        public static List<Vec> GetAdjacentCells(Boolean[,] checkedCells, Vec currentCell, GameBoard gameBoard, Int32 searchingCellsColorIndex)
        {
            checkedCells[currentCell.X, currentCell.Y] = true;
            List<Vec> sameColoredCells = new List<Vec>();

            void CheckCellAndAdd(Vec checkingCell)
            {
                if (CheckCell(gameBoard, currentCell, checkingCell) && !checkedCells[checkingCell.X, checkingCell.Y])
                {
                    sameColoredCells.Add(checkingCell);
                    sameColoredCells.AddRange(GetAdjacentCells(checkedCells, checkingCell, gameBoard, searchingCellsColorIndex));
                }
            }

            CheckCellAndAdd(new Vec(currentCell.X - 1, currentCell.Y));
            CheckCellAndAdd(new Vec(currentCell.X, currentCell.Y - 1));
            CheckCellAndAdd(new Vec(currentCell.X + 1, currentCell.Y));
            CheckCellAndAdd(new Vec(currentCell.X, currentCell.Y + 1));

            return sameColoredCells;
        }

        private static Boolean CheckCell(GameBoard gameBoard, Vec currentCell, Vec futureCell)
        {
            return IsCellOnBoard(futureCell, gameBoard) && IsSameColor(gameBoard, currentCell, futureCell);
        }

        private static Boolean IsSameColor(GameBoard gameBoard, Vec firstCell, Vec secondCell)
        {
            return gameBoard[firstCell] == gameBoard[secondCell];
        }
        
        private static Boolean IsCellOnBoard(Vec currentCell, GameBoard gameBoard)
        {
            return CheckRange(currentCell.X, 0, gameBoard.SizeX - 1) && 
                   CheckRange(currentCell.Y, 0, gameBoard.SizeY - 1);
        }

        private static Boolean CheckRange(Int32 value, Int32 leftBorder, Int32 rightBorder)
        {
            return value >= leftBorder && value <= rightBorder;
        }
    }
}
