using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sudoku;

namespace my_sudoku
{
    class RemainderStrat : SolverStrat
    {
        public override Puzzle Solve(Puzzle puzzle)
        {
            bool canSolve = true;

            while (canSolve)
            {
                canSolve = false;
                for (int i = 0; i < puzzle.Size; i++)
                {
                    for (int j = 0; j < puzzle.Size; j++)
                    {
                        if (puzzle.Plane[i, j] == '-')
                        {
                            // Cols
                            int[] colNeighbors = puzzle.GetCols(i, j);
                            int occurrences = 0;
                            List<int> numberOpts = new List<int>();
                            for (int k = 0; k < puzzle.Size; k++)
                                numberOpts.Add(k.ToString()[0]);
                            for (int k = 0; k < puzzle.Size; k++)
                            {
                                if (colNeighbors[k] == '-')
                                    occurrences++;
                                numberOpts.Remove(colNeighbors[k]);
                            }
                            if (occurrences == 1)
                            {
                                puzzle.Plane[i, j] = numberOpts[0];
                                canSolve = true;
                            }

                            // Rows
                            if (!canSolve)
                            {
                                int[] rowNeighbors = puzzle.GetRows(i, j);
                                occurrences = 0;
                                numberOpts = new List<int>();
                                for (int k = 0; k < puzzle.Size; k++)
                                    numberOpts.Add(k.ToString()[0]);
                                for (int k = 0; k < puzzle.Size; k++)
                                {
                                    if (colNeighbors[k] == '-')
                                        occurrences++;
                                    numberOpts.Remove(rowNeighbors[k]);
                                }
                                if (occurrences == 1)
                                {
                                    puzzle.Plane[i, j] = numberOpts[0];
                                    canSolve = true;
                                }
                            }

                            // Blocks
                            if (!canSolve)
                            {
                                int[] blockNeighbors = puzzle.GetBlocks(i, j);
                                occurrences = 0;
                                numberOpts = new List<int>();
                                for (int k = 0; k < puzzle.Size; k++)
                                    numberOpts.Add(k.ToString()[0]);
                                for (int k = 0; k < puzzle.Size; k++)
                                {
                                    if (colNeighbors[k] == '-')
                                        occurrences++;
                                    numberOpts.Remove(blockNeighbors[k]);
                                }
                                if (occurrences == 1)
                                {
                                    puzzle.Plane[i, j] = numberOpts[0];
                                    canSolve = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
