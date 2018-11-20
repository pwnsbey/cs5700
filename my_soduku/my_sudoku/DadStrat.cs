using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sudoku;

namespace my_sudoku
{
    public class DadStrat : SolverStrat
    {
        public override Puzzle Solve(Puzzle puzzle)
        {
            List<char>[,] possibilities = new List<char>[puzzle.Size, puzzle.Size];
            for (int blankTarget = 1; blankTarget <= puzzle.Size; blankTarget++)
            {
                Console.WriteLine(blankTarget);
                bool solvedCell = false;

                // cols
                for (int x = 0; x < puzzle.Size; x++)
                {
                    // get blanks in col
                    List<int[]> blankCoords = new List<int[]>();
                    for (int y = 0; y < puzzle.Size; y++)
                    {
                        if (puzzle.Plane[x, y] == '-')
                        {
                            int[] blankCoord = new int[2];
                            blankCoord[0] = x;
                            blankCoord[1] = y;
                            blankCoords.Add(blankCoord);
                        }
                    }
                    
                    // if blank count = target
                    if (blankCoords.Count == blankTarget)
                    {
                        for (int i = 0; i < blankCoords.Count; i++)
                        {
                            var coordX = blankCoords[i][0];
                            var coordY = blankCoords[i][1];
                            // assign possibilites
                            possibilities[coordX, coordY] = GetPossibilities(puzzle, coordX, coordY);
                            
                            // attempt to solve
                            if (possibilities[coordX, coordY].Count == 1)
                            {
                                Console.WriteLine("solved");
                                puzzle.Plane[coordX, coordY] = possibilities[coordX, coordY][0];
                                solvedCell = true;
                            }
                        }
                    }
                }

                // rows
                for (int x = 0; x < puzzle.Size; x++)
                {
                    List<int[]> blankCoords = new List<int[]>();
                    for (int y = 0; y < puzzle.Size; y++)
                    {
                        if (puzzle.Plane[y, x] == '-')
                        {
                            int[] blankCoord = new int[2];
                            blankCoord[0] = y;
                            blankCoord[1] = x;
                            blankCoords.Add(blankCoord);
                        }
                    }
                    
                    if (blankCoords.Count == blankTarget)
                    {
                        for (int i = 0; i < blankCoords.Count; i++)
                        {
                            var coordX = blankCoords[i][0];
                            var coordY = blankCoords[i][1];
                            possibilities[coordX, coordY] = GetPossibilities(puzzle, coordX, coordY);
                            
                            if (possibilities[coordX, coordY].Count == 1)
                            {
                                Console.WriteLine("solved");
                                puzzle.Plane[coordX, coordY] = possibilities[coordX, coordY][0];
                                solvedCell = true;
                            }
                        }
                    }
                }

                // blocks
                for (int w = 0; w < puzzle.Size; w++)
                {
                    List<int[]> blankCoords = new List<int[]>();
                    for (int x = 0; x < puzzle.Blocksize; x++)
                    {
                        for (int y = 0; y < puzzle.Blocksize; y++)
                        {
                            int modX = x + (puzzle.Blocksize * (w % puzzle.Blocksize));
                            int modY = y + (puzzle.Blocksize * (w / puzzle.Blocksize));

                            if (puzzle.Plane[modX, modY] == '-')
                            {
                                int[] blankCoord = new int[2];
                                blankCoord[0] = x;
                                blankCoord[1] = y;
                                blankCoords.Add(blankCoord);
                            }
                        }
                    }
                    
                    if (blankCoords.Count == blankTarget)
                    {
                        for (int i = 0; i < blankCoords.Count; i++)
                        {
                            var coordX = blankCoords[i][0];
                            var coordY = blankCoords[i][1];
                            // assign possibilites
                            possibilities[coordX, coordY] = GetPossibilities(puzzle, coordX, coordY);
                            
                            // attempt to solve
                            if (possibilities[coordX, coordY].Count == 1)
                            {
                                Console.WriteLine("solved");
                                puzzle.Plane[coordX, coordY] = possibilities[coordX, coordY][0];
                                solvedCell = true;
                            }
                        }
                    }
                }

                if (solvedCell)
                {
                    if (blankTarget == 1)
                        blankTarget = 0;
                    else
                        blankTarget = 1;
                }
            }
            return puzzle;
        }
    }
}
