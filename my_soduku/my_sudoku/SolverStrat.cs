using sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_sudoku
{
    public abstract class SolverStrat
    {
        public bool CheckIfSolved(Puzzle puzzle)
        {
            bool isSolved = true;
            for (int x = 0; x < puzzle.Size; x++)
            {
                for (int y = 0; y < puzzle.Size; y++)
                {
                    if (puzzle.Plane[x, y] == '-')
                    {
                        isSolved = false;
                    }
                }
            }
            return isSolved;
        }

        public List<char> GetPossibilities(Puzzle puzzle, int x, int y)
        {
            List<char> possibilities = new List<char>();
            for (int i = 1; i <= puzzle.Size; i++)
            {
                possibilities.Add(i.ToString()[0]);
            }
            char[] colNeighbors = GetInCol(puzzle, x, y);
            char[] rowNeighbors = GetInRow(puzzle, x, y);
            char[] blockNeighbors = GetInBlock(puzzle, x, y);
            for (int i = 0; i < puzzle.Size; i++)
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

        public char[] GetInCol(Puzzle puzzle, int x, int y)
        {
            char[] returnArray = new char[puzzle.Size];
            for (int i = 0; i < puzzle.Size; i++)
            {
                returnArray[i] = puzzle.Plane[x, i];
            }
            return returnArray;
        }

        public char[] GetInRow(Puzzle puzzle, int x, int y)
        {
            char[] returnArray = new char[puzzle.Size];
            for (int i = 0; i < puzzle.Size; i++)
            {
                returnArray[i] = puzzle.Plane[i, y];
            }
            return returnArray;
        }

        public char[] GetInBlock(Puzzle puzzle, int x, int y)
        {
            char[] returnArray = new char[puzzle.Size];
            int xStart = 0;
            int xEnd = puzzle.Blocksize - 1;
            int yStart = 0;
            int yEnd = puzzle.Blocksize - 1;

            while (xEnd < x)
                xEnd += puzzle.Blocksize;
            xStart = xEnd - puzzle.Blocksize + 1;

            while (yEnd < y)
                yEnd += puzzle.Blocksize;
            yStart = yEnd - puzzle.Blocksize + 1;

            int insertIndex = 0;
            for (int i = yStart; i <= yEnd; i++)
            {
                for (int j = xStart; j <= xEnd; j++)
                {
                    returnArray[insertIndex] = puzzle.Plane[i, j];
                    insertIndex++;
                }
            }

            return returnArray;
        }

        public abstract Puzzle Solve(Puzzle puzzle);
    }
}
