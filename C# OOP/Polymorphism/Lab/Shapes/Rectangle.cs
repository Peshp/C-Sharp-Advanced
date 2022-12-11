using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public double Height
        {
            get => this.height;
            protected set
            {
                if (value >= 0)
                    this.height = value;
                else
                    throw new Exception("Height cannot be a negative number");
            }
        }
        public double Width
        {
            get => this.width;
            protected set
            {
                if (value >= 0)
                    this.width = value;
                else
                    throw new Exception("Width cannot be a negative number");
            }
        }
        public Rectangle(double h, double w)
        {
            this.Height = h;
            this.Width = w;
        }

        public override double CalculateArea()
            => this.Width * this.Height;
        public override double CalculatePerimeter()
            => 2 * this.Height + 2 * this.Width;
        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.Height - 1; i++)
            {
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', '*');
        }

        private void DrawLine(double width, char v1, char v2)
        {
            Console.Write(v1);
            for (int i = 1; i < width - 1; i++)
            {
                Console.Write(v2);
            }
            Console.WriteLine(v1);
        }
    }
}
