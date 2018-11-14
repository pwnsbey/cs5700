﻿using my_sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beginning...");
            FileIO fileIO = new FileIO();
            Puzzle puzzle = fileIO.ReadPuzzle("SamplePuzzles/Input/Puzzle-4x4-0903.txt");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("BEGIN");
            Solver solver = new Solver();
            solver.Solve(puzzle);
            while (true)
            {
                if (Console.KeyAvailable)
                    break;
            }
        }
    }
}
