using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shapes
{
    public abstract class Shape
    {
        public bool IsComposited = false;
        public Pen pen = new Pen(Color.Black);

        /**
         * Move a shape
         *
         * @param deltaX            The delta x-location by which the line should be moved -- must be a valid double
         * @param deltaY            The delta y-location by which the line should be moved -- must be a valid double
         * @throws ShapeException   Exception throw if any parameter is invalid
         */
        public abstract void Move(double deltaX, double deltaY);

        /**
         * @return the area of the shape
         */
        public abstract double ComputeArea();

        /**
         * @return a string script representing all object attributes
         */
        public abstract string ToScript();

        /**
         * Render the shape to a given graphics object
         * 
         * @param graphics The graphics object to render the shape to.
         */
        public abstract void Draw(Graphics graphics);
    }
}
