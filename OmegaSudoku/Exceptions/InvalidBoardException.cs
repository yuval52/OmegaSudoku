using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSudoku.Exceptions
{
    public class InvalidBoardException : Exception
    {
        public InvalidBoardException() : base(ExceptionMessage())
        {

        }

        private static string ExceptionMessage()
        {
            return $"The initial sudoku board is invalid.";
        }
    }
}
