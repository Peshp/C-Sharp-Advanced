using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape : IDrawShape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();           
    }
}
