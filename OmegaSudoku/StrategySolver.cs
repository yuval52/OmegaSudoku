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

            // Return how many board changes this function made
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
                                }
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
