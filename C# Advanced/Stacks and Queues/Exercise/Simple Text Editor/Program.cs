using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var memory = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            memory.Push(string.Empty);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "1":
                        memory.Push(memory.Peek() + command[1]);
                        break;
                    case "2":
                        int count = int.Parse(command[1]);
                        string update = memory.Peek().Remove(memory.Peek().Length - count);
                        memory.Push(update);
                        break;
                    case "3":
                        int index = int.Parse(command[1]);
                        Console.WriteLine(memory.Peek()[index - 1]);
                        break;
                    case "4":
                        memory.Pop();
                        break;
                }
            }
        }
    }
}
