using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IPet
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public  Pet(string name, string birth)
        {
            this.Name = name;
            this.Birthdate = birth;
        }   
    }
}
