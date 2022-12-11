using System;

namespace Operations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var mo = new MathOperations();
            Console.WriteLine(mo.Add(2, 3));
            Console.WriteLine(mo.Add(2.3, 3.2, 4.23));
            Console.WriteLine(mo.Add(2.3m, 3.2m, 4.23m));
        }
    }
}
