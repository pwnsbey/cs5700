using System;
using System.Drawing;

namespace Shapes
{
    public class EmbeddedPicture: Shape
    {
        public PictureImage Image;
        public Rectangle ImageBounds;

        public EmbeddedPicture(PictureImage image, Point point1, Point point2)
        {
            Image = image;
            ImageBounds = new Rectangle(point1, point2);
        }

        public EmbeddedPicture(PictureImage image, double x1, double y1, double x2, double y2)
        {
            Image = image;
            ImageBounds = new Rectangle(new Point(x1, y1), new Point(x2, y2));
        }

        public override double ComputeArea()
        {
            return ImageBounds.ComputeArea();
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image.bitmap, (float)ImageBounds.Point1.X, (float)ImageBounds.Point1.Y, 
                                      (float)ImageBounds.Point2.X, (float)ImageBounds.Point2.Y);
        }

        public override void Move(double deltaX, double deltaY)
        {
            ImageBounds.Move(deltaX, deltaY);
        }

        public override string ToScript()
        {
            return "shape:embeddedpicture,imageid:" + Image.id +
                   ",x1:" + ImageBounds.Point1.X.ToString() + ",y1:" + ImageBounds.Point1.Y.ToString() +
                   ",x2:" + ImageBounds.Point2.X.ToString() + ",y2:" + ImageBounds.Point2.Y.ToString();
        }
    }
}
