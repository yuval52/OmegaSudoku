using OmegaSudoku.Exceptions;
using OmegaSudoku.Solvers;
namespace OmegaSudokuTest
{
    /// <summary>
    /// A test class for testing unsolvable Sudokus.
    /// </summary>
    [TestClass]
    public sealed class UnsolvableSudokuTest
    {
        [TestMethod]
        public void UnsolvableSudokuTest1()
        {
            string inputSudoku = "123000000456000000000090000000000000000000000000000000000000000000000000000000000";

            Assert.ThrowsException<UnsolvableBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void UnsolvableSudokuTest2()
        {
            string inputSudoku = "000020003000000000000100000100000030006000000007000500039000000020010000050000001";

            Assert.ThrowsException<UnsolvableBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void UnsolvableSudokuTest3()
        {
            string inputSudoku = "000000051260000000008600000000071020140050000000000300000300400500900000700000000";

            Assert.ThrowsException<UnsolvableBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void UnsolvableSudokuTest4()
        {
            string inputSudoku = "400800502208400973000002840796500000000673019532980000070200195600105000000390400";

            Assert.ThrowsException<UnsolvableBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void UnsolvableSudokuTest5()
        {
            string inputSudoku = "000010500604000000000005000000300062510400000700000000052000100000008030000600000";

            Assert.ThrowsException<UnsolvableBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }
    }
}
