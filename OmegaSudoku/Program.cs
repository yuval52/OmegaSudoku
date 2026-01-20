using OmegaSudoku;

SudokuBoard board = new SudokuBoard(4);

bool valid = board.LoadBoard([1, 2, 4, 3,
                              3, 4, 2, 1,
                              4, 3, 0, 2,
                              2, 1, 3, 4]);

Console.WriteLine(valid);

int[,] boardMatrix = board.GetBoard();
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write(boardMatrix[i, j].ToString() + ", ");
    }
    Console.Write("\n");
}

bool placed = board.PlaceNumber(2, 2, 3);

Console.WriteLine(placed);

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 4; j++)
    {
        Console.Write(boardMatrix[i, j].ToString() + ", ");
    }
    Console.Write("\n");
}