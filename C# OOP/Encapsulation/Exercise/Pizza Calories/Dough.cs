using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string baking;
        private double grams;
        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (value == "White" || value == "Wholegrain")
                    this.flourType = value;
                else
                    throw new ArgumentException("Invalid type of dough.");
            }
        }
        public string Baking
        {
            get { return this.baking; }
            private set
            {
                if (value == "Crispy" || value == "Chewy" || value == "Homemade")
                    this.baking = value;
                else
                    throw new Exception("Invalid type of dough.");
            }
        }
        public double Grams
        {
            get { return this.grams; }
            private set
            {
                if (value > 1 && value < 200)
                    this.grams = value;
                else
                    throw new Exception("Dough weight should be in the range [1..200].");
            }
        }
        public Dough(string flour, string bake, double grams)
        {
            this.FlourType = flour;
            this.Baking = bake;
            this.Grams = grams;
        }
    }
}
