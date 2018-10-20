using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class EmbeddedPictureTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            EmbeddedPicture embeddedPicture = sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, 5, 6);
            Assert.AreEqual(1, embeddedPicture.ImageBounds.Point1.X);
            Assert.AreEqual(2, embeddedPicture.ImageBounds.Point1.Y);
            Assert.AreEqual(5, embeddedPicture.ImageBounds.Point2.X);
            Assert.AreEqual(6, embeddedPicture.ImageBounds.Point2.Y);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", double.PositiveInfinity, 2, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, double.PositiveInfinity, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, double.PositiveInfinity, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, 3, double.PositiveInfinity);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", double.NegativeInfinity, 2, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, double.NegativeInfinity, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, double.NegativeInfinity, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, 3, double.NegativeInfinity);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", double.NaN, 2, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, double.NaN, 3, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, double.NaN, 4);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, 3, double.NaN);
                Assert.Fail("Expection exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeEmbeddedPicture("thinking.bmp", 1, 1, 1, 1);
                Assert.Fail("Exception exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("The two points must form a valid rectangle", e.Message);
            }
        }

        [TestMethod]
        public void TestMove()
        {
            ShapeFactory sf = new ShapeFactory();
            EmbeddedPicture embeddedPicture = sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, 5, 6);
            embeddedPicture.Move(2, 3);
            Assert.AreEqual(3, embeddedPicture.ImageBounds.Point1.X);
            Assert.AreEqual(5, embeddedPicture.ImageBounds.Point1.Y);
            Assert.AreEqual(7, embeddedPicture.ImageBounds.Point2.X);
            Assert.AreEqual(9, embeddedPicture.ImageBounds.Point2.Y);
        }

        [TestMethod]
        public void TestComputeArea()
        {
            ShapeFactory sf = new ShapeFactory();
            EmbeddedPicture embeddedPicture = sf.MakeEmbeddedPicture("thinking.bmp", 0, 0, 5, 6);
            Assert.AreEqual(30, embeddedPicture.ComputeArea(), 0);
        }

        [TestMethod]
        public void TestDraw()
        {
            ShapeFactory sf = new ShapeFactory();

            EmbeddedPicture embeddedPicture = sf.MakeEmbeddedPicture("thinking.bmp", 1, 2, 5, 6);
            Bitmap bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            embeddedPicture.Draw(g);
            bitmap.Save("embeddedPicture.bmp");
        }
    }
}
