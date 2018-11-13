using sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_sudoku
{
    abstract class SolverStrat
    {
        public abstract Puzzle Solve(Puzzle puzzle);
    }
}
