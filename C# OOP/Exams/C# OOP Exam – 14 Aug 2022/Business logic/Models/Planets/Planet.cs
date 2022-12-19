using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                else
                    name = value;
            }
        }

        public double Budget
        {
            get => budget;
            set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                else
                    budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;       
        private double CalculateMilitaryPower()
        {
            double total = Army.Select(x => x.EnduranceLevel).Sum() +
                weapons.Models.Select(x => x.DestructionLevel).Sum();
            if (Army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                total *= 1.30;
            if (Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                total *= 1.45;
            return Math.Round(total, 3);
        }
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine(units.Models.Any() ? $"--Forces: {string.Join(", ", units.Models.Select(u => u.GetType().Name))}" : "--Forces: No units");
            sb.AppendLine(weapons.Models.Any() ? $"--Combat equipment: {string.Join(", ", weapons.Models.Select(w => w.GetType().Name))}" : "--Combat equipment: No weapons");
            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (budget < amount)
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
                unit.IncreaseEndurance();
        }       
    }
}
