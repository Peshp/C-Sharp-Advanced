using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) : base(name, power)
        { }

        public override string CastAbility()
            => $"Warrior - {Name} hit for {Power} damage";
    }
}
