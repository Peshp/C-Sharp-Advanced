using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;
        public MilitaryUnit(double cost)
        {
            Cost = cost;
            enduranceLevel = 1;
        }
        public double Cost
        {
            get => cost;
            private set { cost = value; }
        }

        public int EnduranceLevel
        {
            get => enduranceLevel;
            private set
            {
                if (value > 20)
                {
                    value = 20;
                    enduranceLevel = 20;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                else
                    enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            EnduranceLevel += 1;
        }
    }
}
