using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.DefaultFuelConsumption = 3;
        }
    }
    public class SportCar : Car
    {
        public SportCar(int horsepower, double fuel) : base(horsepower, fuel)
        {
            this.DefaultFuelConsumption = 10;
        }
    }
    public class FamilyCar : Car
    {
        public FamilyCar(int horsepower, double fuel) : base(horsepower, fuel)
        { }
    }
}
