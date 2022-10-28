using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {       
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }
        public List<Renovator> Renovators;
        public int Count { get { return Renovators.Count; } }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
                return $"Invalid renovator's information.";
            if (this.Count >= NeededRenovators)
                return "Renovators are no more needed.";
            if (renovator.Rate > 350)
                return "Invalid renovator's rate.";
            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
            => Renovators.Remove(Renovators.Find(x => x.Name == name));
        public int RemoveRenovatorBySpecialty(string type)
            => Renovators.RemoveAll(r => r.Type == type);
        public Renovator HireRenovator(string name)
        {
            Renovator renovator = Renovators.Find(r => r.Name == name);
            if (renovator != null)
                return renovator;
            else
                return null;
        }
        public List<Renovator> PayRenovators(int days)
            => Renovators.FindAll(r => r.Days >= days).ToList();
        public string Report()
            => $"Renovators available for Project {this.Project}" +
            Environment.NewLine +
            string.Join(Environment.NewLine, Renovators.FindAll(r => !r.Hired));
    }
}
