using System;

namespace Abstraction.Models.WithRaduis
{
    public class Circle : FigureWithRadius
    {
        public Circle() : base(0)
        {
        }

        public Circle(double radius) : base(radius)
        {
        }

        public override double CalcPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double CalcSurface()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
