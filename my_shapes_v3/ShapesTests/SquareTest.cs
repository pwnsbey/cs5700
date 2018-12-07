using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class SquareTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            ShapeFactory sf = new SquareFactory();

            Square square = (Square)sf.Create2dShape();
            square.SetSquare(1, 2, 3);
            Assert.AreEqual(1, square.Point1.X);
            Assert.AreEqual(2, square.Point1.Y);
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new SquareFactory();

            Square square = (Square)sf.Create2dShape();
            square.SetSquare(1, 2, 3);
            square.Move(2, 3);
            Assert.AreEqual(3, square.Point1.X);
            Assert.AreEqual(5, square.Point1.Y);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            ShapeFactory sf = new SquareFactory();

            Square square = (Square)sf.Create2dShape();
            square.SetSquare(2, 2, 2);
            Assert.AreEqual(4, square.ComputeArea(), 0);
        }
    }
}
