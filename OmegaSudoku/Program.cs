using OmegaSudoku;

SudokuBoard board = new SudokuBoard(4);

bool valid = board.LoadBoard([1, 2, 4, 3,
                              3, 4, 2, 1,
                              4, 3, 0, 2,
                              2, 1, 3, 4]);

Console.WriteLine(valid);

board.PrintBoard();

bool placed = board.PlaceNumber(2, 2, 1);

Console.WriteLine(placed);

board.PrintBoard();