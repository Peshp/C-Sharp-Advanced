using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        public virtual double FuelQuantity { get; protected set; }
        public virtual double FuelConsumption { get; protected set; }
        public Vehicle(double fuelQuan, double fuelCons)
        {
            this.FuelQuantity = fuelQuan;
            this.FuelConsumption = fuelCons;
        }
        public virtual void Drive(double distance)
        {
            double newFuel = this.FuelQuantity - this.FuelConsumption * distance;
            if (newFuel >= 0)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQuantity = newFuel;
            }
            else
                Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        public virtual void Refuel(double fuel)
            => this.FuelQuantity += fuel;
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
