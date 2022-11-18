using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        
        public double Length { get { return this.length; } private set
            {
                if (value <= 0)
                    throw new ArgumentException("Length cannot be zero or negative.");
                this.length = value;
            } }
        public double Width { get { return this.width; } private set
            {
                if (value <= 0)
                    throw new ArgumentException("Width cannot be zero or negative.");
                this.width = value;
            } }
        public double Height { get { return this.height; } private set
            {
                if (value <= 0)
                    throw new ArgumentException("Height cannot be zero or negative.");
                this.height = value;
            } }
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;  
            this.Height = height;  
        }
        public double SurfaceArea()
            => 2 * (length * width) + 2 * (length * height) + 2 * (width * height);
        public double LateralSurfaceArea()
            => 2 * (length * height) + 2 * (width * height);
        public double Volume()
            => length * width * height;
        public override string ToString()
        {
            return $"Surface Area - {SurfaceArea():f2}\n" +
                $"Lateral Surface Area - {LateralSurfaceArea():f2}\n" +
                $"Volume - {Volume():f2}";
        }
    }
}
