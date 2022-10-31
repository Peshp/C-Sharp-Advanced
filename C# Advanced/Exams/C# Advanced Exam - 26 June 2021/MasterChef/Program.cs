using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            var dishes = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var quantity = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var result = new Dictionary<string, int>();
            
            while (dishes.Any() && quantity.Any())
            {
                if (quantity.Peek() == 0)
                {
                    quantity.Pop();
                    if (quantity.Count == 0)
                        break;
                }                   
                if (dishes.Peek() == 0)
                {
                    dishes.Dequeue();
                    if (dishes.Count == 0)
                        break;
                }
                FoodCount(dishes, quantity, result);               
            }
            if(result.Count == 4)           
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");           
            else           
                Console.WriteLine("You were voted off. Better luck next year.");
            if(dishes.Count > 0 || quantity.Count > 0)
            {                              
                Console.WriteLine($"Ingredients left: {dishes.Sum() + quantity.Sum()}");
            }
            if(result.Count > 0)
            {
                foreach (var item in result.OrderBy(a => a.Key))
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }
            
        }

        private static void FoodCount(Queue<int> dishes, Stack<int> quantity, Dictionary<string, int> result)
        {           
            int currDish = dishes.Peek();
            int currQuan = quantity.Peek();                         
            string currFood = Food(currDish, currQuan);    
            
            if(currFood == "Dipping sauce" || currFood == "Green salad" ||
                currFood == "Chocolate cake" || currFood == "Lobster")
            {               
                if (result.ContainsKey(currFood))
                    result[currFood]++;
                else
                    result.Add(currFood, 1);

                dishes.Dequeue();
                quantity.Pop();
            }
            else
            {
                quantity.Pop();
                currDish += 5;
                dishes.Dequeue();
                dishes.Enqueue(currDish);
            }
        }

        private static string Food(int currDish, int currQuan)
        {          
            if (currDish * currQuan == 150)
                return "Dipping sauce";
            else if (currDish * currQuan == 250)
                return "Green salad";
            else if (currDish * currQuan == 300)
                return "Chocolate cake";
            else if (currDish * currQuan == 400)
                return "Lobster";
            else
                return "nothing";
        }
    }
}
