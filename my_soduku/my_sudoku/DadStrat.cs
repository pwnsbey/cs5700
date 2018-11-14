using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sudoku;

namespace my_sudoku
{
    class DadStrat : SolverStrat
    {
        public override Puzzle Solve(Puzzle puzzle)
        {
            List<char>[,] possibilities = new List<char>[puzzle.Size, puzzle.Size];
            for (int blankTarget = 1; blankTarget <= puzzle.Size; blankTarget++)
            {
                bool solvedCell = false;
                // cols
                for (int x = 0; x < puzzle.Size; x++)
                {
                    // get blanks in col
                    List<int[]> blankCoords = new List<int[]>();
                    for (int y = 0; y < puzzle.Size; y++)
                    {
                        int[] blankCoord = new int[2];
                        blankCoord[0] = x;
                        blankCoord[1] = y;
                        blankCoords.Add(blankCoord);
                    }

                    // if blank count = target
                    if (blankCoords.Count == blankTarget)
                    {
                        for (int i = 0; i < blankCoords.Count; i++)
                        {
                            // assign possibilites
                            possibilities[blankCoords[i][0], blankCoords[i][1]] = puzzle.GetPossibilities(blankCoords[i][0], blankCoords[i][1]);

                            // attempt to solve
                        }
                    }
                }

                // rows

                // blocks

                if (solvedCell)
                    blankTarget = 1;
            }
        }
    }
}
