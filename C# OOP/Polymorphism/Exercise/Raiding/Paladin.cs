using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name, int power) : base(name, power)
        { }

        public override string CastAbility()
            => $"Paladin - {Name} healed for {Power}";
    }
}
