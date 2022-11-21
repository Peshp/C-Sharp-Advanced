using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.Height - 1; i++)
            {
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', '*');
        }

        private void DrawLine(int width, char v1, char v2)
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
