using System;

namespace Shapes
{
    public class Square: Shape
    {
        private Rectangle Rectangle;

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
            Rectangle = new Rectangle(cornerX, cornerY, cornerX + sideLength, cornerY + sideLength);
        }

        /**
         * Constructor with point for the center
         * 
         * @param point The Point location for the corner
         * @param sideLength The length of a side (all sides are equal)
         */
        public Square (Point point, double sideLength)
        {
            Validator.ValidatePositiveDouble(sideLength, "Invalid side legnth");
            if (point == null)
                throw new ShapeException("Invalid corner point");

            Point point2 = new Point(point.X + sideLength, point.Y + sideLength);
            Rectangle = new Rectangle(point, point2);
        }

        /**
         * @return the first point of the square
         */
        public Point GetPoint1()
        {
            return Rectangle.Point1;
        }
        
        /**
         * @return the second point of the square
         */
        public Point GetPoint2()
        {
            return Rectangle.Point2;
        }

        /**
         * @return the length of a side (all sides are equal)
         */
        public double GetSide()
        {
            return Rectangle.GetHeight();
        }

        /**
         * @return the area of the square
         */
        public override double ComputeArea()
        {
            return Rectangle.ComputeArea();
        }

        /**
         * Move the square
         * @param deltaX            a delta change for both points of the square
         * @param deltaY            a delta change for both points of the square
         * @throws ShapeException   Exception thrown if either the delta x or y are not valid doubles
         */
        public override void Move(double deltaX, double deltaY)
        {
            Rectangle.Move(deltaX, deltaY);
        }

        public override string ToScript()
        {
            return "shape:square,cornerx:" + Rectangle.Point1.X.ToString() + ",cornery:" +
                   Rectangle.Point1.Y.ToString() + ",sidelength:" + GetSide().ToString();
        }
    }
}
