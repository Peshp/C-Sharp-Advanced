using System;
using System.Collections.Generic;
using System.Text;

namespace Tire
{
    public class Tire
    {
        private int year;
        private double pressure;

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double Preassure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

        public Tire(int year, double preassure)
        {
            this.Year = year;
            this.Preassure = preassure;
        }
    }
}
