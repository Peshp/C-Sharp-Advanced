using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            var potato = new Queue<string>(names);
            int n = int.Parse(Console.ReadLine());

            while (potato.Count > 1)
            {
                for (int i = 1; i <= n - 1; i++)
                {
                    var player = potato.Dequeue();
                    potato.Enqueue(player);
                }
                Console.WriteLine($"Removed {potato.Dequeue()}");
            }
            Console.WriteLine($"Last is {potato.Dequeue()}");
        }
    }
}
