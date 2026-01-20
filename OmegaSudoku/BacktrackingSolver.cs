using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OmegaSudoku
{
    public class BacktrackingSolver
    {
        private SudokuBoard _originalBoard;
        public BacktrackingSolver(SudokuBoard board)
        {
            _originalBoard = board;
        }

        public bool SolveBacktracking()
        {
            // Start thr backtracking with the original board
            return Backtrack(_originalBoard);
        }

        private bool Backtrack(SudokuBoard board)
        {
            SudokuBoard cloneBoard = (SudokuBoard)board.Clone();
            // The next cell to backtrack through
            int nextRow;
            int nextColumn;
            (nextRow, nextColumn) = FindNextCell(cloneBoard);

            if (nextRow == -1 && nextColumn == -1)
            {
                // No empty cells, board solved
                return true;
            }

            int cellMask = cloneBoard.GetCellMask(nextRow, nextColumn);

            for (int i = 1; i <= cloneBoard.GetSize(); i++)
            {
                // Create a mask of the number to try
                int numMask = 1 << (i - 1);
                if ((cellMask & numMask) == 0)
                {
                    // Number is available for cell
                    if (cloneBoard.PlaceNumber(nextRow, nextColumn, i))
                    {
                        // Placed number
                        // Backtrack again
                        //Console.WriteLine(nextRow.ToString() + ", " +  nextColumn.ToString() + ", num: " + i.ToString());
                        bool solved = Backtrack(cloneBoard);
                        if (solved)
                        {
                            // A solution was found in this branch
                            // This number placement is good, place number on original board
                            _originalBoard.PlaceNumber(nextRow, nextColumn, i);
                            return true;
                        }
                        // Solution was not found in this branch
                        // Remove number placement before trying next number
                        cloneBoard.UndoPlacement(nextRow, nextColumn, i);
                    }

                }
            }
            return false;
        }

        private (int rowIndex, int columnIndex) FindNextCell(SudokuBoard board)
        {
            for (int i = 0; i < board.GetSize(); i++)
            {
                for (int j = 0; j < board.GetSize(); j++)
                {
                    if (board.GetCell(i, j) == 0)
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }

    }
}
