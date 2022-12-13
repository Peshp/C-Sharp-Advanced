using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        public virtual double TankCapacity { get; protected set; }      
        public virtual double FuelQuantity { get; protected set; }     
        public virtual double FuelConsumption { get; protected set; }
        public Vehicle(double fuelQuan, double fuelCons, double tank)
        {
            this.TankCapacity = tank;
            if (FuelQuantity <= TankCapacity)
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
        {
            double newFuel = 0;
            if(fuel <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else
            {
                newFuel = this.FuelQuantity + fuel;
                if (newFuel > this.TankCapacity)
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                else
                    this.FuelQuantity += fuel;
            }              
        }
        public virtual void DriveEmpty(double distance)
        {
            double newFuel = this.FuelQuantity - (this.FuelConsumption - 1.4) * distance;
            if (newFuel >= 0)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQuantity = newFuel;
            }
            else
                Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
