using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class EllipseTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            Ellipse ellipse = sf.MakeEllipse(1, 3, 2.5, 3.5);
            Assert.AreEqual(1, ellipse.Center.X);
            Assert.AreEqual(3, ellipse.Center.Y);
            Assert.AreEqual(2.5, ellipse.VertRadius);
            Assert.AreEqual(3.5, ellipse.HorizRadius);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            try
            {
                sf.MakeEllipse(double.PositiveInfinity, 2, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEllipse(double.NegativeInfinity, 2, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEllipse(Double.NaN, 2, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, double.PositiveInfinity, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, double.NegativeInfinity, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, double.NaN, 3, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, 2, double.PositiveInfinity, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, 2, double.PositiveInfinity, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, 2, Double.NaN, 4);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, 2, 3, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, 2, 3, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                sf.MakeEllipse(1, 2, 3, Double.NaN);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new ShapeFactory();

            Ellipse myEllipse = sf.MakeEllipse(1, 2, 5, 6);
            Assert.AreEqual(1, myEllipse.Center.X, 0);
            Assert.AreEqual(2, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.VertRadius, 0);
            Assert.AreEqual(6, myEllipse.HorizRadius, 0);

            myEllipse.Move(3, 4);
            Assert.AreEqual(4, myEllipse.Center.X, 0);
            Assert.AreEqual(6, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.VertRadius, 0);
            Assert.AreEqual(6, myEllipse.HorizRadius, 0);

            myEllipse.Move(0.123, 0.456);
            Assert.AreEqual(4.123, myEllipse.Center.X, 0);
            Assert.AreEqual(6.456, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.VertRadius, 0);
            Assert.AreEqual(6, myEllipse.HorizRadius, 0);

            myEllipse.Move(-0.123, -0.456);
            Assert.AreEqual(4, myEllipse.Center.X, 0);
            Assert.AreEqual(6, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.VertRadius, 0);
            Assert.AreEqual(6, myEllipse.HorizRadius, 0);

            myEllipse.Move(-12, -26);
            Assert.AreEqual(-8, myEllipse.Center.X, 0);
            Assert.AreEqual(-20, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.VertRadius, 0);
            Assert.AreEqual(6, myEllipse.HorizRadius, 0);

            try
            {
                myEllipse.Move(double.PositiveInfinity, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myEllipse.Move(double.NegativeInfinity, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myEllipse.Move(double.NaN, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myEllipse.Move(1, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }

            try
            {
                myEllipse.Move(1, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }

            try
            {
                myEllipse.Move(1, double.NaN);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }
        }

        [TestMethod]
        public void TestScale()
        {
            ShapeFactory sf = new ShapeFactory();

            Ellipse myEllipse = sf.MakeEllipse(1, 2, 5, 6);
            Assert.AreEqual(1, myEllipse.Center.X, 0);
            Assert.AreEqual(2, myEllipse.Center.Y, 0);
            Assert.AreEqual(5, myEllipse.VertRadius, 0);
            Assert.AreEqual(6, myEllipse.HorizRadius, 0);

            myEllipse.Scale(3);
            Assert.AreEqual(1, myEllipse.Center.X, 0);
            Assert.AreEqual(2, myEllipse.Center.Y, 0);
            Assert.AreEqual(15, myEllipse.VertRadius, 0);
            Assert.AreEqual(18, myEllipse.HorizRadius, 0);

            myEllipse.Scale(0.2);
            Assert.AreEqual(1, myEllipse.Center.X, 0);
            Assert.AreEqual(2, myEllipse.Center.Y, 0);
            Assert.AreEqual(3, myEllipse.VertRadius, 0);
            Assert.AreEqual(3.6, myEllipse.HorizRadius, 0);

            try
            {
                myEllipse.Scale(double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (Exception)
            {
                // ignore
            }

            try
            {
                myEllipse.Scale(double.NegativeInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (Exception)
            {
                // ignore
            }

            try
            {
                myEllipse.Scale(double.NaN);
                Assert.Fail("Expected exception not thrown");
            }
            catch (Exception)
            {
                // ignore
            }
        }

        [TestMethod]
        public void TestComputeArea()
        {
            ShapeFactory sf = new ShapeFactory();

            Ellipse myEllipse = sf.MakeEllipse(1, 2, 5, 5);
            Assert.AreEqual(78.53975, myEllipse.ComputeArea(), 0.0001);

            myEllipse = new Ellipse(1, 2, 4.234, 4.234);
            Assert.AreEqual(56.3185174, myEllipse.ComputeArea(), 0.0001);

            myEllipse = new Ellipse(1, 2, 0, 0);
            Assert.AreEqual(0, myEllipse.ComputeArea(), 0);
        }

        [TestMethod]
        public void TestDraw()
        {
            ShapeFactory sf = new ShapeFactory();

            Ellipse myEllipse = sf.MakeEllipse(1, 3, 2.5, 3.5);
            Bitmap bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            myEllipse.Draw(g);
            bitmap.Save("ellipse.bmp");
        }
    }
}
