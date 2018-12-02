using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Ellipsoid : Ellipse
    {
        public double DepthRadius { get; set; }

        public Ellipsoid(double x, double y, double z, double vertRadius, double horizRadius, double depthRadius)
        {
            Validator.ValidatePositiveDouble(vertRadius, "Invalid radius");
            Validator.ValidatePositiveDouble(horizRadius, "Invalid radius");
            Validator.ValidatePositiveDouble(depthRadius, "Invalid radius");

            Center = new Point(x, y, z);
            VertRadius = vertRadius;
            HorizRadius = horizRadius;
            DepthRadius = depthRadius;
        }

        public Ellipsoid(Point center, double vertRadius, double horizRadius, double depthRadius)
        {

            Validator.ValidatePositiveDouble(vertRadius, "Invalid radius");
            Validator.ValidatePositiveDouble(horizRadius, "Invalid radius");
            Validator.ValidatePositiveDouble(depthRadius, "Invalid radius");
            if (center == null)
                throw new ShapeException("Invalid center point");

            Center = center;
            VertRadius = vertRadius;
            HorizRadius = horizRadius;
            DepthRadius = depthRadius;
        }

        public new void Scale(double scaleFactor)
        {
            Validator.ValidatePositiveDouble(scaleFactor, "Invalid scale factor");
            VertRadius *= scaleFactor;
            HorizRadius *= scaleFactor;
            DepthRadius *= scaleFactor;
        }

        public new double ComputeArea()
        {
            return (4 * Math.PI) * Math.Pow(((Math.Pow(HorizRadius * DepthRadius, 1.6) + 
                Math.Pow(HorizRadius * VertRadius, 1.6) + Math.Pow(DepthRadius * VertRadius, 1.6)) / 3), (1 / 1.6));
        }
    }
}
