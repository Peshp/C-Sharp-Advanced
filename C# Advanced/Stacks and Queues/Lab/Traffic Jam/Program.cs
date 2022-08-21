using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string car = "";
            var pass = new Queue<string>();
            int passed = 0;

            while (car != "end")
            {
                car = Console.ReadLine();
                          
                if(car == "green")
                {
                    for (int i = 1; i <= n; i++)
                    {                       
                        if(pass.Count > 0)
                        {
                            Console.WriteLine($"{pass.Dequeue()} passed!");
                            passed++;
                        }
                    }
                }
                else
                {
                    pass.Enqueue(car);
                }
            }
            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}
