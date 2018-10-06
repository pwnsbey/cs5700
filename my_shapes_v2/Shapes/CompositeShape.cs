using System;
using System.Collections.Generic;

namespace Shapes
{
    public class CompositeShape: Shape
    {
        private List<Shape> Shapes;

        public List<Shape> GetShapes()
        {
            return Shapes;
        }

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void RemoveShape(int shapeIndex)
        {
            Shapes.RemoveAt(shapeIndex);
        }

        public void ClearShapes()
        {
            Shapes.Clear();
        }

        public override double ComputeArea()
        {
            double totalArea = 0;

            foreach (Shape shape in Shapes)
                totalArea += shape.ComputeArea();

            return totalArea;
        }

        public override void Move(double deltaX, double deltaY)
        {
            foreach (Shape shape in Shapes)
                shape.Move(deltaX, deltaY);
        }
    }
}
