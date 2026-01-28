using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OmegaSudoku.Tests
{
    public static class FileTest
    {
        public static void TestLargeFile(int numberOfLines)
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Loading {numberOfLines} sudokus from file");
            Console.WriteLine("----------------------------------------------------------------\n");
            // Currently using smaller 10,000 sudokus file "sudokuSet.csv"
            // Full 9,000,000 sudokus file is too large for github, so it was added to the gitignore
            // Full file is called "sudoku.csv"
            List<string[]> rows = ReadCSVFile("Tests/sudokuSet.csv", numberOfLines);

            bool allTrue = true;


            Console.WriteLine($"Solving {numberOfLines} sudokus from file:");
            Console.WriteLine("\nSolving...\n");

            // Decide how many segments should the loading bar have
            int loadingBarSegments = 20;
            // Split sample into 10 parts
            int tenthSize = numberOfLines / loadingBarSegments;

            //Print start of loading bar
            string emptyLoadingBar = new string(' ', loadingBarSegments);
            Console.Write("[" + emptyLoadingBar + "]");

            // Messure the time before solving
            DateTime before = DateTime.Now;

            for (int i = 0; i < rows.Count; i++)
            {
                //Console.WriteLine(rows[i][0]);
                string solved = SudokuSolver.TestSolver(rows[i][0]);
                bool isSolved = solved.Equals(rows[i][1]);
                if (!isSolved)
                {
                    allTrue = false;
                }

                if (i % tenthSize == 0)
                {
                    // Print loading bar progression
                    string loadingBarDots = new string('-', i / tenthSize);
                    string loadingBarSpaces = new string(' ', loadingBarSegments - (i / tenthSize));
                    Console.Write("\r[" + loadingBarDots + loadingBarSpaces + "]");
                }

                //Console.WriteLine(isSolved);
            }

            string fullLoadingBar = new string('-', loadingBarSegments);
            Console.Write("\r[" + fullLoadingBar + "]\n\n");

            // Messure the time after solving
            DateTime after = DateTime.Now;

            // Calculate solving time
            TimeSpan time = after - before;

            // Print if the solves were correct
            Console.WriteLine("All boards solved correctly:\n");
            Console.WriteLine(allTrue);

            // Print the solve time
            Console.WriteLine("\nSolve time:");
            Console.WriteLine(time.ToString(@"mm\:ss\.ffff"));
            Console.WriteLine();
        }

        private static List<string[]> ReadCSVFile(string filePath, int numberOfLines)
        {
            List<string[]> rows = new List<string[]>();

            string[] lines = File.ReadLines(filePath).Take(numberOfLines).ToArray();

            bool skippedFirstRow = false;

            foreach (string line in lines)
            {
                if (skippedFirstRow)
                {
                    string[] rowArr = line.Split(',');
                    rows.Add(rowArr);
                    //Console.WriteLine(rowArr[0]);
                }
                else
                {
                    skippedFirstRow = true;
                }
            }

            return rows;
        }
    }
}
