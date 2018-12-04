using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Tetrahedron : Triangle
    {
        public Tetrahedron(double x1, double y1, double z1, double x2, double y2, double z2, 
                           double x3, double y3, double z3)
        {
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);

            ValidateTriangle(point1, point2, point3);

            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public Tetrahedron(Point point1, Point point2, Point point3)
        {
            if (point1 == null || point2 == null || point3 == null)
                throw new ShapeException("Invalid corner point(s)");

            ValidateTriangle(point1, point2, point3);

            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }
    }
}
