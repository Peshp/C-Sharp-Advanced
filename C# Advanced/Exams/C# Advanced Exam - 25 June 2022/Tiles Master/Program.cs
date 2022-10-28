using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            var white = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var grey = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var result = new SortedDictionary<string, int>();

            while (white.Any() && grey.Any())
            {            
                Walls(white, grey, result);
            }

            if(white.Count > 0)
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            else
                Console.WriteLine("White tiles left: none");

            if(grey.Count > 0)
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            else
                Console.WriteLine("Grey tiles left: none");

            foreach (var item in result.OrderByDescending(x => x.Value))           
                Console.WriteLine($"{item.Key}: {item.Value}");           
        }

        private static void Walls(Stack<int> white, Queue<int> grey, SortedDictionary<string, int> result)
        {
            int currWhite = white.Peek();
            int currGrey = grey.Peek();
            string currColor = "";

            if (currWhite != currGrey)
            {
                currWhite /= 2;
                white.Pop();
                white.Push(currWhite);

                grey.Dequeue();
                grey.Enqueue(currGrey);

                currWhite = white.Peek();
                currGrey = grey.Peek();
            }
            else
            {
                currColor = CalcResult(currGrey, currWhite, result);
                if (result.ContainsKey(currColor))
                    result[currColor]++;
                else
                    result.Add(currColor, 1);
                white.Pop();
                grey.Dequeue();
            }                         
        }

        private static string CalcResult(int currGrey, int currWhite, SortedDictionary<string, int> result)
        {
            if (currGrey + currWhite == 40)
                return "Sink";
            else if (currGrey + currWhite == 50)
                return "Oven";
            else if (currGrey + currWhite == 60)
                return "Countertop";
            else if (currGrey + currWhite == 70)
                return "Wall";
            else
                return "Floor";
        } 
    }
}
