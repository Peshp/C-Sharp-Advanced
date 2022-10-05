using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(", ").Select(n => int.Parse(n)).
            Where(n => n % 2 == 0).OrderBy(n => n).ToArray()));
        }
    }
}
