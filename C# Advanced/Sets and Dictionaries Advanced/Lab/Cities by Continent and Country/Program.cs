using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] city = Console.ReadLine().Split();
                
                if(!cities.ContainsKey(city[0]))              
                    cities.Add(city[0], new Dictionary<string, List<string>>());               
                if(!cities[city[0]].ContainsKey(city[1]))               
                    cities[city[0]][city[1]] = new List<string>();                                 
                cities[city[0]][city[1]].Add(city[2]);
            }

            foreach (var item in cities)
            {
                Console.WriteLine($"{item.Key}:");
                Console.WriteLine(string.Join("\n",   item.Value.Select(x => $" {x.Key} -> {string.Join(", ", x.Value)}")));
            }
        }
    }
}
