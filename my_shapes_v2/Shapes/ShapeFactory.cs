using System;

namespace Shapes
{
    public class ShapeFactory
    {
        public Shape MakeShape(string shapeName)
        {
            shapeName = shapeName.ToLower();
            switch (shapeName)
            {
                case "point":
                    return new Point(0,0);
                case "line":
                    return new Line(0, 0, 1, 1);
                case "ellipse":
                    return new Ellipse(0, 0, 1, 2);
                case "circle":
                    return new Circle(0, 0, 1);
                case "rectangle":
                    return new Rectangle(0, 0, 2, 1);
                case "square":
                    return new Square(0, 0, 1);
                case "triangle":
                    return new Triangle(0, 0, 1, 0, 0, 1);
                case "compositeshape":
                    return null;  // TODO
                case "embeddedpicture":
                    return null;  // TODO
                default:
                    return null;
            }
        }
    }
}
