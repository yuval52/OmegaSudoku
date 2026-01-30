namespace OmegaSudoku.Exceptions
{
    /// <summary>
    /// An exception that is thrown when the initial board is invalid.
    /// </summary>
    public class InvalidBoardException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidBoardException"/> class.
        /// </summary>
        public InvalidBoardException() : base(ExceptionMessage())
        {

        }

        /// <summary>
        /// Creates the exception message.
        /// </summary>
        /// <returns>The custom exception message.</returns>
        private static string ExceptionMessage()
        {
            return $"The initial sudoku board is invalid.";
        }
    }
}
