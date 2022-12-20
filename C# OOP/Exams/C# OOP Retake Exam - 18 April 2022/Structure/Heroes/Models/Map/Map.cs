using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        private List<Knight> knight;
        private List<Barbarian> barbarians;
        public Map()
        {
            knight = new List<Knight>();
            barbarians = new List<Barbarian>();
        }
        public string Fight(ICollection<IHero> players)
        {
            foreach (var player in players)
            {
                if (player.GetType().Name == "Knight")
                    knight.Add(new Knight(player.Name, player.Health, player.Armour));
                else
                    barbarians.Add(new Barbarian(player.Name, player.Health, player.Armour));
            }
            while (knight.Any(x => x.IsAlive) && barbarians.Any(x => x.IsAlive))
            {
                foreach (var guy in knight)
                {
                    if (guy.IsAlive)
                        barbarians.ForEach(x => x.TakeDamage(guy.Weapon.DoDamage()));
                }
                foreach (var barb in barbarians)
                {
                    if (barb.IsAlive)
                        knight.ForEach(x => x.TakeDamage(barb.Weapon.DoDamage()));
                }
            }
            if (knight.Any())
                return $"The knights took {knight.FindAll(x => x.IsAlive == false).Count} casualties but won the battle.";
            else
                return $"The barbarians took {barbarians.FindAll(x => x.IsAlive == false).Count} casualties but won the battle.";
        }
    }
}
