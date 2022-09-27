using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = new HashSet<string>();  

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                if (command == "PARTY")
                {
                    while (true)
                    {
                        guests.Remove("PARTY");
                        string members = Console.ReadLine();
                        if (members == "END")
                            break;
                        if (guests.Contains(members))
                        {
                            guests.Remove(members);
                        }
                    }
                    break;
                }               
                guests.Add(command);            
            }
            Console.WriteLine(guests.Count);
            foreach (var item in guests.OrderBy(x => (int)x[0]))
                Console.WriteLine(item);
        }
    }
}
