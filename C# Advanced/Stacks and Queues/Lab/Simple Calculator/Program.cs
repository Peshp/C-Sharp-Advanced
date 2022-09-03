using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var queue = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                queue.Enqueue(input[i]);
            }

            int result = 0;
            bool action = true;
            while (queue.Count != 0)
            {
                string sign = queue.Dequeue();

                if(sign == "+")
                {
                    action = true;
                }
                else if(sign == "-")
                {
                    action = false;
                }
                else if(action == true)
                {
                    result += int.Parse(sign);
                }
                else if(action == false)
                {
                    result -= int.Parse(sign);
                }
            }
            Console.WriteLine(result);
        }
    }
}
