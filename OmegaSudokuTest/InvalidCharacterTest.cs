using OmegaSudoku.Exceptions;
using OmegaSudoku.Solvers;
namespace OmegaSudokuTest
{
    /// <summary>
    /// A test class for testing invalid characters in Sudokus.
    /// </summary>
    [TestClass]
    public sealed class InvalidCharacterTest
    {
        [TestMethod]
        public void InvalidCharacterTest1()
        {
            string inputSudoku = "7001395000064hello490876032003090605050600008001080900029010053300052401504300000";

            Assert.ThrowsException<InvalidCharacterException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidCharacterTest2()
        {
            string inputSudoku = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            Assert.ThrowsException<InvalidCharacterException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidCharacterTest3()
        {
            string inputSudoku = "0000094006700000001000:0000020160000,00000950000030000300000016009004000000800000";

            Assert.ThrowsException<InvalidCharacterException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidCharacterTest4()
        {
            string inputSudoku = "6  4  5 9 7562 3  2 4  9 8  26  1  7    6 813  8 3  52   2 3 7       2  74   6   ";

            Assert.ThrowsException<InvalidCharacterException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidCharacterTest5()
        {
            string inputSudoku = "00020030010004000000000000878030000060000b015000000000023000800000061000000000040";

            Assert.ThrowsException<InvalidCharacterException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }
    }
}
