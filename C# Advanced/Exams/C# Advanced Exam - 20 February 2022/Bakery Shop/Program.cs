using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());
            var flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());
            var result = new SortedDictionary<string, int>();

            while (water.Any() && flour.Any())          
                CalcProducts(water, flour, result);

            foreach (var item in result.OrderByDescending(x => x.Value))           
                Console.WriteLine($"{item.Key}: {item.Value}");
            if(water.Count > 0)
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            else
                Console.WriteLine("Water left: None");
            if(flour.Count > 0)
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            else
                Console.WriteLine("Flour left: None");
        }

        private static void CalcProducts(Queue<double> water, Stack<double> flour, SortedDictionary<string, int> result)
        {
            var currWater = water.Peek();
            var currFlour = flour.Peek();

            var mix = currWater + currFlour;
            string product = Mix(mix, currWater, currFlour);

            

            if(product == "nothing")
            {
                if(currWater == currFlour)
                {
                    water.Dequeue();
                    flour.Pop();
                    product = "Croissant";
                }                   
                else
                {
                    water.Dequeue();
                    flour.Pop();                   
                    currFlour -= currWater;
                    flour.Push(currFlour);
                    product = "Croissant";               
                }
                if (result.ContainsKey(product))
                    result[product]++;
                else
                    result.Add(product, 1);                
            }
            else
            {
                if (result.ContainsKey(product))
                    result[product]++;
                else
                    result.Add(product, 1);
                flour.Pop();
                water.Dequeue();
            }                                     
        }

        private static string Mix(double mix, double currWater, double currFlour)
        {          
            if (currWater * 100 / mix == 40)
                return "Muffin";
            else if (currWater * 100 / mix == 30)
                return "Baguette";
            else if (currWater * 100 / mix == 20)
                return "Bagel";
            else           
                return "nothing";                 
        }
    }
}
