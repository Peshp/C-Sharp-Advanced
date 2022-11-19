using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private int cost;
        public Product(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
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
        public int Cost
        {
            get { return this.cost; }
            private set
            {
                if (value < 0)
                    throw new Exception("Money cannot be negative");
                this.cost = value;
            }
        }
        public override string ToString()
               => this.Name;
    }
}
