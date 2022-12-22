using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (captain == null)
                    throw new NullReferenceException("Captain cannot be null.");
            }
        }
        public double ArmorThickness
        {
            get => armorThickness;
            set { armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get => speed;
            protected set { speed = value; }
        }

        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
                throw new NullReferenceException("Target cannot be null.");          
            targets.Add(target.Name);
            Math.Max(0, target.ArmorThickness -= this.MainWeaponCaliber);
        }

        public abstract void RepairVessel();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Armor thickness: {ArmorThickness}");
            sb.AppendLine($"Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"Speed: {Speed} knots");
            sb.AppendLine(targets.Any() ? string.Join(", ", targets) : "None");

            return sb.ToString().TrimEnd();
        }
    }
}
