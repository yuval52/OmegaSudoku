using OmegaSudoku.Exceptions;
using OmegaSudoku.Solvers;
using OmegaSudoku.Tests;

namespace OmegaSudoku.Interface
{
    /// <summary>
    /// A static class that handles the user interface for the Sudoku solver.
    /// </summary>
    public static class UserInterface
    {
        /// <summary>
        /// Runs the Sudoku solver user interface once.
        /// </summary>
        /// <returns>The string representation of the solved Sudoku board inputted by the user.</returns>
        public static string RunSudokuSolver()
        {
            // Display the insturctions interface
            ShowInterface();

            // Wait for input
            string input = Console.ReadLine();

            Console.WriteLine();

            if (input.Equals("quit"))
            {
                return "quit";
            }

            if (input.Equals("test"))
            {
                TestInterface();
                return "test";
            }

            Console.Clear();
            Console.WriteLine("Solving sudoku:");
            Console.WriteLine(input + "\n");


            // Run the solver
            string result = SudokuSolver.SolveSudoku(input);

            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();

            return result;
        }

        /// <summary>
        /// Opens the test interface to run a large amount of Sudokus from a dataset.
        /// </summary>
        /// <exception cref="InputIsNotANumberException">An exception that is thrown when the input is not a number.</exception>
        /// <exception cref="InputOutOfRangeException">An exception that is thrown when the input is not in the range of numbers possible for the test.</exception>
        public static void TestInterface()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("This test will run a large amount of sudokus from a dataset");
            Console.WriteLine("The original dataset contains 9 million sudokus and their solutions");
            Console.WriteLine("For this application I used a subset of the dataset that only contains 10,000 sudokus, since the");
            Console.WriteLine("full dataset is too large to be uploaded to GitHub");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Enter how many sudokus to run from the file:");
            string input = Console.ReadLine();
            int number;

            bool isNumber = int.TryParse(input, out number);

            if (!isNumber)
            {
                throw new InputIsNotANumberException(input);
            }

            if (number < 1 || number > 10000)
            {
                throw new InputOutOfRangeException(number);
            }

            FileTest.TestLargeFile(number);

            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();

        }

        /// <summary>
        /// Displays the main page instrcutions.
        /// </summary>
        public static void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Sudoku board input\n");
            Console.WriteLine("A sudoku board is represented by a series of 81 digits");
            Console.WriteLine("Each 9 consecutive digits represent a row on the board");
            Console.WriteLine("The digit 0 reprsents an empty cells");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("To quit the solver type 'quit'");
            Console.WriteLine("To run a large amount of sudokus from a dataset type 'test'");
            Console.WriteLine("----------------------------------------------------------------\n");
            Console.WriteLine("Enter sudoku board:");
        }
    }
}
