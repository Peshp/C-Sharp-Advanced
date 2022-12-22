using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<IVessel> vessels;
        public Captain(string fullName)
        {
            FullName = fullName;
            combatExperience = 0;
            vessels = new List<IVessel>();
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get => combatExperience;
            private set { combatExperience = value; }
        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            if(vessels.Any())
            {
                foreach (var ves in vessels)
                {
                    sb.AppendLine();
                    ves.ToString();
                }
            }
            
            return sb.ToString();
        }
    }
}
