namespace OmegaSudoku.Exceptions
{
    public class InputIsNotANumberException : Exception
    {
        public InputIsNotANumberException(string input) : base(ExceptionMessage(input))
        {

        }

        private static string ExceptionMessage(string input)
        {
            return $"The input '{input}' is not a valid number.";
        }
    }
}
