using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nsx[0];
            int s = nsx[1];
            int x = nsx[2];

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if(queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if(queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
