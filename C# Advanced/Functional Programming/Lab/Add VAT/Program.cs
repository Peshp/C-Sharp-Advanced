using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> vat = n => (n * 1.2).ToString("F2");
            Console.WriteLine(string.Join("\n", Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).
                Select(double.Parse).Select(vat)).ToArray());  
        }
    }
}
