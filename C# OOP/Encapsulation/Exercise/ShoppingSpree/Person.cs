using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bag;
       
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new Exception("Name cannot be empty");
                this.name = value;
            }
        }
        public int Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                    throw new Exception("Money cannot be negative");
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag => this.bag;
        public Person(string name, int money)
        {
            this.Money = money;
            this.Name = name;
            bag = new List<Product>();
        }
        public void IsMoneyEnough(Product product)
        {
            if(money - product.Cost >= 0)
            {
                Console.WriteLine($"{Name} bought {product}");
                money -= product.Cost;
                this.bag.Add(product);
            }
            else
                Console.WriteLine($"{Name} can't afford {product}");
        }     
    }
}
