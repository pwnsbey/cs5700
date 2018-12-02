using System;
using System.Collections.Generic;

namespace Shapes
{
    public abstract class ShapeFactory
    {
        public abstract Shape Create2dShape();
        public abstract Shape Create3dShape();
    }
}
