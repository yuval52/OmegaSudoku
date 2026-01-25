using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmegaSudoku.Exceptions;

namespace OmegaSudoku
{
    public static class SudokuSolver
    {
        public static string SolveSudoku(string sudokuString)
        {
            // Convert the input string to an array
            int[] sudokuArr = InputValidation.ConvertInput(sudokuString);

            // Create new sudoku board and load the array into it
            SudokuBoard board = new SudokuBoard(9);
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
                // Board is unsolveable
                // TODO: throw custom exception
                return "";
            }

            // Print the solved board
            Console.WriteLine("Solved board:");
            board.PrintBoard();

            // Print the solve time
            Console.WriteLine("\nSolve time:");
            Console.WriteLine(time.ToString());
            Console.WriteLine();

            // Temporary return
            // Will return solved board in the same format as the input board
            return "";
        }
    }
}
