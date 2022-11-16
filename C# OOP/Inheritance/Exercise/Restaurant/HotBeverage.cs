using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
        }             
    }
    public class Coffee : HotBeverage
    {
        public Coffee(string name, decimal price, double milliliters, double caffeine)
            : base(name, price, milliliters)
        {
            CoffeeMilliliters = 50;
            CoffeePrice = 3.5;
        }
        public double CoffeeMilliliters { get; set; }
        public double CoffeePrice { get; set; }
        public double Caffeine { get; set; }
    }
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
        }
    }
}
