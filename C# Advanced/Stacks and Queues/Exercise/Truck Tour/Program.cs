using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                if(CompleteCircle(queue))
                {
                    Console.WriteLine(i);
                    break;
                }
                queue.Enqueue(queue.Dequeue());
            }
        }

        private static bool CompleteCircle(Queue<string> queue)
        {
            int fuel = 0;
            bool canComplete = true;

            for (int i = 0; i < queue.Count; i++)
            {
                int petrol = int.Parse(queue.Peek().Split().First());
                int distance = int.Parse(queue.Peek().Split().Last());

                fuel += petrol - distance;
                if (fuel < 0)
                    canComplete = false;
                queue.Enqueue(queue.Dequeue());
            }
            return canComplete;
        }
    }
}
