using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        protected string name;
        public Animal(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
    }
}
