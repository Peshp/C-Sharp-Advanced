using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Batteries { get; private set; }
        public Tesla(string model, string color, int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Batteries = batteries;
        }
        public string Start()
        {
            string text = "Engine start";
            return text;
        }
        public string Stop()
        {
            string text = "Breaaak!";
            return text;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
