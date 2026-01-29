namespace OmegaSudoku.Exceptions
{
    public class UnsolveableBoardException : Exception
    {
        public UnsolveableBoardException() : base(ExceptionMessage())
        {

        }

        private static string ExceptionMessage()
        {
            return $"The sudoku board is unsolveable.";
        }
    }
}
