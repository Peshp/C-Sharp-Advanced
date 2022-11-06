using System;
using System.Collections.Generic;
using System.Linq;

namespace Energy_Drinks
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffee = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            var energy = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            int stamat = 0;

            while (coffee.Any() && energy.Any())
            {
                int currCoffee = coffee.Peek();
                int currDrink = energy.Peek();

                if (stamat + currCoffee * currDrink <= 300)
                {
                    stamat += currCoffee * currDrink;
                    coffee.Pop();
                    energy.Dequeue();
                }
                else if(stamat - 30 >= 0)
                {
                    stamat -= 30;
                    coffee.Pop();
                    energy.Dequeue();
                    energy.Enqueue(currDrink);
                }
                else
                {
                    coffee.Pop();
                    energy.Dequeue();
                    energy.Enqueue(currDrink);
                }
            }
            
            if(energy.Count > 0)
                Console.WriteLine($"Drinks left: {string.Join(", ", energy)}");
            else
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");

            Console.WriteLine($"Stamat is going to sleep with {stamat} mg caffeine.");
        }
    }
}
