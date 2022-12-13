using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuan, double fuelCons, double tank) : base(fuelQuan, fuelCons + 1.4, tank)
        { }       
    }
}
