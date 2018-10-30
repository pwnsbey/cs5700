using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Puzzle
    {
        public int Size;
        public int[,] Plane;

        private int[] allowedSizes = new int[] { 4, 9, 16, 25 };

        private int charToInt(char c)
        {
            return (int)char.GetNumericValue(c);
        }

        // 9
        // 1 2 3 4 5 6 7 8 9
        // - 3 4 - - - 8 - -
        // 1 - 5 8 - 3 - - -
        // - - - - 4 - - - 6
        // - - - - 2 8 7 - -
        // 9 5 - - - - - 8 4
        // - - 8 1 9 - - - -
        // 8 - - - 7 - - - -
        // - - - 5 - 9 3 - 8
        // - - 3 - - - 4 9 -

        public Puzzle(string[] puzzleInput)
        {
            Size = charToInt(puzzleInput[0][0]);
            if (!allowedSizes.Contains(Size))
            {
                // TODO: throw error
            }

            int blocksize = Convert.ToInt32(Math.Sqrt(Size));
            for (int y = 1; y <= Size; y++)  // 1 to account for the puzzle size number at y=0
            {
                for (int x = 0; x < Size; x++)
                {
                    Plane[y, x] = charToInt(puzzleInput[y][x]);
                }

                // TODO: make some kind of print function for this, and test it
            }
        }
    }
}
