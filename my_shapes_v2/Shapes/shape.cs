using System;

namespace Shapes
{
    public abstract class Shape
    {
        /**
         * Move a shape
         *
         * @param deltaX            The delta x-location by which the line should be moved -- must be a valid double
         * @param deltaY            The delta y-location by which the line should be moved -- must be a valid double
         * @throws ShapeException   Exception throw if any parameter is invalid
         */
        public abstract void Move(double deltaX, double deltaY);
    }
}
