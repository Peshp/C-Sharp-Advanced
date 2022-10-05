using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> checker = n => n[0] == n.ToUpper()[0];
            Console.WriteLine(string.Join("\n",Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Where(w => checker(w)).ToArray()));
        }
    }
}
