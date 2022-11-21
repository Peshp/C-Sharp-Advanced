using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int r)
        {
            this.Radius = r;
        }
        public int Radius { get; set; }
        public void Draw()
        {
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            for (double i = this.Radius; i >= -this.Radius; --i)
            {
                for (double j = -this.Radius; j < rOut; j+=0.5)
                {
                    double value = i * i + j * j;
                    if(rIn * rIn <= value && rOut * rOut >= value)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
