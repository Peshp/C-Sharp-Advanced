using System;
using System.Collections.Generic;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nums = new HashSet<int>();
            int count = 1;
            int even = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());                
                if(nums.Contains(num))
                {
                    count++;
                    if(count == 3)
                    {
                        count = 1;
                    }
                    if (count % 2 == 0)
                    {
                        even = num;                      
                    }
                }
                nums.Add(num);
            }
            Console.WriteLine(even);
        }
    }
}
