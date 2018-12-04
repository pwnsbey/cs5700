using System;
using System.Drawing;

namespace Shapes
{
    public class Square: Rectangle
    {
        /**
         * Constructor with x-y for the corner
         * 
         * @param cornerX The x-location for the corner
         * @param cornerY The y-location for the corner
         * @param sideLength The length of a side (all sides are equal)
         */
        public Square(double cornerX, double cornerY, double sideLength)
        {
            Validator.ValidatePositiveDouble(sideLength, "Invalid side legnth");
            Point1 = new Point(cornerX, cornerY);
            Point2 = new Point(cornerX + sideLength, cornerY + sideLength);
        }

        /**
         * Constructor with point for the center
         * 
         * @param point The Point location for the corner
         * @param sideLength The length of a side (all sides are equal)
         */
        public Square (Point point, double sideLength)
        {
            Validator.ValidatePositiveDouble(sideLength, "Invalid side length");
            if (point == null)
                throw new ShapeException("Invalid corner point");

            Point1 = point;
            Point point2 = new Point(point.X + sideLength, point.Y + sideLength);
        }

        // exists to get the child class to stop whining about constructors
        public Square()
        { }
    }
}
