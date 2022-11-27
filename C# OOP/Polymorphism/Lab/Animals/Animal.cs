using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }
        public virtual string Name { get; set; }
        public virtual string FavouriteFood { get; set; }
        public virtual string ExplainSelf()
         => $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
    }
}
