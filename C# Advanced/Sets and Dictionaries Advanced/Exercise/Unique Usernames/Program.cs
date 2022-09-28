using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var unique = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)                        
                unique.Add(Console.ReadLine());

            foreach (var item in unique)
                Console.WriteLine(item);
        }
    }
}
