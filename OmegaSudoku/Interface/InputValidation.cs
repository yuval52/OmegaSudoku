using OmegaSudoku.Exceptions;
using OmegaSudoku.Util;

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
            // The length of the input string
            int length = input.Length;

            // Check if the length is valid
            bool validLength = false;

            for (int i = 0; i < SudokuUtil.possibleSizes.Length; i++)
            {
                if (length == (SudokuUtil.possibleSizes[i] * SudokuUtil.possibleSizes[i]))
                {
                    validLength = true;
                    break;
                }
            }

            if (!validLength)
            {
                throw new InvalidSudokuLengthException(length);
            }

            // The root of the length (size of the board)
            int lengthRoot = (int)Math.Sqrt(length);

            int[] sudokuArray = new int[length];

            // Go over every character
            for (int i = 0; i < length; i++)
            {

                int currentNum = SudokuUtil.InputCharToNumber(input[i]);
                if (currentNum <= lengthRoot)
                {
                    sudokuArray[i] = currentNum;
                }
                else
                {
                    throw new InvalidCharacterException(input[i]);
                }
            }

            // Return the converded input
            return sudokuArray;
        }
    }
}
