using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sudoku;
using my_sudoku;

namespace sudokuTest
{
    [TestClass]
    public class SolverStratTest
    {
        string puzzleIncomplete = "SamplePuzzles/Input/Puzzle-4x4-0001.txt";
        string puzzleComplete = "SamplePuzzles/Input/Puzzle-4x4-0001 - Complete.txt";

        [TestMethod]
        public void TestCheckIfSolved()
        {
            RemainderStrat solverStrat = new RemainderStrat();
            FileIO fileIO = new FileIO();
            Puzzle newPuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            Assert.AreEqual(solverStrat.CheckIfSolved(newPuzzle), false);
            newPuzzle = fileIO.ReadPuzzle(puzzleComplete);
            Assert.AreEqual(solverStrat.CheckIfSolved(newPuzzle), true);
        }

        [TestMethod]
        public void TestGetPossibilities()
        {
            RemainderStrat solverStrat = new RemainderStrat();
            FileIO fileIO = new FileIO();
            Puzzle newPuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            Assert.AreEqual(solverStrat.GetPossibilities(newPuzzle, 1, 0), '4');
        }

        [TestMethod]
        public void TestGetInCol()
        {
            RemainderStrat solverStrat = new RemainderStrat();
            FileIO fileIO = new FileIO();
            Puzzle newPuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            string inCol = "-312";
            Assert.AreEqual(solverStrat.GetInCol(newPuzzle, 1, 0), inCol);
        }

        [TestMethod]
        public void TestGetInRow()
        {
            RemainderStrat solverStrat = new RemainderStrat();
            FileIO fileIO = new FileIO();
            Puzzle newPuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            string inRow = "2-31";
            Assert.AreEqual(solverStrat.GetInCol(newPuzzle, 1, 0), inRow);
        }

        [TestMethod]
        public void TestGetInBlock()
        {
            RemainderStrat solverStrat = new RemainderStrat();
            FileIO fileIO = new FileIO();
            Puzzle newPuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            string inBlock = "2-13";
            Assert.AreEqual(solverStrat.GetInCol(newPuzzle, 1, 1), inBlock);
        }

        [TestMethod]
        public void TestRemainderSolve()
        {
            RemainderStrat remainderStrat = new RemainderStrat();
            FileIO fileIO = new FileIO();
            Puzzle incompletePuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            Puzzle completePuzzle = fileIO.ReadPuzzle(puzzleComplete);
            Assert.AreEqual(remainderStrat.Solve(incompletePuzzle).Plane, completePuzzle.Plane);
        }

        [TestMethod]
        public void TestDadSolve()
        {
            DadStrat dadStrat = new DadStrat();
            FileIO fileIO = new FileIO();
            Puzzle incompletePuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            Puzzle completePuzzle = fileIO.ReadPuzzle(puzzleComplete);
            Assert.AreEqual(dadStrat.Solve(incompletePuzzle).Plane, completePuzzle.Plane);
        }

        [TestMethod]
        public void TestVexSolve()
        {
            VexStrat vexStrat = new VexStrat();
            FileIO fileIO = new FileIO();
            Puzzle incompletePuzzle = fileIO.ReadPuzzle(puzzleIncomplete);
            Puzzle completePuzzle = fileIO.ReadPuzzle(puzzleComplete);
            Assert.AreEqual(vexStrat.Solve(incompletePuzzle).Plane, completePuzzle.Plane);
        }
    }
}
