using OmegaSudoku.Exceptions;
using OmegaSudoku.Solvers;
namespace OmegaSudokuTest
{
    /// <summary>
    /// A test class for testing invalid Sudokus.
    /// </summary>
    [TestClass]
    public sealed class InvalidSudokuLengthTest
    {
        [TestMethod]
        public void InvalidSudokuLengthTest1()
        {
            string inputSudoku = "8070004600000000014310625900490001800162700";

            Assert.ThrowsException<InvalidSudokuLengthException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuLengthTest2()
        {
            string inputSudoku = "0004600700012084030005702000000490120291056808040070909503008072080561091309045060140200800050380900";

            Assert.ThrowsException<InvalidSudokuLengthException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuLengthTest3()
        {
            string inputSudoku = "";

            Assert.ThrowsException<InvalidSudokuLengthException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuLengthTest4()
        {
            string inputSudoku = "000000";

            Assert.ThrowsException<InvalidSudokuLengthException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }

        [TestMethod]
        public void InvalidSudokuLengthTest5()
        {
            string inputSudoku = "hello";

            Assert.ThrowsException<InvalidSudokuLengthException>(() =>
            {
                SudokuSolver.TestSolver(inputSudoku);
            });
        }
    }
}
