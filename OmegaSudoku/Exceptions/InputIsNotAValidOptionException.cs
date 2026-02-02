namespace OmegaSudoku.Exceptions
{
    /// <summary>
    /// An exception that is thrown when the input is not a valid menu option.
    /// </summary>
    public class InputIsNotAValidOptionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputIsNotAValidOptionException"/> class.
        /// </summary>
        /// <param name="input">The invalid input.</param>
        public InputIsNotAValidOptionException(string input) : base(ExceptionMessage(input))
        {

        }

        /// <summary>
        /// Creates the exception message for the given input.
        /// </summary>
        /// <param name="input">The invalid input.</param>
        /// <returns>The custom exception message.</returns>
        private static string ExceptionMessage(string input)
        {
            return $"The input '{input}' is not a valid option.";
        }
    }
}
