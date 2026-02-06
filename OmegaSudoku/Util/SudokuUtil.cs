using System.Numerics;
using OmegaSudoku.Exceptions;
namespace OmegaSudoku.Util
{
    /// <summary>
    /// A static utility class for common Sudoku functions.
    /// </summary>
    public static class SudokuUtil
    {
        // The possible sizes for Sudoku boards
        public static readonly int[] possibleSizes = {4, 9, 16};

        /// <summary>
        /// Determines the number of possible options (0 bits) in a given bitmask.
        /// </summary>
        /// <param name="mask">The bitmask to check.</param>
        /// <param name="size">The max amount of bits to check.</param>
        /// <returns>The amount of 0 bits in the bitmask.</returns>
        public static int NumberOfOptions(int mask, int size)
        {
            int countSetBits = BitOperations.PopCount((uint)mask);

            // The number of options is the bits that arent 1
            return size - countSetBits;
        }

        /// <summary>
        /// Checks if a number is present in the given bitmask.
        /// </summary>
        /// <param name="mask">The bitmask to check.</param>
        /// <param name="num">The number to look for.</param>
        /// <returns>Whether the number is in the bitmask.</returns>
        public static bool IsNumberInMask(int mask, int num)
        {
            int numMask = 1 << (num - 1);
            return (mask & numMask) != 0;
        }

        /// <summary>
        /// Adds a number to the given bitmask.
        /// </summary>
        /// <param name="mask">Thr mask to add to.</param>
        /// <param name="num">The number to add to the mask.</param>
        /// <returns>The new bitmask with the number added.</returns>
        public static int AddNumberToMask(int mask, int num)
        {
            int numMask = 1 << (num - 1);
            return mask | numMask;
        }

        /// <summary>
        /// Removes a number from the given bitmask.
        /// </summary>
        /// <param name="mask">The mask to remove from.</param>
        /// <param name="num">The number to remove.</param>
        /// <returns>The new mask with the number removed.</returns>
        public static int RemoveNumberFromMask(int mask, int num)
        {
            int numMask = 1 << (num - 1);
            return mask & ~numMask;
        }

        /// <summary>
        /// Converts an input charachter into the corresponding number for the Sudoku board.
        /// </summary>
        /// <param name="inputChar">The character to convert.</param>
        /// <returns>The numerical value of the character.</returns>
        /// <exception cref="InvalidCharacterException">An exceptin that is thrown when the input string contains an invalid charachter.</exception>
        public static int InputCharToNumber(char inputChar)
        {
            // From looking online it seems the most common way to represent large Sudokus is to use English letters as numbers above 9
            if (Char.IsDigit(inputChar))
            {
                return inputChar - '0';
            }
            else if (Char.IsLetter(inputChar))
            {
                return Char.ToLower(inputChar) - 'a' + 10;
            }
            else
            {
                throw new InvalidCharacterException(inputChar);
            }
        }

        /// <summary>
        /// Converts a number into the corresponding output charachter.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>The corresponding character.</returns>
        public static char NumberToOutputChar(int number)
        {
            if (number <= 9)
            {
                return (char)(number + '0');
            }
            else
            {
                return (char)(number - 10 + 'a');
            }
        }
    }
}
