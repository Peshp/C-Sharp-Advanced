using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Snake snake = new Snake(name);

            string name2 = Console.ReadLine();
            Bear bear = new Bear(name2);

            Console.WriteLine($"{snake} VS {bear}");
        }
    }
}