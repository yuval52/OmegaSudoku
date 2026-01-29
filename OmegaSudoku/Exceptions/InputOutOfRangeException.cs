namespace OmegaSudoku.Exceptions
{
    public class InputOutOfRangeException : Exception
    {
        public InputOutOfRangeException(int num) : base(ExceptionMessage(num))
        {

        }

        private static string ExceptionMessage(int num)
        {
            return $"The number {num} is out of the possible range.";
        }
    }
}
