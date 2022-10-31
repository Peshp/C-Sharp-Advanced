using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
        public int Count { get {return this.data.Count; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public void Add(Ski ski)
        {
            if (this.data.Count < Capacity)
                this.data.Add(ski);
        }
        public bool Remove(string manufacturer, string model)
            => this.data.Remove(this.data.Find(s => s.ManuFacturer == manufacturer && s.Model == model));
        public Ski GetNewestSki()
            => this.data.OrderBy(n => n.Year).First();
        public Ski GetSki(string manufacturer, string model)
            => this.data.Find(s => s.ManuFacturer == manufacturer && s.Model == model);
        public string GetStatistics()
        {
            return $"The skis stored in {this.Name}:" +
                Environment.NewLine +
                string.Join(Environment.NewLine, data);
        }
    }
}
