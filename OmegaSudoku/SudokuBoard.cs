using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    public class SudokuBoard
    {
        // The length of one side of the board
        private int _size;
        // The values of the board
        public int[,] _board;

        // An array of bitmasks for values in a row
        private int[] _rowConstraints;
        // An array of bitmasks for values in a column
        private int[] _colummnConstraints;
        // An array of bitmasks for values in a square
        private int[,] _squareConstraints;

        public SudokuBoard(int size)
        {
            // Initiallize empty board with no constraints
            _size = size;
            _board = new int[size, size];
            _rowConstraints = new int[size];
            _colummnConstraints = new int[size];
            int sqrt = (int)Math.Sqrt(size);
            _squareConstraints = new int[sqrt, sqrt];
        }

        public void LoadBoard(int[] newBoard)
        {
            // For now assume array length was already checked to be correct
            for (int i = 0; i < _size; i++) {
                for (int j = 0; j < _size; j++)
                {
                    // Fill in board matrix
                    _board[i, j] = newBoard[(i *  _size) + j];
                }
            }
        }
    }
}
