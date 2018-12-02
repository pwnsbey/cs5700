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
            ShapeFactory sf = new ShapeFactory();

            var triangle = sf.MakeTriangle(1, 1, 2, 2, 3, 3);
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
            ShapeFactory sf = new ShapeFactory();

            try
            {
                sf.MakeTriangle(double.PositiveInfinity, 1, 2, 2, 3, 3);
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeTriangle(1, double.NegativeInfinity, 2, 2, 3, 3);
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new ShapeFactory();

            Triangle triangle = sf.MakeTriangle(1, 1, 2, 2, 3, 3);
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
            ShapeFactory sf = new ShapeFactory();

            Triangle triangle = sf.MakeTriangle(0, 0, 0, 2, 2, 0);
            Assert.AreEqual(2, triangle.ComputeArea(), .0001);
        }

        [TestMethod]
        public void TestDraw()
        {
            ShapeFactory sf = new ShapeFactory();

            Triangle myTriange = sf.MakeTriangle(1, 1, 2, 2, 3, 3);
            Bitmap bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            myTriange.Draw(g);
            bitmap.Save("triangle.bmp");
        }
    }
}
