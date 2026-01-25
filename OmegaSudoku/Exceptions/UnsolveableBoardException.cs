using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class UnsolveableBoardException : Exception
    {
        public UnsolveableBoardException() : base(ExceptionMessage())
        {

        }

        private static string ExceptionMessage()
        {
            return $"The sudoku board is unsolveable.";
        }
    }
}
