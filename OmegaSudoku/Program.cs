using OmegaSudoku;

try
{
    SudokuBoard board = new SudokuBoard(9);
    //int[] sudokuArr = InputValidation.ConvertInput("800000000003600000070090200050007000000045700000100030001000068008500010090000400");
    int[] sudokuArr = InputValidation.ConvertInput("000000068900000002000400500041000000000035000050000000000800010300000700000100400");
    bool valid = board.LoadBoard(sudokuArr);

    Console.WriteLine("Initial board:");
    board.PrintBoard();

    BacktrackingSolver solver = new BacktrackingSolver(board);

    DateTime before = DateTime.Now;

    bool solved = solver.SolveBacktracking();

    DateTime after = DateTime.Now;

    TimeSpan time = after - before;

    if (solved)
    {
        Console.WriteLine("Solved board:");
        board.PrintBoard();

        Console.WriteLine("\nSolve time:");
        Console.WriteLine(time.ToString());
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}