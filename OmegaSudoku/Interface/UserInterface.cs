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
            Console.WriteLine("Solving Sudoku:");
            Console.WriteLine(input + "\n");


            // Run the solver
            string result = SudokuSolver.SolveSudoku(input);

            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();

            return result;
        }

        public static void TestInterface()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("This program contains 2 types of tests:");
            Console.WriteLine("One test containing easy Sudokus, and another containing difficult ones");
            Console.WriteLine("The dataset of easy Sudokus also contains answers to verify the solutions");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Type 'easy' for the easy Sudokus test");
            Console.WriteLine("Type 'difficult' for the difficult Sudokus test");
            Console.WriteLine("Enter test level:");
            string input = Console.ReadLine();

            if (input.Equals("easy"))
            {
                EasyTestInterface();
            }
            else if (input.Equals("difficult"))
            {
                DifficultTestInterface();
            }
            else
            {
                throw new InputIsNotAValidOptionException(input);
            }


        }

        /// <summary>
        /// Opens the test interface to run a large amount of easy Sudokus from a dataset.
        /// </summary>
        /// <exception cref="InputIsNotANumberException">An exception that is thrown when the input is not a number.</exception>
        /// <exception cref="InputOutOfRangeException">An exception that is thrown when the input is not in the range of numbers possible for the test.</exception>
        public static void EasyTestInterface()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("This test will run a large amount of easy Sudokus from a dataset");
            Console.WriteLine("The original dataset contains 9 million Sudokus and their solutions");
            Console.WriteLine("For this application I used a subset of the dataset that only contains 10,000 Sudokus, since the");
            Console.WriteLine("full dataset is too large to be uploaded to GitHub");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Enter how many Sudokus to run from the file:");
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

            FileTest.TestEasyFile(number);

            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();

        }

        /// <summary>
        /// Opens the test interface to run a large amount of difficult Sudokus from a dataset.
        /// </summary>
        /// <exception cref="InputIsNotANumberException">An exception that is thrown when the input is not a number.</exception>
        /// <exception cref="InputOutOfRangeException">An exception that is thrown when the input is not in the range of numbers possible for the test.</exception>
        public static void DifficultTestInterface()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("This test will run a large amount of difficult Sudokus from a dataset");
            Console.WriteLine("This dataset contains 49151 Sudokus with only 17 cells filled");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Enter how many Sudokus to run from the file:");
            string input = Console.ReadLine();
            int number;

            bool isNumber = int.TryParse(input, out number);

            if (!isNumber)
            {
                throw new InputIsNotANumberException(input);
            }

            if (number < 1 || number > 49151)
            {
                throw new InputOutOfRangeException(number);
            }

            FileTest.TestDifficultFile(number);

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
            Console.WriteLine("A Sudoku board is represented by a series of 81 digits");
            Console.WriteLine("Each 9 consecutive digits represent a row on the board");
            Console.WriteLine("The digit 0 reprsents an empty cells");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("To quit the solver type 'quit'");
            Console.WriteLine("To run a large amount of Sudokus from a dataset type 'test'");
            Console.WriteLine("----------------------------------------------------------------\n");
            Console.WriteLine("Enter Sudoku board:");
        }
    }
}
