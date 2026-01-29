namespace OmegaSudoku.Exceptions
{
    public class InvalidBoardException : Exception
    {
        public InvalidBoardException() : base(ExceptionMessage())
        {

        }

        private static string ExceptionMessage()
        {
            return $"The initial sudoku board is invalid.";
        }
    }
}
