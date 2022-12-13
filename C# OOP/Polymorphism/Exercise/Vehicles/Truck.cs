using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuan, double fuelCons) : base(fuelQuan, fuelCons + 1.6)
        {
        }
        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}
