using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            Circle circle = new Circle(radius);

            int w = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(w, h);

            circle.Draw();
            rectangle.Draw();
        }
    }
}
