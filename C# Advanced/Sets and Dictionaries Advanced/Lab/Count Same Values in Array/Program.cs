using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            var dictionary = new Dictionary<double, int>();          

            foreach (var item in numbers)
            {
                if (dictionary.ContainsKey(item))
                    dictionary[item]++;
                else
                    dictionary[item] = 1;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
