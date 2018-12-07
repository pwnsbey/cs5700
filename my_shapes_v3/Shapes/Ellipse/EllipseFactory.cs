using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class EllipseFactory : ShapeFactory
    {
        public override Shape Create2dShape()
        {
            return new Ellipse(0, 0, 1, 2);
        }

        public override Shape Create3dShape()
        {
            return new Ellipsoid(0, 0, 0, 1, 2, 1);
        }
    }
}
