using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.Sort();
            if(numbers.Count > 3)
                Console.WriteLine(string.Join(" ", numbers.OrderByDescending(x => x).Take(3)));
            else
                Console.WriteLine(string.Join(" ", numbers.OrderByDescending(x => x)));
        }
    }
}
