using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                while (true)
                {                                     
                    double grams = DefineGrams(input);
                    double grams2 = DefineGrams2(input);
                    double grams3 = double.Parse(input.Split()[3]);
                    Dough dough = new Dough(input.Split()[1], input.Split()[2], grams3);
                    input = Console.ReadLine();
                    if (input == "END")
                    {
                        Console.WriteLine($"{(grams3 * 2 * grams2 * grams):f2}");
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static double DefineGrams2(string input)
        {
            double grams2 = 0;
            switch (input.Split()[2])
            {
                case "Crispy": grams2 = 0.9; break;
                case "Chewy": grams2 = 1.1; break;
                case "Homemade": grams2 = 1; break;
            }
            return grams2;
        }

        private static double DefineGrams(string input)
        {
            double grams = 0;
            switch (input.Split()[1])
            {
                case "White": grams = 1.5; break;
                case "Wholegrain": grams = 1; break;
            }
            return grams;
        }
    }
}
