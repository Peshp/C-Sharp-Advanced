using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuan, double fuelCons) : base(fuelQuan, fuelCons + 0.9)
        { }
    }
}