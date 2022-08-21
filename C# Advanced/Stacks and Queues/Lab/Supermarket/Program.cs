using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {           
            var names = new Queue<string>();

            while (true)
            {
                string name = Console.ReadLine();
                if(name == "End")
                {
                    break;
                }

                if (name == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }                    
                }
                else
                {
                    names.Enqueue(name);
                }                            
            }
           
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
