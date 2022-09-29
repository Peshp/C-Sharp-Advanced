using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var counter = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                if (!counter.ContainsKey(symbol))
                    counter.Add(symbol, 0);
                counter[symbol]++;
            }
            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
