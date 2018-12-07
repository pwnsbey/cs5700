using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shapes
{
    public class Circle : Shape
    {
        public Ellipse Ellipse;

        /**
         * Constructor with x-y Location for center
         *
         * @param x                 The x-location of the center of the circle -- must be a valid double
         * @param y                 The y-location of the center of the circle
         * @param radius            The radius of the circle -- must be greater or equal to zero.
         */
        public Circle(double x, double y, double radius)
        {
            Ellipse = new Ellipse(x, y, radius, radius);
        }

        /**
         * Constructor with a Point for center
         *
         * @param center            The x-location of the center of the circle -- must be a valid point
         * @param radius            The radius of the circle -- must be greater or equal to zero.
         */
        public Circle(Point center, double radius)
        {
            Ellipse = new Ellipse(center, radius, radius);
        }

        // exists to get the child class to stop whining about constructors
        protected Circle()
        { }

        public void SetCenter(double x, double y)
        {
            Ellipse.Center.X = x;
            Ellipse.Center.Y = y;
        }

        public void SetRadius(double radius)
        {
            Ellipse.HorizRadius = radius;
            Ellipse.VertRadius = radius;
        }

        /**
         * @return the center of the circle as a Point
         */
        public Point GetCenter()
        {
            return Ellipse.Center;
        }

        /*
         * @return the radius of the circle
         */
        public double GetRadius()
        {
            return Ellipse.VertRadius;
        }

        /**
         * Move the circle
         * @param deltaX            a delta change for the x-location of center of the circle
         * @param deltaY            a delta change for the y-location of center of the circle
         */
        public override void Move(double deltaX, double deltaY, double deltaZ = 0)
        {
            Ellipse.Move(deltaX, deltaY, deltaZ);
        }

        /**
         * Scale the circle
         *
         * @param scaleFactor       a non-negative double that represents the percentage to scale the circle.
         *                          0>= and <1 to shrink.
         *                          >1 to grow.
         */
        public void Scale(double scaleFactor)
        {
            Ellipse.Scale(scaleFactor);
        }

        /**
         * @return  The area of the circle.
         */
        public override double ComputeArea()
        {
            return Ellipse.ComputeArea();
        }
    }
}
