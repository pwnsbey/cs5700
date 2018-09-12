using System;
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
            var square = new Square(1, 2, 3);
            Assert.AreEqual(1, square.GetPoint1().X);
            Assert.AreEqual(2, square.GetPoint2().Y);
            Assert.AreEqual(3, square.GetSide());
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            try
            {
                new Square(null, 3);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid corner point", e.Message);
            }

            try
            {
                new Square(new Point(1, 2), double.PositiveInfinity);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid side legnth", e.Message);
            }

            try
            {
                new Square(new Point(1, 2), double.NegativeInfinity);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid side legnth", e.Message);
            }

            try
            {
                new Square(new Point(1, 2), double.NaN);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid side legnth", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            Square square = new Square(1, 1, 3);
            square.Move(2, 3);
            Assert.AreEqual(3, square.GetPoint1().X);
            Assert.AreEqual(4, square.GetPoint1().Y);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            Square square = new Square(2, 2, 2);
            Assert.AreEqual(4, square.ComputeArea(), 0);
        }
    }
}
