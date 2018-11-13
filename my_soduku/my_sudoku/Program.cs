using my_sudoku;
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
            Puzzle puzzle = fileIO.ReadPuzzle("SamplePuzzles/Input/Puzzle-9x9-0001.txt");
            while (true)
            {
                if (Console.KeyAvailable)
                    break;
            }
        }
    }
}
