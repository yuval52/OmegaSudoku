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
            //changes += OnlyViableCellInRow(board, movesStack);

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

        public static int OnlyViableCellInRow(SudokuBoard board, Stack<int[]> movesStack)
        {
            // Find rows where only one cell has a number available and fill it
            int changes = 0;
            for (int i = 0; i < board.GetSize(); i++)
            {
                // Find amount of times numbers are possible in row
                int[] possibleCellsForNumbers = new int[board.GetSize()];
                // For every cell in the row count the possibilities
                for (int j = 0; j < board.GetSize(); j++)
                {
                    int cellMask = board.GetCellMask(i, j);
                    for (int num = 0; num < board.GetSize(); num++)
                    {
                        int numMask = 1 << num;
                        if (((cellMask & numMask) == 0) && (board.GetCell(i, j) != 0))
                        {
                            // Number is available in cell
                            possibleCellsForNumbers[num]++;
                        }
                    }
                }

                for (int num = 1; num <= board.GetSize(); num++)
                {
                    if (possibleCellsForNumbers[num - 1] == 1)
                    {
                        int numMask = 1 << (num - 1);
                        // A number is only possible in one cell in the row
                        for (int j = 0; j < board.GetSize(); j++)
                        {
                            int cellMask = board.GetCellMask(i, j);
                            if (((cellMask & numMask) == 0) && (board.GetCell(i, j) != 0))
                            {
                                // Number is available in cell
                                board.PlaceNumber(i, j, num);
                                // Add change to stack
                                int[] move = [i, j, num];
                                Console.WriteLine(i.ToString() + ", " + j.ToString() + ", " + (num).ToString());
                                movesStack.Push(move);
                                changes++;
                                break;
                            }
                        }
                    }
                }
            }
            // Return the number of changes this function made to the board
            return changes;
        }

    }
}
