using System;
using System.Collections.Generic;

namespace Shapes
{
    public class ShapeFactory
    {
        //public Shape MakeShape(string shapeName)
        //{
        //    shapeName = shapeName.ToLower();
        //    switch (shapeName)
        //    {
        //        case "point":
        //            return new Point(0,0);
        //        case "line":
        //            return new Line(0, 0, 1, 1);
        //        case "ellipse":
        //            return new Ellipse(0, 0, 1, 2);
        //        case "circle":
        //            return new Circle(0, 0, 1);
        //        case "rectangle":
        //            return new Rectangle(0, 0, 2, 1);
        //        case "square":
        //            return new Square(0, 0, 1);
        //        case "triangle":
        //            return new Triangle(0, 0, 1, 0, 0, 1);
        //        case "compositeshape":
        //            return new CompositeShape(0, 0);
        //        case "embeddedpicture":
        //            return null;  // TODO
        //        default:
        //            return null;
        //    }
        //}

        private List<PictureImage> AvailableImages;

        public ShapeFactory()
        {
            AvailableImages = new List<PictureImage>();
        }

        public Point MakePoint(double x, double y)
        {
            return new Point(x, y);
        }

        public Line MakeLine(double x1, double y1, double x2, double y2)
        {
            return new Line(MakePoint(x1, y1), MakePoint(x2, y2));
        }

        public Ellipse MakeEllipse(double x, double y, double vertRadius, double horizRadius)
        {
            return new Ellipse(MakePoint(x, y), vertRadius, horizRadius);
        }

        public Circle MakeCircle(double x, double y, double radius)
        {
            return new Circle(MakePoint(x, y), radius);
        }

        public Rectangle MakeRectangle(double x1, double y1, double x2, double y2)
        {
            return new Rectangle(MakePoint(x1, y1), MakePoint(x2, y2));
        }

        public Square MakeSquare(double x, double y, double sideLength)
        {
            return new Square(MakePoint(x, y), sideLength);
        }

        public Triangle MakeTrangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return new Triangle(MakePoint(x1, y1), MakePoint(x2, y2), MakePoint(x3, y3));
        }

        public CompositeShape MakeCompositeShape(double x, double y)
        {
            return new CompositeShape(x, y);
        }

        public EmbeddedPicture MakeEmbeddedPicture(string filepath, double x1, double y1, 
                                                                    double x2, double y2)
        {
            PictureImage newImg = new PictureImage(filepath);
            foreach (PictureImage img in AvailableImages)
            {
                if (img.bitmap.Equals(newImg.bitmap))
                {
                    return new EmbeddedPicture(img, MakePoint(x1, y1), MakePoint(x2, y2));
                }
            }
            AvailableImages.Add(newImg);
            return new EmbeddedPicture(newImg, MakePoint(x1, y1), MakePoint(x2, y2));
        }

        public EmbeddedPicture MakeEmbeddedPicture(Type type, string resource, double x1, double y1,
                                                                               double x2, double y2)
        {
            PictureImage newImg = new PictureImage(type, resource);
            foreach (PictureImage img in AvailableImages)
            {
                if (img.bitmap.Equals(newImg.bitmap))
                {
                    return new EmbeddedPicture(img, MakePoint(x1, y1), MakePoint(x2, y2));
                }
            }
            AvailableImages.Add(newImg);
            return new EmbeddedPicture(newImg, MakePoint(x1, y1), MakePoint(x2, y2));
        }
    }
}
