using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Sphere : Circle
    {
        public Sphere(double x, double y, double z, double radius)
        {
            Ellipse = new Ellipse(x, y, radius, radius);
        }

        public Sphere(Point center, double radius)
        {
            Ellipse = new Ellipse(center, radius, radius);
        }

        public new double ComputeArea()
        {
            return 4 * (Math.PI * Math.Pow(Ellipse.HorizRadius, 2));
        }
    }
}
