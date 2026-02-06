using OmegaSudoku.Tests;

namespace OmegaSudokuTest
{
    /// <summary>
    /// A test class for testing Sudoku solving speed.
    /// </summary>
    [TestClass]
    public sealed class SpeedSudokuTest
    {
        [TestMethod]
        public void SpeedSudokuTest1()
        {
            int numberOfSudokus = 100000;
            TimeSpan oneSecond = TimeSpan.FromSeconds(1);

            TimeSpan longestSolveTime = FileTest.TestEasyFile(numberOfSudokus);
            // Test if the longest solve time is less than one second
            Assert.IsTrue(longestSolveTime <  oneSecond);
        }

        [TestMethod]
        public void SpeedSudokuTest2()
        {
            int numberOfSudokus = 49151;
            TimeSpan oneSecond = TimeSpan.FromSeconds(1);

            TimeSpan longestSolveTime = FileTest.TestDifficultFile(numberOfSudokus);
            // Test if the longest solve time is less than one second
            Assert.IsTrue(longestSolveTime < oneSecond);
        }
    }
}
