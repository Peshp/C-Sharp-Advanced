using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;
            
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            List<int> result = new List<int>();

            for (int i = nums[0]; i <= nums[1]; i++)          
                numbers.Add(i);

            string command = Console.ReadLine();
            if (command == "odd")
                result = numbers.FindAll(isOdd);
            else
                result = numbers.FindAll(isEven);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
