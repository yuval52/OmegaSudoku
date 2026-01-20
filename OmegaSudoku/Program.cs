using OmegaSudoku;

//SudokuBoard board = new SudokuBoard(4);

//bool valid = board.LoadBoard([0, 3, 4, 0,
//                              4, 0, 0, 2,
//                              1, 0, 0, 3,
//                              0, 2, 1, 0]);

SudokuBoard board = new SudokuBoard(9);

//bool valid = board.LoadBoard([6, 0, 0, 4, 1, 0, 3, 0, 8,
//                              8, 0, 5, 0, 6, 3, 4, 0, 0,
//                              7, 3, 0, 0, 2, 0, 0, 0, 1,
//                              0, 0, 6, 1, 5, 7, 0, 0, 2,
//                              5, 7, 0, 0, 0, 4, 1, 0, 6,
//                              1, 2, 0, 0, 9, 6, 0, 4, 0,
//                              3, 0, 0, 0, 0, 0, 0, 8, 0,
//                              0, 6, 9, 0, 3, 0, 0, 5, 0,
//                              0, 0, 7, 0, 4, 0, 0, 1, 0]);

//bool valid = board.LoadBoard([0, 0, 4, 8, 0, 5, 7, 0, 6,
//                              0, 0, 0, 9, 0, 0, 0, 4, 0,
//                              0, 2, 0, 4, 0, 0, 0, 0, 1,
//                              8, 0, 0, 7, 0, 3, 0, 6, 0,
//                              0, 0, 6, 0, 0, 1, 5, 0, 0,
//                              2, 0, 0, 0, 0, 8, 4, 7, 0,
//                              0, 4, 0, 5, 0, 6, 0, 0, 0,
//                              5, 0, 0, 0, 0, 0, 6, 8, 0,
//                              0, 0, 0, 1, 0, 0, 0, 5, 4]);

bool valid = board.LoadBoard([0, 0, 0, 0, 0, 0, 0, 6, 8,
                              9, 0, 0, 0, 0, 0, 0, 0, 2,
                              0, 0, 0, 4, 0, 0, 5, 0, 0,
                              0, 4, 1, 0, 0, 0, 0, 0, 0,
                              0, 0, 0, 0, 3, 5, 0, 0, 0,
                              0, 5, 0, 0, 0, 0, 0, 0, 0,
                              0, 0, 0, 8, 0, 0, 0, 1, 0,
                              3, 0, 0, 0, 0, 0, 7, 0, 0,
                              0, 0, 0, 1, 0, 0, 4, 0, 0]);

//bool valid = board.LoadBoard([0, 4, 0, 8, 0, 0, 0, 0, 6,
//                              0, 0, 1, 0, 0, 6, 0, 0, 3,
//                              0, 0, 6, 3, 0, 9, 8, 0, 0,
//                              2, 5, 0, 6, 0, 3, 0, 0, 0,
//                              0, 0, 0, 0, 0, 0, 0, 0, 0,
//                              0, 8, 7, 0, 0, 0, 0, 4, 0,
//                              0, 0, 0, 0, 9, 0, 7, 0, 0,
//                              0, 0, 0, 0, 0, 4, 0, 1, 0,
//                              0, 0, 0, 0, 0, 2, 0, 0, 5]);

Console.WriteLine(valid);

board.PrintBoard();

BacktrackingSolver solver = new BacktrackingSolver(board);

DateTime before = DateTime.Now;

bool solved = solver.SolveBacktracking();

DateTime after = DateTime.Now;

TimeSpan time = after - before;

Console.WriteLine(solved);

board.PrintBoard();

Console.WriteLine(time.ToString());