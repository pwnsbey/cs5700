using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            ShapeFactory sf = new RectangleFactory();

            Shapes.Rectangle rectangle = (Shapes.Rectangle)sf.Create2dShape();
            rectangle.Point1.X = 1;
            rectangle.Point1.Y = 2;
            rectangle.Point2.X = 5;
            rectangle.Point2.Y = 6;
            Assert.AreEqual(1, rectangle.Point1.X);
            Assert.AreEqual(2, rectangle.Point1.Y);
            Assert.AreEqual(5, rectangle.Point2.X);
            Assert.AreEqual(6, rectangle.Point2.Y);
        }

        [TestMethod]
        public void TestGetLength()
        {
            ShapeFactory sf = new RectangleFactory();

            Shapes.Rectangle rectangle = (Shapes.Rectangle)sf.Create2dShape();
            rectangle.Point1.X = 2;
            rectangle.Point1.Y = 2;
            rectangle.Point2.X = 4;
            rectangle.Point2.Y = 4;
            Assert.AreEqual(2, rectangle.GetLength());
        }

        [TestMethod]
        public void TestGetHeight()
        {
            ShapeFactory sf = new RectangleFactory();

            Shapes.Rectangle rectangle = (Shapes.Rectangle)sf.Create2dShape();
            rectangle.Point1.X = 2;
            rectangle.Point1.Y = 2;
            rectangle.Point2.X = 4;
            rectangle.Point2.Y = 4;
            Assert.AreEqual(2, rectangle.GetHeight());
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new RectangleFactory();

            Shapes.Rectangle rectangle = (Shapes.Rectangle)sf.Create2dShape();
            rectangle.Point1.X = 1;
            rectangle.Point1.Y = 2;
            rectangle.Point2.X = 5;
            rectangle.Point2.Y = 6;
            rectangle.Move(2, 3);
            Assert.AreEqual(3, rectangle.Point1.X);
            Assert.AreEqual(5, rectangle.Point1.Y);
            Assert.AreEqual(7, rectangle.Point2.X);
            Assert.AreEqual(9, rectangle.Point2.Y);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            ShapeFactory sf = new RectangleFactory();

            Shapes.Rectangle rectangle = (Shapes.Rectangle)sf.Create2dShape();
            rectangle.Point1.X = 0;
            rectangle.Point1.Y = 0;
            rectangle.Point2.X = 5;
            rectangle.Point2.Y = 6;
            Assert.AreEqual(30, rectangle.ComputeArea(), 0);
        }
    }
}
