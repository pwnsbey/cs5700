using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sudoku;

namespace my_sudoku
{
    class VexStrat : SolverStrat
    {
        public override Puzzle Solve(Puzzle puzzle)
        {
            List<int[]> blankCoords = new List<int[]>();
            for (int x = 0; x < puzzle.Size; x++)
            {
                for (int y = 0; y < puzzle.Size; y++)
                {
                    int[] blankCoord = new int[2];
                    blankCoord[0] = x;
                    blankCoord[1] = y;
                    blankCoords.Add(blankCoord);
                }
            }
            for (int i = 0; i < blankCoords.Count; i++)
            {
                
            }
        }
    }
}
