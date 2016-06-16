namespace CohesionAndCoupling
{
    using System;
    using System.Runtime.CompilerServices;
    using DataValidation;

    public static class GeometryUtils
    {
        private static double width;
        private static double height;
        private static double depth;

        public static double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (DataValidator.NumericValidator(value))
                {
                    width = value;
                }
            }
        }

        public static double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (DataValidator.NumericValidator(value))
                {
                    height = value;
                }
            }
        }

        public static double Depth
        {
            get
            {
                return depth;
            }

            set
            {
                if (DataValidator.NumericValidator(value))
                {
                    depth = value;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return CalcDistance2D(x1, x2, y1, y2) + Math.Sqrt(Math.Pow((z2 - z1), 2));
        }

        public static double CalcVolume()
        {
            return Width * Height * Depth;
        }

        public static double CalcDiagonalXYZ()
        {
            return CalcDistance3D(0, 0, 0, Width, Height, Depth);
        }

        public static double CalcDiagonalXY()
        {
            return CalcDistance2D(0, 0, Width, Height);
        }

        public static double CalcDiagonalXZ()
        {
            return CalcDistance2D(0, 0, Width, Depth);
        }

        public static double CalcDiagonalYZ()
        {
            return CalcDistance2D(0, 0, Height, Depth);
        }
    }
}
