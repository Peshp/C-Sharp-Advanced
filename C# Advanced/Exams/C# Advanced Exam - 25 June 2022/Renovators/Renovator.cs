using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
            this.Hired = false;
        }
        public string Name;
        public string Type;
        public double Rate;
        public int Days;
        public bool Hired;
        public override string ToString()      
            =>  $"-Renovator: {this.Name}" + Environment.NewLine +
            $"--Specialty: {this.Type}" + Environment.NewLine +
            $"--Rate per day: {this.Rate} BGN";
        
    }
}
