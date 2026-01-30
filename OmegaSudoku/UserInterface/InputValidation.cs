using OmegaSudoku.Exceptions;

namespace OmegaSudoku.UserInterface
{
    public static class InputValidation
    {

        public static int[] ConvertInput(string input)
        {
            // Convert the input from a string to an array
            int length = input.Length;
            if (length != 81)
            {
                // Invalid input length
                throw new InvalidSudokuLengthException(length);
            }

            int[] sudokuArray = new int[length];

            // Go over every character
            for (int i = 0; i < length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    sudokuArray[i] = input[i] - '0';
                }
                else
                {
                    // Non digit character
                    throw new InvalidCharacterException(input[i]);
                }
            }

            // Return the converded input
            return sudokuArray;
        }
    }
}
