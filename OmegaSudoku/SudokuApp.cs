using OmegaSudoku.Interface;

namespace OmegaSudoku
{
    /// <summary>
    /// The main class for running the Omega Sudoku application.
    /// </summary>
    public static class SudokuApp
    {
        /// <summary>
        /// Starts the Omega Sudoku application.
        /// </summary>
        public static void Run()
        {
            Console.WriteLine("Welcome to the Omega sudoku solver!\n");
            while (true)
            {
                // The main loop for repeatedly running the Sudoku solver
                try
                {
                    string output = UserInterface.RunSudokuSolver();
                    if (output.Equals("quit"))
                    {
                        // User quit the application
                        Console.WriteLine("Quitting the program...");
                        // Exit the loop and end the program
                        break;
                    }
                }
                catch (Exception e)
                {
                    // Inform the user of exceptions encountered during application running
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Encountered an error:");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press enter to return to the main menu");
                    Console.ReadLine();
                }

            }
        }
    }
}
