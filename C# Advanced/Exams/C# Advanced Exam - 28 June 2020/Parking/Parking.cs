using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private readonly List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public int Count { get { return this.data.Count; } }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public void Add(Car car)
        {
            if (this.data.Count < this.Capacity)
                this.data.Add(car);
        }
        public bool Remove(string manufacturer, string model)
        {
            return this.data.Remove(this.data.Find(c => c.Manufacturer == manufacturer && c.Model == model));        
        }
        public Car GetLatestCar()
            => this.data.OrderBy(c => c.Year).FirstOrDefault();
        public Car GetCar(string manufacturer, string model)
            => this.data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
        public string GetStatistics()
        {
            return $"The cars are parked in {this.Type}:" +
                Environment.NewLine +
                string.Join(Environment.NewLine, data);
        }
    }
}
