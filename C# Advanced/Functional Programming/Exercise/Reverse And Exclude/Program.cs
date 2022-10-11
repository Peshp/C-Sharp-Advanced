using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            nums.Reverse();

            int divider = int.Parse(Console.ReadLine());
            Predicate<int> check = (num) => num % divider == 0;
            List<int> result = new List<int>();

            foreach (var num in nums)           
                if (!check(num))
                    result.Add(num);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
