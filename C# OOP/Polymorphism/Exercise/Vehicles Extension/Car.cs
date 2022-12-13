using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuan, double fuelCons, double tank) : base(fuelQuan, fuelCons + 0.9, tank)
        { }
    }
}
