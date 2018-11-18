using sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_sudoku
{
    class Solver
    {
        //public bool IsFinished(Puzzle puzzle)
        //{
        //    throw NotImplementedException;
        //}

        public Puzzle Solve(Puzzle puzzle)
        {
            SolverStrat strat = new VexStrat();
            return strat.Solve(puzzle);
        }
    }
}
