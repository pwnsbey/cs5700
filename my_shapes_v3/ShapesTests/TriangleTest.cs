using System;
using System.Drawing;
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
            ShapeFactory sf = new TriangleFactory();

            Triangle triangle = (Triangle)sf.Create2dShape();
            triangle.Point1.X = 1;
            triangle.Point1.Y = 1;
            triangle.Point2.X = 2;
            triangle.Point2.Y = 2;
            triangle.Point3.X = 3;
            triangle.Point3.Y = 3;
            Assert.AreEqual(1, triangle.Point1.X);
            Assert.AreEqual(1, triangle.Point1.Y);
            Assert.AreEqual(2, triangle.Point2.X);
            Assert.AreEqual(2, triangle.Point2.Y);
            Assert.AreEqual(3, triangle.Point3.X);
            Assert.AreEqual(3, triangle.Point3.Y);
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new TriangleFactory();

            Triangle triangle = (Triangle)sf.Create2dShape();
            triangle.Point1.X = 1;
            triangle.Point1.Y = 1;
            triangle.Point2.X = 2;
            triangle.Point2.Y = 2;
            triangle.Point3.X = 3;
            triangle.Point3.Y = 3;
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
            ShapeFactory sf = new TriangleFactory();

            Triangle triangle = (Triangle)sf.Create2dShape();
            triangle.Point1.X = 1;
            triangle.Point1.Y = 1;
            triangle.Point2.X = 2;
            triangle.Point2.Y = 2;
            triangle.Point3.X = 3;
            triangle.Point3.Y = 3;
            Assert.AreEqual(2, triangle.ComputeArea(), .0001);
        }
    }
}
