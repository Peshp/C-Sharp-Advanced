using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;
        public Weapon(int destructionLevel, double price)
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }
        public double Price
        {
            get => price;
            private set { price = value; }
        }

        public int DestructionLevel
        {
            get => destructionLevel;
            set
            {
                if (value < 1)
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                else if (value > 10)
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                else
                    destructionLevel = value;
            }
        }
    }
}
