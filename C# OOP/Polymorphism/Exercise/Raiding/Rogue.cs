using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name, int power) : base(name, power)
        { }

        public override string CastAbility()
            => $"Rogue - {Name} hit for {Power} damage";
    }
}
