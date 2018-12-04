using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class TriangleFactory : ShapeFactory
    {
        public override Shape Create2dShape()
        {
            return new Triangle(0, 0, 2, 2, 4, 4);
        }

        public override Shape Create3dShape()
        {
            return new Tetrahedron(0, 0, 0, 2, 2, 2, 4, 4, 4);
        }
    }
}
