using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, Dictionary<string, double>>();           
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Revision")
                    break;
                string[] token = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (!products.ContainsKey(token[0]))
                {
                    products.Add(token[0], new Dictionary<string, double>());
                }
                products[token[0]].Add(token[1], double.Parse(token[2]));
            }

            foreach (var item in products.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}->");
                Console.WriteLine(string.Join("\n", item.Value.Select(x => $"Product: {x.Key}, Price: {x.Value}")));
            }
        }
    }
}
