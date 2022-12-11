using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public double Radius
        {
            get => this.radius;
            set
            {
                if (value >= 0)
                    this.radius = value;
                else
                    throw new Exception("Radius cannot be negative number");
            }
        }
        public Circle(double r)
        {
            this.Radius = r;
        }
        public override double CalculateArea()
            => Math.PI * Math.Pow(this.Radius, 2);
        public override double CalculatePerimeter()
            => Math.PI * (this.Radius * 2);

        public void Draw()
        {
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            for (double i = this.Radius; i >= -this.Radius; --i)
            {
                for (double j = -this.Radius; j < rOut; j += 0.5)
                {
                    double value = i * i + j * j;
                    if (rIn * rIn <= value && rOut * rOut >= value)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
