namespace OmegaSudoku.Exceptions
{
    public class InvalidSudokuLengthException : Exception
    {
        public InvalidSudokuLengthException(int length) : base(ExceptionMessage(length))
        {
            
        }

        private static string ExceptionMessage(int length)
        {
            return $"Input length {length} is not a valid sudoku size.";
        }
    }
}
