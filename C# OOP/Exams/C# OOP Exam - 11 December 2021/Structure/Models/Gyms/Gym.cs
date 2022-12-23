using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                else
                    name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set { capacity = value; }
        }

        public double EquipmentWeight => equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            athletes.ForEach(a => a.Exercise());
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            string athletesInGym = "";
            if (athletes.Any())
                athletesInGym += string.Join(", ", athletes);
            else
                athletesInGym = "No athletes";

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            sb.Append("Athletes:");
            sb.AppendLine(athletesInGym);
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
