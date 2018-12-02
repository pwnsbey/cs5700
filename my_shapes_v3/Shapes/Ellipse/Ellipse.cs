using System;
using System.Drawing;

namespace Shapes
{
    public class Ellipse : Shape
    {
        public Point Center { get; set; }
        public double VertRadius { get; set;  }
        public double HorizRadius { get; set; }

        /**
         * Constructor with x-y Location for center
         *
         * @param x                 The x-location of the center of the ellipse -- must be a valid double
         * @param y                 The y-location of the center of the ellipse -- must be a valid double
         * @param vertRadius        The vertical radius of the ellipse -- must be greater or equal to zero.
         * @param horizRadius       The horizontal radius of the ellipse -- must be greater or equal to zero.
         * @throws ShapeException   The exception thrown if the x, y, or z are not valid
         */
        public Ellipse(double x, double y, double vertRadius, double horizRadius)
        {
            Validator.ValidatePositiveDouble(vertRadius, "Invalid radius");
            Validator.ValidatePositiveDouble(horizRadius, "Invalid radius");

            Center = new Point(x, y);
            VertRadius = vertRadius;
            HorizRadius = horizRadius;
        }

        /**
         * Constructor with a Point for center
         *
         * @param center            The Point location of the center of the ellipse -- must be a valid point
         * @param vertRadius        The vertical radius of the ellipse -- must be greater or equal to zero.
         * @param horizRadius       The horizontal radius of the ellipse -- must be greater or equal to zero.
         * @throws ShapeException   The exception thrown if the x, y, or z are not valid
         */
        public Ellipse(Point center, double vertRadius, double horizRadius) {

            Validator.ValidatePositiveDouble(vertRadius, "Invalid radius");
            Validator.ValidatePositiveDouble(horizRadius, "Invalid radius");
            if (center == null)
                throw new ShapeException("Invalid center point");

            Center = center;
            VertRadius = vertRadius;
            HorizRadius = horizRadius;
        }

        // exists to get the child class to stop whining about constructors
        protected Ellipse()
        { }

        /**
         * Move the ellipse
         * @param deltaX            a delta change for the x-location of center of the ellipse
         * @param deltaY            a delta change for the y-location of center of the ellipse
         * @throws ShapeException   Exception thrown if either the delta x or y are not valid doubles
         */
        public override void Move(double deltaX, double deltaY, double deltaZ = 0)
        {
            Center.Move(deltaX, deltaY, deltaZ);
        }

        /**
         * Scale the ellipse
         *
         * @param scaleFactor       a non-negative double that represents the percentage to scale the ellipse.
         *                          0>= and <1 to shrink.
         *                          >1 to grow.
         * @throws ShapeException   Exception thrown if the scale factor is not valid
         */
        public void Scale(double scaleFactor)
        {
            Validator.ValidatePositiveDouble(scaleFactor, "Invalid scale factor");
            VertRadius  *= scaleFactor;
            HorizRadius *= scaleFactor;
        }

        /**
         * @return  The area of the ellipse.
         */
        public override double ComputeArea()
        {
            return Math.PI * VertRadius * HorizRadius;
        }
    }
}
