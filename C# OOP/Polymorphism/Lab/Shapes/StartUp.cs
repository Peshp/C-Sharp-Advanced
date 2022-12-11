using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double r = double.Parse(Console.ReadLine());

            Shape rectangle = new Rectangle(h, w);
            Shape circle = new Circle(r);

            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine($"{circle.CalculatePerimeter():f2}");
            Console.WriteLine($"{circle.CalculateArea():f2}");

            var rect = new Rectangle(h, w);
            rect.Draw();
            var circ = new Circle(r);
            circ.Draw();
        }
    }
}
