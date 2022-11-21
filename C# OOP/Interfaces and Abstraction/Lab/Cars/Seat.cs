using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; private set; }
        public string Color { get; private set; }
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
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
