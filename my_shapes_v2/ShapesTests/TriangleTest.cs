using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            var triangle = new Triangle(1, 1, 2, 2, 3, 3);
            Assert.AreEqual(1, triangle.Point1.X);
            Assert.AreEqual(1, triangle.Point1.Y);
            Assert.AreEqual(2, triangle.Point2.X);
            Assert.AreEqual(2, triangle.Point2.Y);
            Assert.AreEqual(3, triangle.Point3.X);
            Assert.AreEqual(3, triangle.Point3.Y);

            triangle = new Triangle(new Point(1, 1), new Point(2, 2), new Point(3, 3));
            Assert.AreEqual(1, triangle.Point1.X);
            Assert.AreEqual(1, triangle.Point1.Y);
            Assert.AreEqual(2, triangle.Point2.X);
            Assert.AreEqual(2, triangle.Point2.Y);
            Assert.AreEqual(3, triangle.Point3.X);
            Assert.AreEqual(3, triangle.Point3.Y);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            try
            {
                new Triangle(null, new Point(2, 2), new Point(3, 3));
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid corner point(s)", e.Message);
            }

            try
            {
                new Triangle(new Point(1, 1), null, new Point(3, 3));
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid corner point(s)", e.Message);
            }

            try
            {
                new Triangle(new Point(1, 1), new Point(2, 2), null);
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid corner point(s)", e.Message);
            }

            try
            {
                new Triangle(new Point(1, 1), new Point(1, 1), new Point(3, 3));
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Cannot have zero-length sides", e.Message);
            }

            try
            {
                new Triangle(new Point(1, 1), new Point(1, 2), new Point(1, 3));
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("All points may not be in a line", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            Triangle triangle = new Triangle(1, 1, 2, 2, 3, 3);
            triangle.Move(2, 4);
            Assert.AreEqual(3, triangle.Point1.X);
            Assert.AreEqual(5, triangle.Point1.Y);
            Assert.AreEqual(4, triangle.Point2.X);
            Assert.AreEqual(6, triangle.Point2.Y);
            Assert.AreEqual(5, triangle.Point3.X);
            Assert.AreEqual(7, triangle.Point3.Y);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            Triangle triangle = new Triangle(0, 0, 0, 2, 2, 0);
            Assert.AreEqual(2, triangle.ComputeArea(), .0001);
        }
    }
}
