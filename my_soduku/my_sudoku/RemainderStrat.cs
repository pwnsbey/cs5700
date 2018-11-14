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
                puzzle.PrintPuzzle();
                Console.WriteLine("");
                canSolve = false;
                for (int j = 0; j < puzzle.Size; j++)
                {
                    for (int i = 0; i < puzzle.Size; i++)
                    {
                        if (puzzle.Plane[i, j] == '-')
                        {
                            // Cols
                            char[] colNeighbors = puzzle.GetInCol(i, j);
                            int occurrences = 0;
                            List<char> numberOpts = new List<char>();
                            for (int k = 1; k <= puzzle.Size; k++)
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
                                char[] rowNeighbors = puzzle.GetInRow(i, j);
                                occurrences = 0;
                                numberOpts = new List<char>();
                                for (int k = 1; k <= puzzle.Size; k++)
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
                                char[] blockNeighbors = puzzle.GetInBlock(i, j);
                                occurrences = 0;
                                numberOpts = new List<char>();
                                for (int k = 1; k <= puzzle.Size; k++)
                                    numberOpts.Add(k.ToString()[0]);
                                for (int k = 0; k < puzzle.Size; k++)
                                {
                                    if (blockNeighbors[k] == '-')
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
            Console.WriteLine("FINISH");
            puzzle.PrintPuzzle();
            return puzzle;
        }
    }
}
