using OmegaSudoku;

SudokuBoard board = new SudokuBoard(4);

bool valid = board.LoadBoard([1, 2, 4, 3,
                              3, 4, 2, 1,
                              4, 3, 1, 2,
                              2, 1, 3, 4]);

Console.WriteLine(valid);

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write(board._board[i, j].ToString() + ", ");
    }
    Console.Write("\n");
}