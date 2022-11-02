using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }
        public int Count { get { return this.Fish.Count; } }
        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
                return "Invalid fish.";
            if (Fish.Count + 1 > Capacity)
                return "Fishing net is full.";
            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            var fish = this.Fish.FirstOrDefault(f => f.Weight == weight);
            if (fish != null)
                this.Fish.Remove(fish);
            return false;
        }
        public Fish GetFish(string fishType)
            => this.Fish.FirstOrDefault(f => f.FishType == fishType);
        public Fish GetBiggestFish()
            => this.Fish.FirstOrDefault(f => f.Length == this.Fish.Max(f => f.Length));
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Into the {this.Material}:");
            foreach (var item in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
