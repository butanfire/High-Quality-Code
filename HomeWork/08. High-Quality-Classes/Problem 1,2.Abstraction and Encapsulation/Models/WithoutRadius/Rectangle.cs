namespace Abstraction.Models.WithoutRadius
{
    public class Rectangle : Polygons
    {
        public Rectangle() : base(0, 0)
        {
        }

        public Rectangle(double width, double height) : base(width, height)
        {
        }

        public override double CalcPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override double CalcSurface()
        {
            return Width * Height;
        }
    }
}
