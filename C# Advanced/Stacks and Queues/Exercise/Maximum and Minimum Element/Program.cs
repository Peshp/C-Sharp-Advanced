using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

            int x = int.Parse(Console.ReadLine());
            for (int i = 0; i < x; i++)
            {
                int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
                switch (n[0])
                {
                    case 1:
                        int num = n[1];
                        stack.Push(num);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if(stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if(stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
