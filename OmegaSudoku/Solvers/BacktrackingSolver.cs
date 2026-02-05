using OmegaSudoku.Board;
using OmegaSudoku.Util;

namespace OmegaSudoku.Solvers
{
    /// <summary>
    /// The class dedicated to solving Sudoku boards using backtracking.
    /// </summary>
    public class BacktrackingSolver
    {
        // The Sudoku board to solve
        private SudokuBoard _board;
        // Stack containing all moves made during solving to enable undoing moves
        private Stack<int[]> movesStack;

        /// <summary>
        /// Initializes a backtracking solver for the given Sudoku board.
        /// </summary>
        /// <param name="board">The board to solve.</param>
        public BacktrackingSolver(SudokuBoard board)
        {
            _board = board;
            // Initialize an empty moves stack
            movesStack = new Stack<int[]>();
        }


        /// <summary>
        /// Wrapper function to start the backtracking solving process.
        /// </summary>
        /// <returns>Whether the solver managed to solve the board.</returns>
        public bool SolveBacktracking()
        {
            // Start the backtracking
            return Backtrack();
        }

        /// <summary>
        /// Recursive backtracking function to solve the board.
        /// </summary>
        /// <returns>Whether a solution to the board was found in this branch of backtracking.</returns>
        private bool Backtrack()
        {
            // Use non backtracking strategies first
            int prevChanges = 0;
            int changes = StrategySolver.ApplyStrategies(_board, movesStack);

            while(changes != prevChanges)
            {
                // Continue applying strategies until no more changes are made
                prevChanges = changes;
                changes += StrategySolver.ApplyStrategies(_board, movesStack);
            }

            // The next cell to backtrack through
            int nextRow;
            int nextColumn;
            (nextRow, nextColumn) = FindNextCell();

            if (nextRow == -1 && nextColumn == -1)
            {
                // No empty cells, board solved
                return true;
            }

            // Get the bitmask of the cell
            int cellMask = _board.GetCellMask(nextRow, nextColumn);

            for (int i = 1; i <= _board.GetSize(); i++)
            {
                // Try each number for the cell
                if (!SudokuUtil.IsNumberInMask(cellMask, i))
                {
                    // Number is available for cell
                    PerformMove(nextRow, nextColumn, i);
                    // Placed number
                    // Backtrack again
                    bool solved = Backtrack();
                    if (solved)
                    {
                        // A solution was found in this branch

                        return true;
                    }
                    // Solution was not found in this branch
                    // Undo number placement before trying next number
                    UndoMove();

                }
            }

            // Branch has no solution, move back up
            // Undo changes done at the start of this call
            UndoMoves(changes);
            return false;
        }

        /// <summary>
        /// Find the next best cell to backtrack through.
        /// </summary>
        /// <returns>The coordinates (row and column) of the next best cell.</returns>
        private (int rowIndex, int columnIndex) FindNextCell()
        {
            // Define score weights
            double optionsWeight = 1;
            // Counter intuitively, I would want to actually prioritize cells that affect less other cells, since they are more likely to create singles, which can be found without backtracking
            // Negative weight to prioritize cells with less effect
            double effectWeight = -0.25;

            // Start by assuming no cell found
            int bestRow = -1;
            int bestColumn = -1;
            double bestScore = Double.NegativeInfinity;

            for (int i = 0; i < _board.GetSize(); i++)
            {
                for (int j = 0; j < _board.GetSize(); j++)
                {
                    if (_board.GetCell(i, j) == 0)
                    {
                        // Found empty cell
                        int cellMask = _board.GetCellMask(i, j);
                        // Count how many options this cell has
                        int options = SudokuUtil.NumberOfOptions(cellMask, _board.GetSize());
                        int optionsScore = _board.GetSize() - options;

                        int squareI = i / _board.GetSizeRoot();
                        int squareJ = j / _board.GetSizeRoot();
                        // Count roughly how many empty cells changing this cell will affect
                        int effectScore = SudokuUtil.NumberOfOptions(_board.GetRowMask(i), _board.GetSize()) + SudokuUtil.NumberOfOptions(_board.GetColumnMask(j), _board.GetSize() + SudokuUtil.NumberOfOptions(_board.GetSquareMask(squareI, squareJ), _board.GetSize()));

                        //Calculate total score
                        double totalScore = optionsScore * optionsWeight + effectScore * effectWeight;

                        if (totalScore > bestScore)
                        {
                            // Cell has the best score so far
                            bestScore = totalScore;
                            bestRow = i;
                            bestColumn = j;
                        }
                    }
                }
            }

            // Return the cell with the least numbers possible
            return (bestRow, bestColumn);
        }

        /// <summary>
        /// Perform a move by placing a number on the board and adding it to the moves stack.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <param name="num">The number to place.</param>
        private void PerformMove(int row, int column, int num)
        {
            // Push the move's info to the stack
            int[] move = [row, column, num];
            movesStack.Push(move);

            // Place the number on the board
            _board.PlaceNumber(row, column, num);
        }

        /// <summary>
        /// Undo the most recent move from the moves stack.
        /// </summary>
        private void UndoMove()
        {
            // Pop the most recent move from the stack
            int[] move = movesStack.Pop();

            // Undo the placement on the board
            _board.UndoPlacement(move[0], move[1], move[2]);
        }

        /// <summary>
        /// Undo multiple moves from the moves stack.
        /// </summary>
        /// <param name="n">The number of moves to undo.</param>
        private void UndoMoves(int n)
        {
            for (int i = 0; i < n; i++)
            {
                // Undo 1 move at a time
                UndoMove();
                
            }
        }

    }
}
