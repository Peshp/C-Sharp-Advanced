using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        { }    
    }
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.DefaultFuelConsumption = 8;
        }
    }
    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsepower, double fuel) : base(horsepower, fuel)
        { }
    }
}
