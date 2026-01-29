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

            // Find squares where only one cell has a number available and fill it
            // Of note, seems to slow down the solving overall for some boards and only mildly speed up for others, re-enabled due to testing
            changes += HiddenSinglesSquare(board, movesStack);

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
                int rowMask = board.GetRowMask(i);

                // For each number check how many cells can contain it
                for (int num = 1; num < board.GetSize() + 1; num++)
                {
                    int numMask = 1 << (num - 1);
                    // Check if number is already in the row
                    if ((rowMask & numMask) != 0)
                    {
                        // Skip the number
                        continue;
                    }

                    int possibleCells = 0;
                    int lastColumn = -1;

                    // Scan every cell in the current row
                    for (int j = 0; j < board.GetSize(); j++)
                    {
                        // Only check empty cells
                        if (board.GetCell(i, j) == 0)
                        {
                            int cellMask = board.GetCellMask(i, j);
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
                int columnMask = board.GetColumnMask(j);

                // For each number check how many cells can contain it
                for (int num = 1; num < board.GetSize() + 1; num++)
                {
                    int numMask = 1 << (num - 1);
                    // Check if number is already in the column
                    if ((columnMask & numMask) != 0)
                    {
                        // Skip the number
                        continue;
                    }

                    int possibleCells = 0;
                    int lastRow = -1;

                    // Scan every cell in the current column
                    for (int i = 0; i < board.GetSize(); i++)
                    {
                        // Only check empty cells
                        if (board.GetCell(i, j) == 0)
                        {
                            int cellMask = board.GetCellMask(i, j);

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

        public static int HiddenSinglesSquare(SudokuBoard board, Stack<int[]> movesStack)
        {
            // Find squares where only one cell has a number available and fill it
            int changes = 0;

            // Check each square
            for (int square = 0; square < board.GetSize(); square++)
            {
                // Calculate the coordinates of the square
                int squareRow = square / board.GetSizeRoot();
                int squareCol = square % board.GetSizeRoot();

                // Calculate the position on the board of the start of the square
                int startRow = squareRow * board.GetSizeRoot();
                int startCol = squareCol * board.GetSizeRoot();

                int squareMask = board.GetSquareMask(squareRow, squareCol);

                // For each number check how many cells can contain it
                for (int num = 1; num < board.GetSize() + 1; num++)
                {
                    int numMask = 1 << (num - 1);
                    // Check if number is already in the square
                    if ((squareMask & numMask) != 0)
                    {
                        // Skip the number
                        continue;
                    }

                    int possibleCells = 0;
                    int lastRow = -1;
                    int lastCol = -1;

                    // Scan every cell in the current square
                    for (int i = startRow; i < startRow + board.GetSizeRoot(); i++)
                    {
                        for (int j = startCol; j < startCol + board.GetSizeRoot(); j++)
                        {
                            // Only check empty cells
                            if (board.GetCell(i, j) == 0)
                            {
                                int cellMask = board.GetCellMask(i, j);

                                if ((cellMask & numMask) == 0)
                                {
                                    // Number is possible in this cell
                                    possibleCells++;
                                    lastRow = i;
                                    lastCol = j;
                                }
                            }
                        }    
                    }

                    if (possibleCells == 1)
                    {
                        // The number is only possible in one cell in the square, fill it
                        board.PlaceNumber(lastRow, lastCol, num);

                        // Add change to stack
                        int[] move = [lastRow, lastCol, num];
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
