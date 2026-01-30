namespace OmegaSudoku.Util
{
    public static class SudokuUtil
    {

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

        public static bool IsNumberInMask(int mask, int num)
        {
            int numMask = 1 << (num - 1);
            return (mask & numMask) != 0;
        }

        public static int AddNumberToMask(int mask, int num)
        {
            int numMask = 1 << (num - 1);
            return mask | numMask;
        }
    }
}
