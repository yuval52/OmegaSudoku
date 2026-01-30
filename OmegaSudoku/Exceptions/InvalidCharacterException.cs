namespace OmegaSudoku.Exceptions
{
    /// <summary>
    /// An exceptin that is thrown when the input string contains an invalid charachter.
    /// </summary>
    public class InvalidCharacterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCharacterException"/> class.
        /// </summary>
        /// <param name="ch">The invalid character.</param>
        public InvalidCharacterException(char ch) : base(ExceptionMessage(ch))
        {

        }

        /// <summary>
        /// Creates the exception message for the given input.
        /// </summary>
        /// <param name="ch">The invalid character.</param>
        /// <returns>The custom exception message.</returns>
        private static string ExceptionMessage(char ch)
        {
            return $"The character '{ch}' is not a valid digit character.";
        }
    }
}
