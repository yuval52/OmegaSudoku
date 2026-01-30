namespace OmegaSudoku.Exceptions
{
    /// <summary>
    /// An exception that is thrown when the input is not in the range of numbers possible for the test.
    /// </summary>
    public class InputOutOfRangeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputOutOfRangeException"/> class.
        /// </summary>
        /// <param name="num">The number out of range.</param>
        public InputOutOfRangeException(int num) : base(ExceptionMessage(num))
        {

        }

        /// <summary>
        /// Creates the exception message for the given input.
        /// </summary>
        /// <param name="num">The number out of range.</param>
        /// <returns>The custom exception message.</returns>
        private static string ExceptionMessage(int num)
        {
            return $"The number {num} is out of the possible range.";
        }
    }
}
