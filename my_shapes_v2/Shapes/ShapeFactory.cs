using System;
using System.Collections.Generic;

namespace Shapes
{
    public class ShapeFactory
    {
        private List<PictureImage> AvailableImages;

        public ShapeFactory()
        {
            AvailableImages = new List<PictureImage>();
        }

        /**
         * Utility function to parse out script strings.
         * 
         * @param script the script to parse
         */
        private Dictionary<string, string> ParseScript(string script)
        {
            Dictionary<string, string> scriptDict = new Dictionary<string, string>();
            string[] varStrings = script.Split(',');
            foreach (string varString in varStrings)
            {
                string[] varVal = varString.Split(':');
                scriptDict.Add(varVal[0], varVal[1]);
            }
            return scriptDict;
        }

        /**
         * Utility function to parse out script strings for composite shapes.
         * 
         * @param script the script to parse
         */
        private List<Dictionary<string, string>> ParseCompositeScript(string script)
        {
            script = script.Remove(0, 2);

            List<Dictionary<string, string>> shapesDict = new List<Dictionary<string, string>>();
            string[] shapeStrings = script.Split('|');
            foreach (string shapeString in shapeStrings)
                shapesDict.Add(ParseScript(shapeString));
            return shapesDict;
        }

        public Shape MakeShapeFromScript(string script)
        {
            try
            {
                // special case for composite shapes
                if (script[0] == '#')
                {
                    List<Dictionary<string, string>> compValDict = ParseCompositeScript(script);
                    CompositeShape compositeShape = MakeCompositeShape(int.Parse(compValDict[0]["x"]),
                                                                       int.Parse(compValDict[1]["y"]));
                    for (int i = 1; i < compValDict.Count; i++)
                    {
                        Dictionary<string, string> shapeDict = compValDict[i];
                        compositeShape.AddShape(ShapeFromDict(shapeDict));
                    }
                    return compositeShape;
                }
                else
                    return ShapeFromDict(ParseScript(script));
            }
            catch
            {
                throw new ShapeException("Invalid shape script");
            }
        }

        private Shape ShapeFromDict(Dictionary<string, string> valDict)
        {
            switch (valDict["shape"])
            {
                case "point":
                    return MakePoint(int.Parse(valDict["x"]), int.Parse(valDict["y"]));
                case "line":
                    return MakeLine(int.Parse(valDict["x1"]), int.Parse(valDict["y1"]), 
                                    int.Parse(valDict["x2"]), int.Parse(valDict["y2"]));
                case "ellipse":
                    return MakeEllipse(int.Parse(valDict["x"]), int.Parse(valDict["y"]), 
                                       int.Parse(valDict["horizradius"]), int.Parse(valDict["vertradius"]));
                case "circle":
                    return MakeCircle(int.Parse(valDict["x"]), int.Parse(valDict["y"]), int.Parse(valDict["radius"]));
                case "rectangle":
                    return MakeRectangle(int.Parse(valDict["x1"]), int.Parse(valDict["y1"]),
                                         int.Parse(valDict["x2"]), int.Parse(valDict["y2"]));
                case "square":
                    return MakeSquare(int.Parse(valDict["cornerx"]), int.Parse(valDict["cornery"]), 
                                      int.Parse(valDict["sidelength"]));
                case "triangle":
                    return MakeTriangle(int.Parse(valDict["x1"]), int.Parse(valDict["y1"]),
                                       int.Parse(valDict["x2"]), int.Parse(valDict["y2"]),
                                       int.Parse(valDict["x3"]), int.Parse(valDict["y3"]));
                case "embeddedpicture":
                    PictureImage targetImage = AvailableImages.Find(image => image.id == int.Parse(valDict["imageid"]));
                    return new EmbeddedPicture(targetImage, int.Parse(valDict["x1"]), int.Parse(valDict["y1"]),
                                                            int.Parse(valDict["x2"]), int.Parse(valDict["y2"]));
                default:
                    throw new ShapeException("Invalid shape name");
            };
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

        public Triangle MakeTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
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
            newImg.id = (AvailableImages.Count);
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
            newImg.id = (AvailableImages.Count);
            AvailableImages.Add(newImg);
            return new EmbeddedPicture(newImg, MakePoint(x1, y1), MakePoint(x2, y2));
        }
    }
}
