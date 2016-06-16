namespace Abstraction
{
    using Models.WithoutRadius;
    using Models.WithRaduis;

    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine("I am a circle. " +
            "My perimeter is {0:f2}. My surface is {1:f2}.",
            circle.CalcPerimeter(),
            circle.CalcSurface());

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. " +
            "My perimeter is {0:f2}. My surface is {1:f2}.",
            rect.CalcPerimeter(),
            rect.CalcSurface());

            ////breaking the methods
            Rectangle strangeRectangle = new Rectangle(-5, -5);
            Console.WriteLine(strangeRectangle.CalcPerimeter());
            Console.WriteLine(strangeRectangle.CalcSurface());

            Circle strangeCircle = new Circle(-5);
            Console.WriteLine(strangeCircle.CalcPerimeter());
            Console.WriteLine(strangeCircle.CalcSurface());
        }
    }
}
