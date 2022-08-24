using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nsx[0];
            int s = nsx[1];
            int x = nsx[2];
            var stack = new Stack<int>();
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                stack.Push(nums[i]);
            }

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if(stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if(stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
