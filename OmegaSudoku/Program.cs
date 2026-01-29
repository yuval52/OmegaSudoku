using OmegaSudoku;

Console.WriteLine("Welcome to the Omega sudoku solver!\n");
while (true)
{
    try
    {
        string output = UserInterface.RunSudokuSolver();
        if (output.Equals("quit"))
        {
            Console.WriteLine("Quitting the program...");
            break;
        }
    }
    catch (Exception e)
    {
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