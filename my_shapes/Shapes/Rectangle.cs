using System;

namespace Shapes
{
    public class Rectangle : ComplexShape
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }

        /**
         * Constructor with x-y for each corner
         * 
         * @param x1 The x-location for the first corner
         * @param y1 The y-location for the first corner
         * @param x2 The x-location for the second corner
         * @param y2 The y-location for the second corner
         */
        public Rectangle(double x1, double y1, double x2, double y2)
        {
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);

            ValidateRectangle(point1, point2);

            Point1 = point1;
            Point2 = point2;
        }

        /**
         * Constructor with Points for each corner
         * 
         * @param point1 The Point location for the first corner
         * @param point2 The Point location for the second corner
         */
        public Rectangle(Point point1, Point point2)
        {
            if (point1 == null || point2 == null)
                throw new ShapeException("Invalid corner point(s)");

            ValidateRectangle(point1, point2);

            Point1 = point1;
            Point2 = point2;
        }

        /**
         * In-class utility for use by constructors to make sure the user inputs a valid rectangle
         * 
         * @param point1 The first point of the rectangle
         * @param point2 The second point of the rectangle
         */
        private void ValidateRectangle(Point point1, Point point2)
        {
            // make sure the points are not on the same line
            if (point1.X == point2.X || point1.X == point2.Y || point1.Y == point2.X || point1.Y == point2.Y)
                throw new ShapeException("The two points must form a valid rectangle");
        }

        /*
         * @return The x-length of the rectangle
         */
        public double GetLength()
        {
            return Math.Abs(Point1.X - Point2.X);
        }

        /**
         * @return the y-height of the rectangle
         */
        public double GetHeight()
        {
            return Math.Abs(Point1.Y - Point2.Y);
        }

        /**
         * @return the area of the rectangle
         */
        public override double ComputeArea()
        {
            return GetLength() * GetHeight();
        }

        /**
         * Move the rectangle
         * @param deltaX            a delta change for both points of the rectangle
         * @param deltaY            a delta change for both points of the rectangle
         * @throws ShapeException   Exception thrown if either the delta x or y are not valid doubles
         */
        public override void Move(double deltaX, double deltaY)
        {
            Point1.Move(deltaX, deltaY);
            Point2.Move(deltaX, deltaY);
        }
    }
}
