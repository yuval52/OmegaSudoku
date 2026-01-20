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
            // Use non backtracking strategies first
            int changes = StrategySolver.ApplyStrategies(_board, movesStack);

            // The next cell to backtrack through
            int nextRow;
            int nextColumn;
            (nextRow, nextColumn) = FindNextCell();

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

            // Branch has no solution, move back up
            // Undo changes done at the start of this call
            UndoMoves(changes);
            return false;
        }

        private (int rowIndex, int columnIndex) FindNextCell()
        {

            int bestRow = -1;
            int bestColumn = -1;
            int minOptions = _board.GetSize();

            for (int i = 0; i < _board.GetSize(); i++)
            {
                for (int j = 0; j < _board.GetSize(); j++)
                {
                    if (_board.GetCell(i, j) == 0)
                    {
                        // Found empty cell
                        int cellMask = _board.GetCellMask(i, j);
                        int options = SudokuUtil.NumberOfOptions(cellMask, _board.GetSize());
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

        private bool UndoMoves(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (!UndoMove())
                {
                    return false;
                }
            }
            return true;
        }
        private bool UndoMove()
        {
            // Undo the last move on the stack
            int[] move = movesStack.Pop();
            return _board.UndoPlacement(move[0], move[1], move[2]);
        }

    }
}
