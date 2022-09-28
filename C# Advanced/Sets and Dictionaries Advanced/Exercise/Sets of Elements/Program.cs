using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var nElements = new HashSet<int>();
            var mElements = new HashSet<int>();

            for (int i = 0; i < nm[0]; i++)           
                nElements.Add(int.Parse(Console.ReadLine()));
            for (int i = 0; i < nm[1]; i++)
                mElements.Add(int.Parse(Console.ReadLine()));

            nElements.IntersectWith(mElements);
            Console.WriteLine(string.Join(" ", nElements));
        }
    }
}
