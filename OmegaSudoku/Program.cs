using OmegaSudoku;

//SudokuBoard board = new SudokuBoard(4);

//bool valid = board.LoadBoard([0, 3, 4, 0,
//                              4, 0, 0, 2,
//                              1, 0, 0, 3,
//                              0, 2, 1, 0]);

SudokuBoard board = new SudokuBoard(9);

bool valid = board.LoadBoard([6, 0, 0, 4, 1, 0, 3, 0, 8,
                              8, 0, 5, 0, 6, 3, 4, 0, 0,
                              7, 3, 0, 0, 2, 0, 0, 0, 1,
                              0, 0, 6, 1, 5, 7, 0, 0, 2,
                              5, 7, 0, 0, 0, 4, 1, 0, 6,
                              1, 2, 0, 0, 9, 6, 0, 4, 0,
                              3, 0, 0, 0, 0, 0, 0, 8, 0,
                              0, 6, 9, 0, 3, 0, 0, 5, 0,
                              0, 0, 7, 0, 4, 0, 0, 1, 0]);

Console.WriteLine(valid);

board.PrintBoard();

BacktrackingSolver solver = new BacktrackingSolver(board);

bool solved = solver.SolveBacktracking();

Console.WriteLine(solved);

board.PrintBoard();