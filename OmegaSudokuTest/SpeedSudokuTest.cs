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

            TimeSpan solveTime = FileTest.TestEasyFile(numberOfSudokus);
            TimeSpan averageSudokuTime = solveTime.Divide(numberOfSudokus);
            Assert.IsTrue(averageSudokuTime <  oneSecond);
        }

        [TestMethod]
        public void SpeedSudokuTest2()
        {
            int numberOfSudokus = 49151;
            TimeSpan oneSecond = TimeSpan.FromSeconds(1);

            TimeSpan solveTime = FileTest.TestDifficultFile(numberOfSudokus);
            TimeSpan averageSudokuTime = solveTime.Divide(numberOfSudokus);
            Assert.IsTrue(averageSudokuTime < oneSecond);
        }
    }
}
