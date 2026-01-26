using OmegaSudoku;
using OmegaSudoku.Tests;

Console.WriteLine("Welcome to the Omega sudoku solver!\n");
while (true)
{
    try
    {
        string output = UserInterface.RunSudokuSolver();
        if (output.Equals("quit"))
        {
            break;
        }
    } catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("Error solving sudoku:");
        Console.WriteLine(e.Message);
        Console.WriteLine("----------------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
}

