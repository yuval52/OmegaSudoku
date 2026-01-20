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
        private SudokuBoard _board;
        private Stack<int[]> movesStack;
        public BacktrackingSolver(SudokuBoard board)
        {
            _board = board;
            movesStack = new Stack<int[]>();
        }

        public bool SolveBacktracking()
        {
            // Start the backtracking
            return Backtrack();
        }

        private bool Backtrack()
        {
            // The next cell to backtrack through
            int nextRow;
            int nextColumn;
            (nextRow, nextColumn) = FindNextCell(_board);

            if (nextRow == -1 && nextColumn == -1)
            {
                // No empty cells, board solved
                return true;
            }

            int cellMask = _board.GetCellMask(nextRow, nextColumn);

            for (int i = 1; i <= _board.GetSize(); i++)
            {
                // Create a mask of the number to try
                int numMask = 1 << (i - 1);
                if ((cellMask & numMask) == 0)
                {
                    // Number is available for cell
                    if (PerformMove(nextRow, nextColumn, i))
                    {
                        // Placed number
                        // Backtrack again
                        bool solved = Backtrack();
                        if (solved)
                        {
                            // A solution was found in this branch

                            return true;
                        }
                        // Solution was not found in this branch
                        // Undo number placement before trying next number
                        UndoMove();
                    }

                }
            }
            return false;
        }

        private (int rowIndex, int columnIndex) FindNextCell(SudokuBoard board)
        {

            int bestRow = -1;
            int bestColumn = -1;
            int minOptions = board.GetSize();

            for (int i = 0; i < board.GetSize(); i++)
            {
                for (int j = 0; j < board.GetSize(); j++)
                {
                    if (board.GetCell(i, j) == 0)
                    {
                        // Found empty cell
                        int cellMask = board.GetCellMask(i, j);
                        int options = NumberOfOptions(cellMask, board.GetSize());
                        if (options < minOptions)
                        {
                            // Cell has the least possible numbers so far
                            minOptions = options;
                            bestRow = i;
                            bestColumn = j;
                        }
                    }
                }
            }

            // Return the cell with the least numbers possible
            return (bestRow, bestColumn);
        }

        private bool PerformMove(int row, int column, int num)
        {
            // Push the move's info to the stack
            int[] move = [row, column, num];
            movesStack.Push(move);

            return _board.PlaceNumber(row, column, num);
        }

        private bool UndoMove()
        {
            // Undo the last move on the stack
            int[] move = movesStack.Pop();
            return _board.UndoPlacement(move[0], move[1], move[2]);
        }

        private int NumberOfOptions(int mask, int size)
        {
            int countSetBits = 0;

            while (mask > 0)
            {
                // Count how many bits are set to 1
                mask &= (mask - 1);
                countSetBits++;
            }

            // The number of options is the bits that arent 1
            return size - countSetBits;
        }

    }
}
