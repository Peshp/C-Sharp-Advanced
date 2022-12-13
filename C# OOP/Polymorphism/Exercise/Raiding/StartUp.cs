using System;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BaseHero hero = null;
            int fullPower = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch(type)
                {
                    case "Druid": hero = new Druid(name, 80); break;
                    case "Paladin": hero = new Paladin(name, 100); break;
                    case "Rogue": hero = new Rogue(name, 80); break;
                    case "Warrior": hero = new Warrior(name, 100); break;
                    default: Console.WriteLine("Invalid hero!"); hero = null; break;
                }
                Console.WriteLine(hero.CastAbility());
                fullPower += hero.Power;
            }
            if(fullPower >= int.Parse(Console.ReadLine()))
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
    }
}
