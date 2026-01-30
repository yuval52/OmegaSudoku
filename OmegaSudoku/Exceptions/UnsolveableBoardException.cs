namespace OmegaSudoku.Exceptions
{
    /// <summary>
    /// An exception that is thrown when the board is unsolvable.
    /// </summary>
    public class UnsolveableBoardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsolveableBoardException"/> class.
        /// </summary>
        public UnsolveableBoardException() : base(ExceptionMessage())
        {

        }

        /// <summary>
        /// Creates the exception message.
        /// </summary>
        /// <returns>The custom exception message.</returns>
        private static string ExceptionMessage()
        {
            return $"The sudoku board is unsolveable.";
        }
    }
}
