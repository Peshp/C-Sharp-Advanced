using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_by_Age
{    
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] id = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                person.Add(id[0], int.Parse(id[1]));
            }

            string adult = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> filtered = FilterPeople(adult, age);
            Action<KeyValuePair<string, int>> createPrinter = CreatePrinter(format);

            foreach (var guy in person)
            {
                if (filtered(guy.Value))
                    createPrinter(guy);
            }
        }

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch(format)
            {
                case "name age":
                    return kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                case "age":
                    return kvp => Console.WriteLine($"{kvp.Value}");
                case "name":
                    return kvp => Console.WriteLine($"{kvp.Key}");
                default:
                    return null;
            }
        }

        public static Func<int, bool> FilterPeople(string adult, int ageHold)
        {
            switch(adult)
            {
                case "younger":
                    return x => x < ageHold;
                case "older":
                    return x => x >= ageHold;
                default:
                    return null;
            }
        }
    }
}
