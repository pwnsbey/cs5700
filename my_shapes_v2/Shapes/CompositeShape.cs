using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shapes
{
    public class CompositeShape: Shape
    {
        private List<Shape> Shapes;
        public new bool IsComposited = true;
        public Point Center;

        public CompositeShape(Point center)
        {
            Center = center;
        }

        public CompositeShape(double x, double y)
        {
            Center = new Point(x, y);
        }

        public List<Shape> GetShapes()
        {
            return Shapes;
        }

        public void AddShape(Shape shape)
        {
            if (!shape.IsComposited)
            {
                Shapes.Add(shape);
                shape.IsComposited = true;
            }
        }

        public void RemoveShape(int shapeIndex)
        {
            Shapes[shapeIndex].IsComposited = false;
            Shapes.RemoveAt(shapeIndex);
        }

        public void ClearShapes()
        {
            foreach (Shape shape in Shapes)
                shape.IsComposited = false;
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

        public override string ToScript()
        {
            string returnScript = "#|shape:compositeshape,x:" + Center.X.ToString() + ",y:" + Center.Y.ToString() + "|";

            foreach (Shape shape in Shapes)
            {
                returnScript += shape.ToScript() + "|";
            }

            return returnScript;
        }

        public override void Draw(Graphics graphics)
        {
            foreach (Shape shape in Shapes)
                shape.Draw(graphics);
        }
    }
}
