using OmegaSudoku.Util;

namespace OmegaSudoku.Board
{
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

        public int GetSize()
        {
            return _size;
        }

        public int GetSizeRoot()
        {
            return _sizeRoot;
        }

        public int GetCell(int i, int j)
        {
            return _board[i, j];
        }

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

        public bool LoadBoard(int[] newBoard)
        {
            // Assume array length was already checked to be correct
            bool valid = true;
            for (int i = 0; i < _size; i++) {
                for (int j = 0; j < _size; j++)
                {
                    // Fill in board matrix
                    _board[i, j] = newBoard[i *  _size + j];
                    if (_board[i, j] != 0)
                    {
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
                        // Calculate square coordinates of cell
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

        public int GetRowMask(int row)
        {
            // Return the bitmask of the specified row
            return _rowMasks[row];
        }

        public int GetColumnMask(int col)
        {
            // Return the bitmask of the specified column
            return _columnMasks[col];
        }

        public int GetSquareMask(int i, int j)
        {
            // Return the bitmask of the specified square (by the coordinates of the square)
            return _squareMasks[i, j];
        }

        public int GetCellMask(int i, int j)
        {
            // Return a bitmask of possible numbers for one cell. 0 is possible, 1 is not possible
            int squareI = i / _sizeRoot;
            int squareJ = j / _sizeRoot;
            int mask = _rowMasks[i] | _columnMasks[j] | _squareMasks[squareI, squareJ];
            return mask;
        }

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

        public bool RemoveFromRowMask(int i, int num)
        {
            int numMask = 1 << num - 1;
            if ((_rowMasks[i] & numMask) == 0)
            {
                // Number isn't in the mask
                return false;
            }

            _rowMasks[i] &= ~numMask;
            // Successfuly removed number from mask
            return true;
        }

        public bool RemoveFromColumnMask(int i, int num)
        {
            int numMask = 1 << num - 1;
            if ((_columnMasks[i] & numMask) == 0)
            {
                // Number isn't in the mask
                return false;
            }

            _columnMasks[i] &= ~numMask;
            // Successfuly removed number from mask
            return true;
        }

        public bool RemoveFromSquareMask(int i, int j, int num)
        {
            int numMask = 1 << num - 1;
            if ((_squareMasks[i, j] & numMask) == 0)
            {
                // Number isn't in the mask
                return false;
            }

            _squareMasks[i, j] &= ~numMask;
            // Successfuly removed number from mask
            return true;
        }

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

        public void PrintBoard()
        {
            int totalWidth = _size * 4 + 1;
            string horizontalDivider = new string('-', totalWidth);

            Console.WriteLine(horizontalDivider);

            for (int i = 0; i < _size; i++)
            {
                Console.Write("|");

                for (int j = 0; j < _size; j++)
                {
                    int value = _board[i, j];
                    string toPrint = value == 0 ? " " : value.ToString();

                    Console.Write($" {toPrint} ");

                    if ((j + 1) % _sizeRoot == 0)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine();

                if ((i + 1) % _sizeRoot == 0)
                {
                    Console.WriteLine(horizontalDivider);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(horizontalDivider);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }
        }

        public override string ToString()
        {
            // Convert the board into string representation
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
