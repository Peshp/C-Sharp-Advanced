using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            var steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var weapons = new Dictionary<string, int>();
            int count = 0;

            while (steel.Any() && carbon.Any())
            {
                string currWeapon = Calculate(steel, carbon);
                if (currWeapon != null)
                {
                    count++;
                    if (weapons.ContainsKey(currWeapon))
                        weapons[currWeapon]++;
                    else
                        weapons.Add(currWeapon, 1);
                }             
            }
            if(weapons.Count > 0)
                Console.WriteLine($"You have forged {count} swords.");
            else
                Console.WriteLine("You did not have enough resources to forge a sword.");
            if(steel.Count > 0)
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            else
                Console.WriteLine("Steel left: none");
            if(carbon.Count > 0)
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            else
                Console.WriteLine("Carbon left: none");
            foreach(var weapon in weapons.OrderBy(x => x.Key))
                Console.WriteLine($"{weapon.Key}: {weapon.Value}");
        }

        private static string Calculate(Queue<int> steel, Stack<int> carbon)
        {
            int currSteel = steel.Dequeue();
            int currCarbon = carbon.Pop();

            if (currSteel + currCarbon == 70)
                return "Gladius";
            else if (currSteel + currCarbon == 80)
                return "Shamshir";
            else if (currSteel + currCarbon == 90)
                return "Katana";
            else if (currSteel + currCarbon == 110)
                return "Sabre";
            else if (currSteel + currCarbon == 150)
                return "Broadsword";
            else
            {               
                carbon.Push(currCarbon + 5);
                return null;
            }               
        }
    }
}
