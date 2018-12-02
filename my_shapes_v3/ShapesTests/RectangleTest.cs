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
            ShapeFactory sf = new ShapeFactory();
            var rectangle = sf.MakeRectangle(1, 2, 5, 6);
            Assert.AreEqual(1, rectangle.Point1.X);
            Assert.AreEqual(2, rectangle.Point1.Y);
            Assert.AreEqual(5, rectangle.Point2.X);
            Assert.AreEqual(6, rectangle.Point2.Y);

            rectangle = sf.MakeRectangle(1.22, 8.87, 12.1, 13.52);
            Assert.AreEqual(1.22, rectangle.Point1.X);
            Assert.AreEqual(8.87, rectangle.Point1.Y);
            Assert.AreEqual(12.1, rectangle.Point2.X);
            Assert.AreEqual(13.52, rectangle.Point2.Y);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            try
            {
                sf.MakeRectangle(double.PositiveInfinity, 2, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, double.PositiveInfinity, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, 2, double.PositiveInfinity, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, 2, 3, double.PositiveInfinity);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(double.NegativeInfinity, 2, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, double.NegativeInfinity, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, 2, double.NegativeInfinity, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, 2, 3, double.NegativeInfinity);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(double.NaN, 2, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, double.NaN, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, 2, double.NaN, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, 2, 3, double.NaN);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeRectangle(1, 1, 1, 1);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("The two points must form a valid rectangle", e.Message);
            }
        }

        [TestMethod]
        public void TestGetLength()
        {
            ShapeFactory sf = new ShapeFactory();
            var rectangle = sf.MakeRectangle(2, 2, 4, 4);
            Assert.AreEqual(2, rectangle.GetLength());
        }

        [TestMethod]
        public void TestGetHeight()
        {
            ShapeFactory sf = new ShapeFactory();
            var rectangle = sf.MakeRectangle(2, 2, 4, 4);
            Assert.AreEqual(2, rectangle.GetHeight());
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new ShapeFactory();
            Shapes.Rectangle rectangle = sf.MakeRectangle(1, 2, 5, 6);
            rectangle.Move(2, 3);
            Assert.AreEqual(3, rectangle.Point1.X);
            Assert.AreEqual(5, rectangle.Point1.Y);
            Assert.AreEqual(7, rectangle.Point2.X);
            Assert.AreEqual(9, rectangle.Point2.Y);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            ShapeFactory sf = new ShapeFactory();
            Shapes.Rectangle rectangle = sf.MakeRectangle(0, 0, 5, 6);
            Assert.AreEqual(30, rectangle.ComputeArea(), 0);
        }

        [TestMethod]
        public void TestDraw()
        {
            ShapeFactory sf = new ShapeFactory();

            Shapes.Rectangle myRectangle = sf.MakeRectangle(1, 2, 5, 6);
            Bitmap bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            myRectangle.Draw(g);
            bitmap.Save("rectangle.bmp");
        }
    }
}
