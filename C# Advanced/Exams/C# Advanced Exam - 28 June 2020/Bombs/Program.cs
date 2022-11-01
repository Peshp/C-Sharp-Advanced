using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var effects = FillQueue(first);
            var casing = FillStack(second);

            int[] table = new int[3];

            int dature = 0;
            int cherry = 0;
            int smoke = 0;

            while (true)
            {
                if (effects.Count == 0)
                    break;
                if (casing.Count == 0)
                    break;
                if (dature > 2 && cherry > 2 && smoke > 2)
                    break;

                int currEffect = effects.Peek();
                int currCasing = casing.Peek();              

                if (currEffect + currCasing == 40)
                {
                    dature++;
                    effects.Dequeue();
                    casing.Pop();
                }
                else if (currEffect + currCasing == 60)
                {
                    cherry++;
                    effects.Dequeue();
                    casing.Pop();
                }
                else if (currEffect + currCasing == 120)
                {
                    smoke++;
                    effects.Dequeue();
                    casing.Pop();
                }
                else
                {
                    casing.Pop();
                    currCasing -= 5;
                    casing.Push(currCasing);
                }                             
            }
            table = new int[] { cherry, dature, smoke };
            PrintResults(table, effects, casing);           
        }

        private static void PrintResults(int[] table, Queue<int> effects, Stack<int> casing)
        {
            if (table[0] >= 3 && table[1] >= 3 && table[2] >= 3)
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            else
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");          

            if(effects.Count > 0)
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            else
                Console.WriteLine("Bomb Effects: empty");

            if(casing.Count > 0)
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
            else
                Console.WriteLine("Bomb Casings: empty");

            Console.WriteLine($"Cherry Bombs: {table[0]}");
            Console.WriteLine($"Datura Bombs: {table[1]}");
            Console.WriteLine($"Smoke Decoy Bombs: {table[2]}");
        }

        public static Stack<int> FillStack(int[] second)
        {
            var casing = new Stack<int>();
            for (int i = 0; i < second.Length; i++)
                casing.Push(second[i]);
            return casing;            
        }

        public static Queue<int> FillQueue(int[] first)
        {
            var effects = new Queue<int>();
            for (int i = 0; i < first.Length; i++)            
                effects.Enqueue(first[i]);
            return effects;
        }
    }
}
