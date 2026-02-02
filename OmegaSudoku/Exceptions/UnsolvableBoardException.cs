namespace OmegaSudoku.Exceptions
{
    /// <summary>
    /// An exception that is thrown when the board is unsolvable.
    /// </summary>
    public class UnsolvableBoardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsolvableBoardException"/> class.
        /// </summary>
        public UnsolvableBoardException() : base(ExceptionMessage())
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
