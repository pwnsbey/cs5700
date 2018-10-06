﻿using System;
using System.Collections.Generic;

namespace Shapes
{
    public class CompositeShape: Shape
    {
        private List<Shape> Shapes;
        public bool IsComposited = true;

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
    }
}
