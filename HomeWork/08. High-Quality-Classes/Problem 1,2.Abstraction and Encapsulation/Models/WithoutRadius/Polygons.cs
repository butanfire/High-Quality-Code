namespace Abstraction.Models.WithoutRadius
{
    using DataValidation;
    using Interfaces;

    public abstract class Polygons : IFigure
    {
        private double width;
        private double height;

        public Polygons()
        {
        }

        public Polygons(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (NumericValidator.ValidateNumber(value))
                {
                    width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (NumericValidator.ValidateNumber(value))
                {
                    height = value;
                }
                
            }
        }

        public abstract double CalcSurface();

        public abstract double CalcPerimeter();
    }
}
