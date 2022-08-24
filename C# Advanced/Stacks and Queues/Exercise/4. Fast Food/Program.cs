using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>();

            for (int i = 0; i < orders.Length; i++)
            {
                queue.Enqueue(orders[i]);
            }

            int max = queue.Max();
            bool notEnough = false;
            while (true)
            {
                for (int i = 0; i < orders.Length; i++)
                {
                    if (orders[i] <= food && queue.Count > 0)
                    {
                        food -= orders[i];
                        queue.Dequeue();
                    }
                    else
                    {
                        notEnough = true;
                        break;                        
                    }
                }
                if(notEnough)
                {
                    break;
                }
            }

            Console.WriteLine(max);
            if(queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
