using OmegaSudoku.Solvers;
namespace OmegaSudokuTest
{
    /// <summary>
    /// A test class for testing valid Sudokus.
    /// </summary>
    [TestClass]
    public sealed class SudokuTest
    {
        [TestMethod]
        public void SudokuTest1()
        {
            string inputSudoku = "500670084407000630068000701000000209050980460679042518105869047796400852003720096";
            string expectedoutput = "532671984417298635968534721384156279251987463679342518125869347796413852843725196";

            string output = SudokuSolver.TestSolver(inputSudoku);
            Assert.AreEqual(expectedoutput, output);
        }

        [TestMethod]
        public void SudokuTest2()
        {
            string inputSudoku = "008072000260038417500016300900360504010245096400800000000120703327084050090703042";
            string expectedoutput = "138472965269538417574916328982361574713245896456897231645129783327684159891753642";

            string output = SudokuSolver.TestSolver(inputSudoku);
            Assert.AreEqual(expectedoutput, output);
        }

        [TestMethod]
        public void SudokuTest3()
        {
            string inputSudoku = "025700000040250971090310400904025000510907008002080009750004810200591700030802090";
            string expectedoutput = "125749683346258971897316425984125367513967248672483159759634812268591734431872596";

            string output = SudokuSolver.TestSolver(inputSudoku);
            Assert.AreEqual(expectedoutput, output);
        }

        [TestMethod]
        public void SudokuTest4()
        {
            string inputSudoku = "600900003507826049090000206000439000300068400809710365060270984005390601000600037";
            string expectedoutput = "612947853537826149498153276256439718371568492849712365163275984785394621924681537";

            string output = SudokuSolver.TestSolver(inputSudoku);
            Assert.AreEqual(expectedoutput, output);
        }

        [TestMethod]
        public void SudokuTest5()
        {
            string inputSudoku = "000000041050080000000000000600107000030000500000400020400000800000050300001600000";
            string expectedoutput = "368592741254781639719346258645127983132968574897435126473219865926854317581673492";

            string output = SudokuSolver.TestSolver(inputSudoku);
            Assert.AreEqual(expectedoutput, output);
        }
    }
}
