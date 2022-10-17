using System;
using System.Text;
using Tire;
using Engine;

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
            private Engines engine;
            private Tires[] tire;

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
            public Engines Engine
            {
                get { return this.engine; }
                set { this.engine = value; }
            }          
            public Tires[] Tires
            {
                get { return this.Tires; }
                set { this.Tires = value; }
            }

            public Car()
            {
                Make = "VW";
                Model = "Golf";
                Year = 2025;
                FuelQuantity = 200;
                FuelConsumption = 10;
            }
            public Car(string make, string model, int year) : this()
            {
                this.Make = make;
                this.Model = model;
                this.Year = year;
            }
            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : 
                this(make, model, year)
            {
                this.FuelQuantity = fuelQuantity;
                this.FuelConsumption = fuelConsumption;
            }
            public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, 
                Engines engine, Tires[] tire) : this(make, model, year, fuelQuantity, fuelConsumption)
            {
                this.Engine = engine;
                this.Tires = tire;
            }
            public void Drive(double distance)
            {
                double fuelToSpend = distance * this.fuelConsumption;
                if (this.FuelConsumption - fuelToSpend >= 0)
                    this.FuelQuantity -= fuelToSpend;
                else
                    Console.WriteLine("Not enough fuel to perform this trip!");
            }
            public string WhoAmI()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Make: {this.Make}");
                sb.AppendLine($"Model: {this.Model}");
                sb.AppendLine($"Year: {this.Year}");
                sb.AppendLine($"Fuel: {this.FuelQuantity:f2}");
                return sb.ToString();
            }                 
        }
        public static void Main()
        {
            var tires = new Tires[4]
            {
                new Tires(1, 2.5),
                new Tires(1, 2.1),
                new Tires(2, 0.5),
                new Tires(2, 2.3),
            };

            var engine = new Engines(560, 6300);

            var car = new Car("Opel", "Urus", 2010, 250, 9, engine, tires);
        }              
    }      
}
