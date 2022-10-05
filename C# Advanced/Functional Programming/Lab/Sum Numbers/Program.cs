using System;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ").Select(n => int.Parse(n)).ToArray();
            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());
        }
    }
}
