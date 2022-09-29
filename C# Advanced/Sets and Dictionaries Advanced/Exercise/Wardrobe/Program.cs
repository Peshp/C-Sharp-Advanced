using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string color = line.Split(" -> ").First();
                string[] shop = line.Split(" -> ").Last().Split(",").ToArray();

                if (!clothes.ContainsKey(color))              
                    clothes.Add(color, new Dictionary<string, int>());
                
                for (int j = 0; j < shop.Length; j++)
                {
                    if (!clothes[color].ContainsKey(shop[j]))
                        clothes[color].Add(shop[j], 0);
                    clothes[color][shop[j]]++;
                }
            }
            string input = Console.ReadLine();
            string search = input.Split()[0];
            string look = input.Split()[1];

            foreach (var item in clothes)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {                   
                    if(search == item.Key && look == cloth.Key)
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    else
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}
