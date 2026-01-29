namespace OmegaSudoku.Exceptions
{
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException(char ch) : base(ExceptionMessage(ch))
        {

        }

        private static string ExceptionMessage(char ch)
        {
            return $"The character '{ch}' is not a valid digit character.";
        }
    }
}
