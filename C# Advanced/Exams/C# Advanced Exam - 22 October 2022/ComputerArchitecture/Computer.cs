using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count { get { return this.Multiprocessor.Count; } }
        public void Add(CPU cpu)
        {
            if (this.Count < this.Capacity)
                this.Multiprocessor.Add(cpu);
        }
        public bool Remove(string brand)
            => this.Multiprocessor.Remove(this.Multiprocessor.Find(p => p.Brand == brand));
        public CPU MostPowerful()
            => this.Multiprocessor.OrderByDescending(p => p.Frequency).First();
        public CPU GetCPU(string brand)
            => this.Multiprocessor.FirstOrDefault(p => p.Brand == brand);
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");           
            sb.AppendLine(string.Join(Environment.NewLine, this.Multiprocessor));
            return sb.ToString().TrimEnd();
        }
    }
}
