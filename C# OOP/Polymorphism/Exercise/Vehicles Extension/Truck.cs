using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuan, double fuelCons, double tank) : base(fuelQuan, fuelCons + 1.6, tank)
        {
        }
        public override void Refuel(double fuel)
        {
            double currFuel = fuel;
            double newFuel = 0;
            if (fuel * 0.95 <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else
            {
                newFuel = this.FuelQuantity + fuel * 0.95;
                if (newFuel > this.TankCapacity)
                    Console.WriteLine($"Cannot fit {currFuel} fuel in the tank");
                else
                    this.FuelQuantity += fuel * 0.95;
            }
        }
    }
}
