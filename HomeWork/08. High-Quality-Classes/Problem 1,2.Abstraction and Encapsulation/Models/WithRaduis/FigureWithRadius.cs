using Abstraction.DataValidation;
using Abstraction.Interfaces;

namespace Abstraction.Models.WithRaduis
{
    public abstract class FigureWithRadius : IFigure
    {
        private double radius;

        public FigureWithRadius()
        {
        }

        public FigureWithRadius(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (NumericValidator.ValidateNumber(value))
                {
                    radius = value;
                }
            }
        }

        public abstract double CalcSurface();

        public abstract double CalcPerimeter();
    }
}
