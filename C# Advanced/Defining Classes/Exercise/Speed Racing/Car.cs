using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    public class Car
    {
        public string Model { get; set; }
        private double FuelAmount { get; set; }
        private double FuelCons { get; set; }
        private double Travelled { get; set; }

        public Car(string model, double fuel, double cons)
        {
            Model = model;
            FuelAmount = fuel;
            FuelCons = cons;
            Travelled = 0;
        }
        public void Drive(double km)
        {
            double allkm = km * FuelCons;
            if(FuelAmount - allkm < 0)
                Console.WriteLine("Insufficient fuel for the drive");
            else
            {
                FuelAmount -= allkm;
                Travelled += km;
            }
        }
        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {Travelled}";
        }
    }
}
