namespace OmegaSudoku.Exceptions
{
    /// <summary>
    /// An exception that is thrown when the input string is an invalid length.
    /// </summary>
    public class InvalidSudokuLengthException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputIsNotANumberException"/> class.
        /// </summary>
        /// <param name="length">The invalid length.</param>
        public InvalidSudokuLengthException(int length) : base(ExceptionMessage(length))
        {
            
        }

        /// <summary>
        /// Creates the exception message for the given input.
        /// </summary>
        /// <param name="length">The invalid length.</param>
        /// <returns>The custom exception message.</returns>
        private static string ExceptionMessage(int length)
        {
            return $"Input length {length} is not a valid sudoku size.";
        }
    }
}
