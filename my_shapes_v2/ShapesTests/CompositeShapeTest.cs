using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class CompositeShapeTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            CompositeShape compositeShape = sf.MakeCompositeShape(2, 3);
            Assert.AreEqual(compositeShape.Center.X, 2);
            Assert.AreEqual(compositeShape.Center.Y, 3);
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            try
            {
                sf.MakeCompositeShape(double.PositiveInfinity, 3);
                Assert.Fail("Exception expetion not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeCompositeShape(2, double.PositiveInfinity);
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

            CompositeShape compositeShape = sf.MakeCompositeShape(1, 1);
            compositeShape.Move(1, 1);
            Assert.AreEqual(2, compositeShape.Center.X);
            Assert.AreEqual(2, compositeShape.Center.Y);
        }

        [TestMethod]
        public void TestAddShape()
        {
            ShapeFactory sf = new ShapeFactory();

            CompositeShape compositeShape = sf.MakeCompositeShape(1, 1);
            Circle testCircle = sf.MakeCircle(3, 2, 2);
            compositeShape.AddShape(testCircle);
            Assert.AreEqual(testCircle, compositeShape.GetShapes()[0]);
        }

        [TestMethod]
        public void TestRemoveShape()
        {
            ShapeFactory sf = new ShapeFactory();

            CompositeShape compositeShape = sf.MakeCompositeShape(1, 1);
            Circle testCircle = sf.MakeCircle(3, 2, 2);
            compositeShape.AddShape(testCircle);
            Assert.AreEqual(1, compositeShape.GetShapes().Count);
            compositeShape.RemoveShape(0);
            Assert.AreEqual(0, compositeShape.GetShapes().Count);
        }



        [TestMethod]
        public void TestClearShapes()
        {
            ShapeFactory sf = new ShapeFactory();

            CompositeShape compositeShape = sf.MakeCompositeShape(1, 1);
            compositeShape.AddShape(sf.MakeCircle(3, 2, 2));
            compositeShape.AddShape(sf.MakePoint(1, 1));
            Assert.AreEqual(compositeShape.GetShapes().Count, 2);
            compositeShape.ClearShapes();
            Assert.AreEqual(compositeShape.GetShapes().Count, 0);
        }
            
        [TestMethod]
        public void TestComputeArea()
        {
            ShapeFactory sf = new ShapeFactory();

            CompositeShape compositeShape = sf.MakeCompositeShape(2, 3);
            Assert.AreEqual(compositeShape.ComputeArea(), 0);
            compositeShape.AddShape(sf.MakeCircle(1, 2, 5));
            Assert.AreEqual(78.53975, compositeShape.ComputeArea(), 0.0001);
        }

        [TestMethod]
        public void TestDraw()
        {
            ShapeFactory sf = new ShapeFactory();

            CompositeShape compositeShape = sf.MakeCompositeShape(1, 1);
            compositeShape.AddShape(sf.MakeCircle(2, 2, 2));
            Bitmap bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            compositeShape.Draw(g);
            bitmap.Save("compositeShape.bmp");
        }
    }
}
