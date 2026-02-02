using OmegaSudoku.Exceptions;
using OmegaSudoku.Solvers;
namespace OmegaSudokuTest
{
    /// <summary>
    /// A test class for testing invalid Sudokus.
    /// </summary>
    [TestClass]
    public sealed class InvalidSudokuTest
    {
        [TestMethod]
        public void InvalidSudokuTest1()
        {
            string inputSudoku = "065230109003040702014074058040083275801402693052907800490700530037814026000305400";

            Assert.ThrowsException<InvalidBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuTest2()
        {
            string inputSudoku = "000000031280000000500100000000337800600000200000040000030000040100500000000600000";

            Assert.ThrowsException<InvalidBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuTest3()
        {
            string inputSudoku = "000008500960405180508010407600170000402689005010500076700360098080800041080090700";

            Assert.ThrowsException<InvalidBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuTest4()
        {
            string inputSudoku = "200000051200030000000000000000070620050400000000000300004501000600000830000700000";

            Assert.ThrowsException<InvalidBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuTest5()
        {
            string inputSudoku = "000640003000079603760813000620958004095000760014000020000700240406205317072400095";

            Assert.ThrowsException<InvalidBoardException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }
    }
}
