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
            ShapeFactory sf = new ShapeFactory();

            Square square = sf.MakeSquare(1, 2, 3);
            Assert.AreEqual(1, square.GetPoint1().X);
            Assert.AreEqual(2, square.GetPoint1().Y);
            Assert.AreEqual(3, square.GetSide());
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            try
            {
                sf.MakeSquare(double.NegativeInfinity, 2, 3);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeSquare(1, double.NegativeInfinity, 3);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeSquare(1, 2, double.PositiveInfinity);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid side length", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new ShapeFactory();

            Square square = sf.MakeSquare(1, 1, 3);
            square.Move(2, 3);
            Assert.AreEqual(3, square.GetPoint1().X);
            Assert.AreEqual(4, square.GetPoint1().Y);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            ShapeFactory sf = new ShapeFactory();

            Square square = sf.MakeSquare(2, 2, 2);
            Assert.AreEqual(4, square.ComputeArea(), 0);
        }

        [TestMethod]
        public void TestDraw()
        {
            ShapeFactory sf = new ShapeFactory();

            Square mySquare = sf.MakeSquare(1, 2, 3);
            Bitmap bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            mySquare.Draw(g);
            bitmap.Save("square.bmp");
        }
    }
}
