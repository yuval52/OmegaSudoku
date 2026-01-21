using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    public static class StrategySolver
    {

        public static int ApplyStrategies(SudokuBoard board, Stack<int[]> movesStack)
        {
            int changes = 0;

            // Fill cells that only have one option
            changes += FillSingleOption(board, movesStack);

            // Find rows where only one cell has a number available and fill it
            changes += HiddenSingelsRow(board, movesStack);

            // Find columns where only one cell has a number available and fill it
            changes += HiddenSingelsColumn(board, movesStack);

            // Return the number of changes this function made to the board
            return changes;
        }

        public static int FillSingleOption(SudokuBoard board, Stack<int[]> movesStack)
        {
            // Fill cells that only have one option
            int changes = 0;
            for (int i = 0; i < board.GetSize(); i++)
            {
                for (int j = 0; j < board.GetSize(); j++)
                {
                    if (board.GetCell(i, j) == 0)
                    {
                        // Found empty cell
                        int cellMask = board.GetCellMask(i, j);
                        int options = SudokuUtil.NumberOfOptions(cellMask, board.GetSize());

                        if (options == 1)
                        {
                            // A cell with a single possible number
                            for (int k = 1; k < board.GetSize() + 1; k++)
                            {
                                
                                int numMask = 1 << (k - 1);
                                if ((cellMask & numMask) == 0)
                                {
                                    // Fill the only possible number
                                    board.PlaceNumber(i, j, k);
                                    // Add change to stack
                                    int[] move = [i, j, k];
                                    movesStack.Push(move);
                                    changes++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            // Return the number of changes this function made to the board
            return changes;
        }

        public static int HiddenSingelsRow(SudokuBoard board, Stack<int[]> movesStack)
        {
            // Find rows where only one cell has a number available and fill it
            int changes = 0;

            // Check each row
            for (int i = 0; i < board.GetSize(); i++)
            {
                // For each number check how many cells can contain it
                for (int num = 1; num < board.GetSize() + 1; num++)
                {
                    int possibleCells = 0;
                    int lastColumn = -1;

                    // Scan every cell in the current row
                    for (int j = 0; j < board.GetSize(); j++)
                    {
                        // Only check empty cells
                        if (board.GetCell(i, j) == 0)
                        {
                            int cellMask = board.GetCellMask(i, j);
                            int numMask = 1 << (num - 1);
                            if ((cellMask & numMask) == 0)
                            {
                                // Number is possible in this cell
                                possibleCells++;
                                lastColumn = j;
                            }
                        }
                    }

                    if (possibleCells == 1)
                    {
                        // The number is only possible in one cell in the row, fill it
                        board.PlaceNumber(i, lastColumn, num);

                        // Add change to stack
                        int[] move = [i, lastColumn, num];
                        movesStack.Push(move);
                        changes++;
                    }
                }
            }

            // Return the number of changes this function made to the board
            return changes;
        }

        public static int HiddenSingelsColumn(SudokuBoard board, Stack<int[]> movesStack)
        {
            // Find cokumns where only one cell has a number available and fill it
            int changes = 0;

            // Check each column
            for (int j = 0; j < board.GetSize(); j++)
            {
                // For each number check how many cells can contain it
                for (int num = 1; num < board.GetSize() + 1; num++)
                {
                    int possibleCells = 0;
                    int lastRow = -1;

                    // Scan every cell in the current column
                    for (int i = 0; i < board.GetSize(); i++)
                    {
                        // Only check empty cells
                        if (board.GetCell(i, j) == 0)
                        {
                            int cellMask = board.GetCellMask(i, j);
                            int numMask = 1 << (num - 1);
                            if ((cellMask & numMask) == 0)
                            {
                                // Number is possible in this cell
                                possibleCells++;
                                lastRow = i;
                            }
                        }
                    }

                    if (possibleCells == 1)
                    {
                        // The number is only possible in one cell in the column, fill it
                        board.PlaceNumber(lastRow, j, num);

                        // Add change to stack
                        int[] move = [lastRow, j, num];
                        movesStack.Push(move);
                        changes++;
                    }
                }
            }

            // Return the number of changes this function made to the board
            return changes;
        }

    }
}
