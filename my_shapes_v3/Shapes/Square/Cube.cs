using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Cube: Square
    {
        public Cube(double cornerX, double cornerY, double cornerZ, double sideLength)
        {
            Validator.ValidatePositiveDouble(sideLength, "Invalid side legnth");
            Point1 = new Point(cornerX, cornerY, cornerZ);
            Point2 = new Point(cornerX + sideLength, cornerY + sideLength, cornerZ + sideLength);
        }

        public Cube(Point point, double sideLength)
        {
            Validator.ValidatePositiveDouble(sideLength, "Invalid side length");
            if (point == null)
                throw new ShapeException("Invalid corner point");

            Point1 = point;
            Point point2 = new Point(point.X + sideLength, point.Y + sideLength, point.Z + sideLength);
        }

        public double GetDepth()
        {
            return Math.Abs(Point1.Z - Point2.Z);
        }

        public new double ComputeArea()
        {
            return 2 * ((GetDepth() * GetLength()) + (GetHeight() * GetLength()) + (GetHeight() * GetDepth()));
        }
    }
}
