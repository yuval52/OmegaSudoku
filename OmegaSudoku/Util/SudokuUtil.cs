namespace OmegaSudoku.Util
{
    /// <summary>
    /// A static utility class for common Sudoku functions.
    /// </summary>
    public static class SudokuUtil
    {

        /// <summary>
        /// Determines the number of possible options (0 bits) in a given bitmask.
        /// </summary>
        /// <param name="mask">The bitmask to check.</param>
        /// <param name="size">The max amount of bits to check.</param>
        /// <returns>The amount of 0 bits in the bitmask.</returns>
        public static int NumberOfOptions(int mask, int size)
        {
            int countSetBits = 0;

            while (mask > 0)
            {
                // Count how many bits are set to 1
                mask &= mask - 1;
                countSetBits++;
            }

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
    }
}
