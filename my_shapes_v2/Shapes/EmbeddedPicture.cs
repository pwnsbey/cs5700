using System;

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

        public override void Move(double deltaX, double deltaY)
        {
            ImageBounds.Move(deltaX, deltaY);
        }
    }
}
