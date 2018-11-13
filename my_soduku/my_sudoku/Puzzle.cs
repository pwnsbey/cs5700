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
        public int Blocksize;
        public char[,] Plane;

        private int[] allowedSizes = new int[] { 4, 9, 16, 25 };

        private int CharToInt(char c)
        {
            return (int)char.GetNumericValue(c);
        }

        public void PrintPuzzle()
        {
            for (int y = 0; y < Size; y++ )
            {
                for (int x = 0; x < Size; x++ )
                {
                    Console.Write(Plane[y, x] + " ");
                }
                Console.Write('\n');
            }
        }

        public char[] GetInCol(int x, int y)
        {
            char[] returnArray = new char[Size];
            for (int i = 0; i < Size; i++ )
            {
                returnArray[i] = Plane[i, x];
            }
            return returnArray;
        }

        public char[] GetInRow(int x, int y)
        {
            char[] returnArray = new char[Size];
            for (int i = 0; i < Size; i++ )
            {
                returnArray[i] = Plane[y, i];
            }
            return returnArray;
        }

        public char[] GetInBlock(int x, int y)
        {
            char[] returnArray = new char[Size];
            int xStart = 0;
            int xEnd = Blocksize-1;
            int yStart = 0;
            int yEnd = Blocksize-1;

            while (xEnd < x)
                xEnd += Blocksize;
            xStart = xEnd - 2;

            while (yEnd < y)
                yEnd += Blocksize;
            yStart = yEnd - 2;

            int insertIndex = 0;
            for (int i = yStart; i <= yEnd; i++ )
            {
                for (int j = xStart; j <= xEnd; j++ )
                {
                    returnArray[insertIndex] = Plane[i, j];
                    insertIndex++;
                }
            }

            return returnArray;
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
            for (int y = 2; y <= Size+1; y++)  // 1 to account for the puzzle size number at y=0
            {
                puzzleInput[y] = puzzleInput[y].Replace(" ", "");
                for (int x = 0; x < Size; x++)
                {
                    Plane[y-2, x] = puzzleInput[y][x];
                }
            }

            PrintPuzzle();
        }
    }
}
