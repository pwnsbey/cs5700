using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class CircleFactory : ShapeFactory
    {
        public override Shape Create2dShape()
        {
            return new Circle(0, 0, 1);
        }

        public override Shape Create3dShape()
        {
            return new Sphere(0, 0, 0, 1);
        }
    }
}
