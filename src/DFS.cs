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
                if (!checkedCells[checkingCell.X, checkingCell.Y] && CheckCell(gameBoard, currentCell, checkingCell))
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

        public static Boolean CheckCell(GameBoard gameBoard, Vec currentCell, Vec futureCell)
        {
            return IsCellOnBoard(futureCell, gameBoard) && IsSameColor(gameBoard, currentCell, futureCell);
        }

        private static Boolean IsSameColor(GameBoard gameBoard, Vec firstCell, Vec secondCell)
        {
            return gameBoard[firstCell] == gameBoard[secondCell];
        }
        
        private static Boolean IsCellOnBoard(Vec currentCell, GameBoard gameBoard)
        {
            return CheckRange(currentCell.X - 1, 0, gameBoard.SizeX) && 
                   CheckRange(currentCell.Y - 1, 0, gameBoard.SizeY);
        }

        private static Boolean CheckRange(Int32 value, Int32 leftBorder, Int32 rightBorder)
        {
            return value >= leftBorder && value <= rightBorder;
        }
    }
}
