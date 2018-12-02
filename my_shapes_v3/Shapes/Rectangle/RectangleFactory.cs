using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class RectangleFactory : ShapeFactory
    {
        public override Shape Create2dShape()
        {
            return new Rectangle(0, 0, 1, 2);
        }

        public override Shape Create3dShape()
        {
            return new RectangularPrism(0, 0, 0, 1, 1, 2);
        }
    }
}
