using OmegaSudoku.Board;
using OmegaSudoku.Exceptions;
using OmegaSudoku.Interface;

namespace OmegaSudoku.Solvers
{
    /// <summary>
    /// A static class that initiates the Sudoku solving process.
    /// </summary>
    public static class SudokuSolver
    {
        /// <summary>
        /// The main function to solve a Sudoku puzzle given as a string.
        /// </summary>
        /// <param name="sudokuString">A string representing the Sudoku board to solve.</param>
        /// <returns>A string representing the solved state of the board.</returns>
        /// <exception cref="InvalidBoardException">An exception that is thrown when the initial board is invalid.</exception>
        /// <exception cref="UnsolvableBoardException">An exception that is thrown when the board is unsolvable.</exception>
        public static string SolveSudoku(string sudokuString)
        {
            // Convert the input string to an array
            int[] sudokuArr = InputValidation.ConvertInput(sudokuString);

            // Determine the size of the board
            int arrLength = sudokuArr.Length;
            int boardSize = (int)Math.Sqrt(arrLength);

            // Create new sudoku board and load the array into it
            SudokuBoard board = new SudokuBoard(boardSize);
            bool valid = board.LoadBoard(sudokuArr);

            // Print the initial board
            Console.WriteLine("Initial board:");
            board.PrintBoard();

            if (!valid)
            {
                // Board is invalid
                throw new InvalidBoardException();
            }

            // Create the backtracking solver object
            BacktrackingSolver solver = new BacktrackingSolver(board);

            // Messure the time before solving
            DateTime before = DateTime.Now;

            // Run the solver algorithm
            bool solved = solver.SolveBacktracking();

            // Messure the time after solving
            DateTime after = DateTime.Now;

            // Calculate solving time
            TimeSpan time = after - before;

            if (!solved)
            {
                // Board is unsolvable
                throw new UnsolvableBoardException();
            }

            // Print the solved board
            Console.WriteLine("Solved board:");
            board.PrintBoard();

            // Print the solve time
            Console.WriteLine("\nSolve time:");
            Console.WriteLine(time.ToString(@"m\:ss\.fffff"));
            Console.WriteLine();

            // Return solved board in the same format as the input board
            return board.ToString();
        }

        /// <summary>
        /// Solves a Sudoku puzzle given as a string without any console output for testing.
        /// </summary>
        /// <param name="sudokuString">A string representing the Sudoku board to solve.</param>
        /// <returns>A string representing the solved state of the board.</returns>
        /// <exception cref="InvalidBoardException">An exception that is thrown when the initial board is invalid.</exception>
        /// <exception cref="UnsolvableBoardException">An exception that is thrown when the board is unsolveable.</exception>
        public static string TestSolver(string sudokuString)
        {
            // Convert the input string to an array
            int[] sudokuArr = InputValidation.ConvertInput(sudokuString);

            // Create new sudoku board and load the array into it
            SudokuBoard board = new SudokuBoard(9);
            bool valid = board.LoadBoard(sudokuArr);

            if (!valid)
            {
                // Board is invalid
                throw new InvalidBoardException();
            }

            // Create the backtracking solver object
            BacktrackingSolver solver = new BacktrackingSolver(board);

            // Run the solver algorithm
            bool solved = solver.SolveBacktracking();

            if (!solved)
            {
                // Board is unsolveable
                throw new UnsolvableBoardException();
            }

            // Return solved board in the same format as the input board
            return board.ToString();
        }
    }
}
