using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class RectangularPrism : Rectangle
    {
        public RectangularPrism(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Point point1 = new Point(x1, y1, z1);
            Point point2 = new Point(x2, y2, z1);

            ValidateRectangle(point1, point2);

            Point1 = point1;
            Point2 = point2;
        }

        public RectangularPrism(Point point1, Point point2)
        {
            if (point1 == null || point2 == null)
                throw new ShapeException("Invalid corner point(s)");

            ValidateRectangle(point1, point2);

            Point1 = point1;
            Point2 = point2;
        }

        public double GetDepth()
        {
            return Math.Abs(Point1.Z - Point2.Z);
        }

        public new double ComputeArea()
        {
            return 2 * ((GetDepth()*GetLength())+(GetHeight()*GetLength())+(GetHeight()*GetDepth()));
        }
    }
}
