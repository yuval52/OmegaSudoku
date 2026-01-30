using OmegaSudoku.Util;

namespace OmegaSudoku.Board
{
    /// <summary>
    /// A class representing a Sudoku board.
    /// </summary>
    public class SudokuBoard
    {
        // The length of one side of the board
        private int _size;
        // The square root of the side length, used as square size
        private int _sizeRoot;
        // The values of the board
        private int[,] _board;

        // An array of bitmasks for values in a row
        private int[] _rowMasks;
        // An array of bitmasks for values in a column
        private int[] _columnMasks;
        // An array of bitmasks for values in a square
        private int[,] _squareMasks;

        /// <summary>
        /// Gets the size of a side of the board.
        /// </summary>
        /// <returns>The size of the board.</returns>
        public int GetSize()
        {
            return _size;
        }

        /// <summary>
        /// Gets the square root of the size of one side of the board, used for square dimensions.
        /// </summary>
        /// <returns>The square root of the size of the board.</returns>
        public int GetSizeRoot()
        {
            return _sizeRoot;
        }

        /// <summary>
        /// Gets the value of a cell at a specific row and column.
        /// </summary>
        /// <param name="i">The row of the cell.</param>
        /// <param name="j">The column of the cell.</param>
        /// <returns>The value of the cell.</returns>
        public int GetCell(int i, int j)
        {
            return _board[i, j];
        }

        /// <summary>
        /// Initializes a new empty board with the specified size.
        /// </summary>
        /// <param name="size">The size of the board.</param>
        public SudokuBoard(int size)
        {
            // Initiallize empty board with no constraints
            _size = size;
            _board = new int[size, size];
            _rowMasks = new int[size];
            _columnMasks = new int[size];
            _sizeRoot = (int)Math.Sqrt(size);
            _squareMasks = new int[_sizeRoot, _sizeRoot];
        }

        /// <summary>
        /// Loads the values of a board into the SudokuBoard object, and checks the board's intial validity.
        /// </summary>
        /// <param name="newBoard">An array of cell values.</param>
        /// <returns>The initial validity of the board.</returns>
        public bool LoadBoard(int[] newBoard)
        {
            // Assume array length was already checked to be correct
            bool valid = true;
            for (int i = 0; i < _size; i++) {
                for (int j = 0; j < _size; j++)
                {
                    // Fill in board matrix
                    _board[i, j] = newBoard[(i * _size) + j];
                    if (_board[i, j] != 0)
                    {
                        // Update masks with added number
                        if(!AddToRowMask(i, _board[i, j]))
                        {
                            // Couldn't add number to mask, invalid board
                            valid = false;
                        }
                        if (!AddToColumnMask(j, _board[i, j]))
                        {
                            // Couldn't add number to mask, invalid board
                            valid = false;
                        }
                        // Calculate coordinates of square containing cell
                        int squareI = i / _sizeRoot;
                        int squareJ = j / _sizeRoot;
                        if (!AddToSquareMask(squareI, squareJ, _board[i, j]))
                        {
                            // Couldn't add number to mask, invalid board
                            valid = false;
                        }
                    }
                }
            }
            // All values were entered successfuly
            return valid;
        }

        /// <summary>
        /// Gets the bitmask of a specified row. A 1 bit indicates that the number is present in the row.
        /// </summary>
        /// <param name="row">The index of the row.</param>
        /// <returns>A bitmask for the values in a row.</returns>
        public int GetRowMask(int row)
        {
            return _rowMasks[row];
        }

        /// <summary>
        /// Gets the bitmask of a specified column. A 1 bit indicates that the number is present in the column.
        /// </summary>
        /// <param name="col">The index of the column.</param>
        /// <returns>A bitmask for the values in a column.</returns>
        public int GetColumnMask(int col)
        {
            return _columnMasks[col];
        }

        /// <summary>
        /// Get the bitmask of a specified square. A 1 bit indicates that the number is present in the square.
        /// </summary>
        /// <param name="i">The row index of the square.</param>
        /// <param name="j">The column index of the square.</param>
        /// <returns>A bitmask for the values in a square.</returns>
        public int GetSquareMask(int i, int j)
        {
            return _squareMasks[i, j];
        }

        /// <summary>
        /// Returns a bitmask representing the possible values that can be placed in the specified cell. A 0 bit indicates that the number is possible, while a 1 bit indicates that the number is not possible.
        /// </summary>
        /// <param name="i">The row index of the cell.</param>
        /// <param name="j">The column index of the cell.</param>
        /// <returns>A bitmask for the possible values of a cell.</returns>
        public int GetCellMask(int i, int j)
        {
            int squareI = i / _sizeRoot;
            int squareJ = j / _sizeRoot;
            int mask = _rowMasks[i] | _columnMasks[j] | _squareMasks[squareI, squareJ];
            return mask;
        }

        /// <summary>
        /// Adds a number to the specified row's mask.
        /// </summary>
        /// <param name="i">The index of the row.</param>
        /// <param name="num">The number to add.</param>
        /// <returns>Whether the number was added succesfuly. If false, the number already existed in the row.</returns>
        public bool AddToRowMask(int i, int num)
        {
            if (SudokuUtil.IsNumberInMask(_rowMasks[i], num))
            {
                // Number is already in the mask
                return false;
            }

            _rowMasks[i] = SudokuUtil.AddNumberToMask(_rowMasks[i], num);
            // Successfuly added number to mask
            return true;
        }

        /// <summary>
        /// Adds a number to the specified column's mask.
        /// </summary>
        /// <param name="i">The index of the column.</param>
        /// <param name="num">The number to add.</param>
        /// <returns>Whether the number was added succesfuly. If false, the number already existed in the column.</returns>
        public bool AddToColumnMask(int i, int num)
        {
            if (SudokuUtil.IsNumberInMask(_columnMasks[i], num))
            {
                // Number is already in the mask
                return false;
            }

            _columnMasks[i] = SudokuUtil.AddNumberToMask(_columnMasks[i], num);
            // Successfuly added number to mask
            return true;
        }

        /// <summary>
        /// Adds a number to the specified square's mask.
        /// </summary>
        /// <param name="i">The index of the square's row.</param>
        /// <param name="j">The index of the square's column.</param>
        /// <param name="num">The number to add.</param>
        /// <returns>Whether the number was added succesfuly. If false, the number already existed in the square.</returns>
        public bool AddToSquareMask(int i, int j, int num)
        {
            if (SudokuUtil.IsNumberInMask(_squareMasks[i, j], num))
            {
                // Number is already in the mask
                return false;
            }

            _squareMasks[i, j] = SudokuUtil.AddNumberToMask(_squareMasks[i, j], num);
            // Successfuly added number to mask
            return true;
        }

        /// <summary>
        /// Removes a number from the specified row's mask.
        /// </summary>
        /// <param name="i">The index of the row.</param>
        /// <param name="num">The number to remove.</param>
        /// <returns>Whether the number was successfuly removed. If false, the number was not already in the row.</returns>
        public bool RemoveFromRowMask(int i, int num)
        {
            if (!SudokuUtil.IsNumberInMask(_rowMasks[i], num))
            {
                // Number isn't in the mask
                return false;
            }

            _rowMasks[i] = SudokuUtil.RemoveNumberFromMask(_rowMasks[i], num);
            // Successfuly removed number from mask
            return true;
        }

        /// <summary>
        /// Removes a number from the specified column's mask.
        /// </summary>
        /// <param name="i">The index of the column.</param>
        /// <param name="num">The number to remove.</param>
        /// <returns>Whether the number was succesfuly removed. If false, the number was not already in the column.</returns>
        public bool RemoveFromColumnMask(int i, int num)
        {
            if (!SudokuUtil.IsNumberInMask(_columnMasks[i], num))
            {
                // Number isn't in the mask
                return false;
            }

            _columnMasks[i] = SudokuUtil.RemoveNumberFromMask(_columnMasks[i], num);
            // Successfuly removed number from mask
            return true;
        }

        /// <summary>
        /// Removes a number from the specified square's mask.
        /// </summary>
        /// <param name="i">The row index of the square.</param>
        /// <param name="j">The column index of the square.</param>
        /// <param name="num">The number to remove.</param>
        /// <returns>Whether the number was successfuly removed. If false, the number was not already in the square.</returns>
        public bool RemoveFromSquareMask(int i, int j, int num)
        {
            if (!SudokuUtil.IsNumberInMask(_squareMasks[i, j], num))
            {
                // Number isn't in the mask
                return false;
            }

            _squareMasks[i, j] = SudokuUtil.RemoveNumberFromMask(_squareMasks[i, j], num);
            // Successfuly removed number from mask
            return true;
        }

        /// <summary>
        /// Places a number on the board at the specified row and column, updating the masks accordingly.
        /// </summary>
        /// <param name="i">The row of the cell.</param>
        /// <param name="j">The column of the cell.</param>
        /// <param name="num">The number to place.</param>
        /// <returns>Whether the number was placed succesfuly. If false, the number placement is not a valid move.</returns>
        public bool PlaceNumber(int i, int j, int num)
        {
            if (!AddToRowMask(i, num))
            {
                // Already in row
                return false;
            }
            if (!AddToColumnMask(j, num))
            {
                // Already in column
                return false;
            }
            int squareI = i / _sizeRoot;
            int squareJ = j / _sizeRoot;
            if (!AddToSquareMask(squareI, squareJ, num))
            {
                return false;
            }

            // Successfuly added number to board
            _board[i, j] = num;
            return true;
        }

        /// <summary>
        /// Removes a number from the board at the specified row and column, updating the masks accordingly.
        /// </summary>
        /// <param name="i">The row of the cell.</param>
        /// <param name="j">The column of the cell.</param>
        /// <param name="num">The number to place.</param>
        /// <returns>Whether the number was placed successfuly.</returns>
        public bool UndoPlacement(int i, int j, int num)
        {
            if (!RemoveFromRowMask(i, num))
            {
                return false;
            }
            if (!RemoveFromColumnMask(j, num))
            {
                return false;
            }
            int squareI = i / _sizeRoot;
            int squareJ = j / _sizeRoot;
            if (!RemoveFromSquareMask(squareI, squareJ, num))
            {
                return false;
            }

            // Successfuly removed number from board
            _board[i, j] = 0;
            return true;
        }

        /// <summary>
        /// Print the board to the console in a formatted way.
        /// </summary>
        public void PrintBoard()
        {
            // Create a string of a horizontal divider
            int totalWidth = _size * 4 + 1;
            string horizontalDivider = new string('-', totalWidth);

            // Print the top line of the board
            Console.WriteLine(horizontalDivider);

            for (int i = 0; i < _size; i++)
            {
                // Print the left border of the board
                Console.Write("|");

                for (int j = 0; j < _size; j++)
                {
                    int value = _board[i, j];
                    // Replace zeros with spaces for empty cells
                    string toPrint = value == 0 ? " " : value.ToString();

                    Console.Write($" {toPrint} ");

                    if ((j + 1) % _sizeRoot == 0)
                    {
                        // If the line is the border of a square, print a white line
                        Console.Write("|");
                    }
                    else
                    {
                        // If the line is not the border of a square, print a darker line
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine();

                if ((i + 1) % _sizeRoot == 0)
                {
                    // If the line is the border of a square, print a white line
                    Console.WriteLine(horizontalDivider);
                }
                else
                {
                    // If the line is not the border of a square, print a darker line
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(horizontalDivider);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
        }

        /// <summary>
        /// Converts the board to a string representation in the same format as the input.
        /// </summary>
        /// <returns>A string representing the board.</returns>
        public override string ToString()
        {
            string boardString = "";

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    // Append every number to the string
                    boardString += _board[i, j];
                }
            }

            return boardString;
        }

    }
}
