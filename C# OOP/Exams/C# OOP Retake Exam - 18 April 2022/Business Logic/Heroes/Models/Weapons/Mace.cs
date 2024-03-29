﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int MACE_DAMAGE = 25;
        public Mace(string name, int durability) : base(name, durability)
        {
        }
        public override int DoDamage()
        {
            if (Durability > 0)
                Durability--;
            if (Durability == 0)
                return 0;
            else
                return MACE_DAMAGE;
        }
    }
}
