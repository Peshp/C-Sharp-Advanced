using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                stack.Push(nums[i]);
            }

            string command = "";
            while (command != "end")
            {
                command = Console.ReadLine();
                string[] token = command.Split();

                switch (token[0])
                {
                    case "add":
                        stack.Push(int.Parse(token[1]));
                        stack.Push(int.Parse(token[2]));
                        break;
                    case "remove":
                        if(int.Parse(token[1]) <= stack.Count)
                        {
                            for (int i = 0; i < int.Parse(token[1]); i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }

            int sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
