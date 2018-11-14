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
            for (int x = 0; x < Size; x++ )
            {
                for (int y = 0; y < Size; y++ )
                {
                    Console.Write(Plane[x, y] + " ");
                }
                Console.Write('\n');
            }
        }

        public bool CheckIfSolved()
        {
            bool isSolved = true;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (Plane[x, y] == '-')
                    {
                        isSolved = false;
                    }
                }
            }
            return isSolved;
        }

        public List<char> GetPossibilities(int x, int y)
        {
            List<char> possibilities = new List<char>();
            for (int i = 0; i < Size; i++)
            {
                possibilities.Add(i.ToString()[0]);
            }
            char[] colNeighbors = GetInCol(x, y);
            char[] rowNeighbors = GetInRow(x, y);
            char[] blockNeighbors = GetInBlock(x, y);
            for (int i = 0; i < Size; i++)
            {
                if (colNeighbors[i] != '-')
                    possibilities.Remove(colNeighbors[i]);
                if (rowNeighbors[i] != '-')
                    possibilities.Remove(rowNeighbors[i]);
                if (blockNeighbors[i] != '-')
                    possibilities.Remove(blockNeighbors[i]);
            }
            return possibilities;
        }

        public char[] GetInCol(int x, int y)
        {
            char[] returnArray = new char[Size];
            for (int i = 0; i < Size; i++ )
            {
                returnArray[i] = Plane[x, i];
            }
            return returnArray;
        }

        public char[] GetInRow(int x, int y)
        {
            char[] returnArray = new char[Size];
            for (int i = 0; i < Size; i++ )
            {
                returnArray[i] = Plane[i, y];
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
            xStart = xEnd - Blocksize + 1;

            while (yEnd < y)
                yEnd += Blocksize;
            yStart = yEnd - Blocksize + 1;

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
