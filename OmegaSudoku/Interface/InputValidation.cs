using OmegaSudoku.Exceptions;

namespace OmegaSudoku.Interface
{
    /// <summary>
    /// A static class for validating and converting Sudoku input.
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Converts a string input representing a Sudoku board into an int array.
        /// </summary>
        /// <param name="input">The string representing a sudoku array.</param>
        /// <returns>An array of integers representing the board.</returns>
        /// <exception cref="InvalidSudokuLengthException">An exception that is thrown when the input string is an invalid length.</exception>
        /// <exception cref="InvalidCharacterException">An exceptin that is thrown when the input string contains an invalid charachter.</exception>
        public static int[] ConvertInput(string input)
        {
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
                    // Convert char digit to int
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
