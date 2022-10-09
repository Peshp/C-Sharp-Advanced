using System;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = (names) => Console.WriteLine($"Sir {names}");
            string[] names = Console.ReadLine().Split();
            foreach (var name in names)           
                print(name);           
        }
    }
}
