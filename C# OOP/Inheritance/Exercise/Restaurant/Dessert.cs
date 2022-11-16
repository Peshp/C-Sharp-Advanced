using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double calories) : 
            base(name, price, grams)
        {
            Calories = calories;
        }
        public double Calories { get; set; }
    }
    public class Cake : Dessert
    {
        public Cake(string name, decimal price, double grams, double calories) :
            base(name, price, grams, calories)
        {
            grams = 250;
            calories = 1000;
            price = 22;
        }
    }
}
