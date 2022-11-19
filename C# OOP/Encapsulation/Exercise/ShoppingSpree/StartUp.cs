using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                DefinePeople(people);
                DefineProducts(products);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string personName = input.Split().First();
                string productName = input.Split().Last();
                Person currGuy = people.Find(p => p.Name == personName);
                Product currPr = products.Find(p => p.Name == productName);
                if (currGuy != null && currPr != null)
                    currGuy.IsMoneyEnough(currPr);
            }
            foreach (Person person in people)
            {
                if(person.Bag.Any())
                    Console.Write($"{person.Name} - {string.Join(", ", person.Bag)}\n");
                else
                    Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }

        private static List<Product> DefineProducts(List<Product> products)
        {        
            string[] pr = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < pr.Length; i++)
            {
                string name = pr[i].Split("=", StringSplitOptions.RemoveEmptyEntries).First();
                int cost = int.Parse(pr[i].Split("=", StringSplitOptions.RemoveEmptyEntries).Last());
                products.Add(new Product(name, cost));
            }
            return products;
        }

        private static List<Person> DefinePeople(List<Person> people)
        {          
            string[] guys = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < guys.Length; i++)
            {
                string name = guys[i].Split("=", StringSplitOptions.RemoveEmptyEntries).First();
                int money = int.Parse(guys[i].Split("=", StringSplitOptions.RemoveEmptyEntries).Last());
                people.Add(new Person(name, money));
            }
            return people;
        }
    }
}
