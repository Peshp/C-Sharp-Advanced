using System;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> names = (name) => Console.WriteLine(string.Join("\n", name));
            string[] name = Console.ReadLine().Split();
            names(name);
        }
    }
}
