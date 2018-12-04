using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class SquareFactory : ShapeFactory
    {
        public override Shape Create2dShape()
        {
            return new Square(0, 0, 3);
        }

        public override Shape Create3dShape()
        {
            return new Cube(0, 0, 0, 3);
        }
    }
}
