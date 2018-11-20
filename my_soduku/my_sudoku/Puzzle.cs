using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    public class Puzzle
    {
        public int Size;
        public int Blocksize;
        public char[,] Plane;

        private int[] allowedSizes = new int[] { 4, 9, 16, 25 };

        private int CharToInt(char c)
        {
            return (int)char.GetNumericValue(c);
        }

        public void PrintPuzzle()
        {
            for (int x = 0; x < Size; x++ )
            {
                for (int y = 0; y < Size; y++ )
                {
                    Console.Write(Plane[x, y] + " ");
                }
                Console.Write('\n');
            }
        }

        public Puzzle(string[] puzzleInput)
        {
            Size = CharToInt(puzzleInput[0][0]);
            if (!allowedSizes.Contains(Size))
            {
                // TODO: throw error
            }
            Blocksize = Convert.ToInt32(Math.Sqrt(Size));
            Plane = new char[Size, Size];
            for (int x = 2; x <= Size+1; x++)  // 1 to account for the puzzle size number at y=0
            {
                puzzleInput[x] = puzzleInput[x].Replace(" ", "");
                for (int y = 0; y < Size; y++)
                {
                    Plane[x-2, y] = puzzleInput[x][y];
                }
            }

            PrintPuzzle();
        }

        public Puzzle(Puzzle puzzle)
        {
            Size = puzzle.Size;
            Blocksize = puzzle.Blocksize;
            Plane = new char[Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Plane[x, y] = puzzle.Plane[x, y];
                }
            }
        }
    }
}
