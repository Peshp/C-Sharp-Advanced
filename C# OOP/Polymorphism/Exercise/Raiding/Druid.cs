using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name, int power) : base(name, power)
        { }

        public override string CastAbility()
            => $"Druid - {Name} healed for {Power}";
    }
}
