using System;
using System.Drawing;

namespace Shapes
{
    public class Triangle : Shape
    {
        public Point Point1 { get; protected set; }
        public Point Point2 { get; protected set; }
        public Point Point3 { get; protected set; }

        /**
         * Constructor with x-y location for all three points
         * 
         * @param x1 The x-location of the first point -- must be a valid double
         * @param y1 The y-location of the first point -- must be a valid double
         * @param x2 The x-location of the second point -- must be a valid double
         * @param y2 The y-location of the second point -- must be a valid double
         * @param x3 The x-location of the third point -- must be a valid double
         * @param y3 The y-location of the third point -- must be a valid double
         */
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);

            ValidateTriangle(point1, point2, point3);

            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        /**
         * Constructor with a Point for all three points
         * 
         * @param point1 The location of the first point -- must be a valid Point
         * @param point2 The location of the second point -- must be a valid Point
         * @param point3 The location of the third point -- must be a valid Point
         */
        public Triangle(Point point1, Point point2, Point point3)
        {
            if (point1 == null || point2 == null || point3 == null)
                throw new ShapeException("Invalid corner point(s)");

            ValidateTriangle(point1, point2, point3);

            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        // exists to get the child class to stop whining about constructors
        public Triangle()
        { }

        /**
         * In-class utility for use by constructors to make sure user input creates a valid triangle
         * 
         * @param point1 The first point
         * @param point2 The second point
         * @param point3 The third point
         */
        protected void ValidateTriangle(Point point1, Point point2, Point point3)
        {
            if (point1.EqualToPoint(point2) || point1.EqualToPoint(point3) || point2.EqualToPoint(point3))
                throw new ShapeException("Cannot have zero-length sides");

            if ((point1.X == point2.X && point2.X == point3.X) || (point1.Y == point2.Y && point2.Y == point3.Y))
                throw new ShapeException("All points may not be in a line");
        }

        /**
         * @return The area of the triangle
         */
        public override double ComputeArea()
        {
            double sideALen = new Line(Point1, Point2).ComputeLength();
            double sideBLen = new Line(Point2, Point3).ComputeLength();
            double sideCLen = new Line(Point3, Point1).ComputeLength();

            double semiperimeter = (sideALen + sideBLen + sideCLen) / 2;

            return Math.Sqrt(semiperimeter * (semiperimeter - sideALen) * (semiperimeter - sideBLen) * (semiperimeter - sideCLen));
        }

        public override void Move(double deltaX, double deltaY, double deltaZ = 0)
        {
            Point1.Move(deltaX, deltaY, deltaZ);
            Point2.Move(deltaX, deltaY, deltaZ);
            Point3.Move(deltaX, deltaY, deltaZ);
        }
    }
}
