using sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_sudoku
{
    public class FileIO
    {
        public Puzzle ReadPuzzle(string filename)
        {
            return new Puzzle(System.IO.File.ReadAllLines(filename));
        }
    }
}
