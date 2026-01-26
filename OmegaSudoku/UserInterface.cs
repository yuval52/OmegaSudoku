using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku
{
    public static class UserInterface
    {

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

            // Run the solver
            string result = SudokuSolver.SolveSudoku(input);

            return result;
        }
        public static void ShowInterface()
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Sudoku board input\n");
            Console.WriteLine("A sudoku board is represented by a series of 81 digits");
            Console.WriteLine("Each 9 consecutive digits represent a row on the board");
            Console.WriteLine("The digit 0 reprsents an empty cells");
            Console.WriteLine("To quit the solver type 'quit'");
            Console.WriteLine("----------------------------------------------------------------\n");
            Console.WriteLine("Enter sudoku board:");
        }
    }
}
