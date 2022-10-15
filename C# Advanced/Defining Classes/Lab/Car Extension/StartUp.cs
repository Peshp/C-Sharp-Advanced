using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {       
        class Car
        {
            private string make;
            private string model;
            private int year;
            private double fuelQuantity;
            private double fuelConsumption;

            public string Make
            {
                get { return this.make; }
                set { this.make = value; }
            }
            public string Model
            {
                get { return this.model; }
                set { this.model = value; }
            }
            public int Year
            {
                get { return this.year; }
                set { this.year = value; }
            }
            public double FuelQuantity
            {
                get { return this.fuelQuantity; }
                set { this.fuelQuantity = value; }
            }
            public double FuelConsumption
            {
                get { return this.fuelConsumption; }
                set { this.fuelConsumption = value; }
            }
            public Car() 
            {
                Make = "VW";
                Model = "Golf";
                Year = 1025;
                FuelConsumption = 200;
                FuelConsumption = 10;
            }
            public Car(string make, string model, int year): this()
            {
                this.Make = make;
                this.Model = model;
                this.Year = year;
            }
            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption): this(make, model, year)
            {
                this.FuelQuantity = fuelQuantity;
                this.FuelConsumption = fuelConsumption;
            }
            public void Drive(double distance)
            {
                if ((this.FuelQuantity - distance) * this.FuelConsumption > 0)
                    this.FuelQuantity -= distance * this.FuelConsumption;
                else
                    Console.WriteLine("Not enough fuel to perform this trip!");
            }
            public string WhoAmI()
            {
                return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year} \nFuel: {this.FuelQuantity:f2}";
            }
        }
        static void Main()
        {
            Car car = new Car();
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }    
}
