﻿using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void TestValidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();
            
            Circle circle = sf.MakeCircle(1, 3, 2.5);
            Assert.AreEqual(1, circle.GetCenter().X);
            Assert.AreEqual(3, circle.GetCenter().Y);
            Assert.AreEqual(2.5, circle.GetRadius());
        }

        [TestMethod]
        public void TestInvalidConstruction()
        {
            ShapeFactory sf = new ShapeFactory();

            try
            {
                sf.MakeCircle(double.PositiveInfinity, 2, 3);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeCircle(double.NegativeInfinity, 2, 3);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeCircle(Double.NaN, 2, 3);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid x-location point", e.Message);
            }

            try
            {
                sf.MakeCircle(1, double.PositiveInfinity, 3);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeCircle(1, double.NegativeInfinity, 3);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeCircle(1, double.NaN, 3);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid y-location point", e.Message);
            }

            try
            {
                sf.MakeCircle(1, 2, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                sf.MakeCircle(1, 2, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }

            try
            {
                sf.MakeCircle(1, 2, Double.NaN);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid radius", e.Message);
            }
        }

        [TestMethod]
        public void TestMove() {
            ShapeFactory sf = new ShapeFactory();

            Circle myCircle = sf.MakeCircle(1, 2, 5);
            Assert.AreEqual(1, myCircle.GetCenter().X, 0);
            Assert.AreEqual(2, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(5, myCircle.GetRadius(), 0);

            myCircle.Move(3, 4);
            Assert.AreEqual(4, myCircle.GetCenter().X, 0);
            Assert.AreEqual(6, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(5, myCircle.GetRadius(), 0);

            myCircle.Move(0.123, 0.456);
            Assert.AreEqual(4.123, myCircle.GetCenter().X, 0);
            Assert.AreEqual(6.456, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(5, myCircle.GetRadius(), 0);

            myCircle.Move(-0.123, -0.456);
            Assert.AreEqual(4, myCircle.GetCenter().X, 0);
            Assert.AreEqual(6, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(5, myCircle.GetRadius(), 0);

            myCircle.Move(-12, -26);
            Assert.AreEqual(-8, myCircle.GetCenter().X, 0);
            Assert.AreEqual(-20, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(5, myCircle.GetRadius(), 0);

            try
            {
                myCircle.Move(double.PositiveInfinity, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myCircle.Move(double.NegativeInfinity, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myCircle.Move(double.NaN, 1);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-x value", e.Message);
            }

            try
            {
                myCircle.Move(1, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }

            try
            {
                myCircle.Move(1, double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }

            try
            {
                myCircle.Move(1, double.NaN);
                Assert.Fail("Expected exception not thrown");
            }
            catch (ShapeException e)
            {
                Assert.AreEqual("Invalid delta-y value", e.Message);
            }
        }

        [TestMethod]
        public void TestScale() {
            ShapeFactory sf = new ShapeFactory();

            Circle myCircle = sf.MakeCircle(1, 2, 5);
            Assert.AreEqual(1, myCircle.GetCenter().X, 0);
            Assert.AreEqual(2, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(5, myCircle.GetRadius(), 0);

            myCircle.Scale(3);
            Assert.AreEqual(1, myCircle.GetCenter().X, 0);
            Assert.AreEqual(2, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(15, myCircle.GetRadius(), 0);

            myCircle.Scale(0.2);
            Assert.AreEqual(1, myCircle.GetCenter().X, 0);
            Assert.AreEqual(2, myCircle.GetCenter().Y, 0);
            Assert.AreEqual(3, myCircle.GetRadius(), 0);

            try
            {
                myCircle.Scale(double.PositiveInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (Exception)
            {
                // ignore
            }

            try
            {
                myCircle.Scale(double.NegativeInfinity);
                Assert.Fail("Expected exception not thrown");
            }
            catch (Exception)
            {
                // ignore
            }

            try
            {
                myCircle.Scale(double.NaN);
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

            Circle myCircle = sf.MakeCircle(1, 2, 5);
            Assert.AreEqual(78.53975, myCircle.ComputeArea(), 0.0001);

            myCircle = new Circle(1, 2, 4.234);
            Assert.AreEqual(56.3185174, myCircle.ComputeArea(), 0.0001);

            myCircle = new Circle(1, 2, 0);
            Assert.AreEqual(0, myCircle.ComputeArea(), 0);

        }

        [TestMethod]
        public void TestDraw()
        {
            ShapeFactory sf = new ShapeFactory();

            Circle myCircle = sf.MakeCircle(5, 5, 2);
            Bitmap bitmap = new Bitmap(1024, 1024, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            myCircle.Draw(g);
            bitmap.Save("circle.bmp");
        }
    }
}
