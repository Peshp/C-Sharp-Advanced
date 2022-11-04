using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; set; }
        public int Count { get { return Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (this.Drones.Count >= this.Capacity)
                return "Airfield is full.";
            if (drone.Name == null && drone.Brand == null &&
                drone.Name == string.Empty && drone.Brand == string.Empty &&
                drone.Range > 4 && drone.Range < 16)
                return $"Invalid drone.";
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";           
        }
        public bool RemoveDrone(string name)
            => Drones.Remove(Drones.Find(d => d.Name == name));
        public int RemoveDroneByBrand(string brand)
            => Drones.RemoveAll(d => d.Brand == brand);
        public Drone FlyDrone(string name)
        {
            Drone droneFind = Drones.Find(d => d.Name == name);
            if (droneFind != null)
                droneFind.Available = false;
            return droneFind;
        }
        public List<Drone> FlyDronesByRange(int range)
            => Drones.FindAll(d => d.Range == range);
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, Drones));
            return sb.ToString().TrimEnd();
        }
    }
}
