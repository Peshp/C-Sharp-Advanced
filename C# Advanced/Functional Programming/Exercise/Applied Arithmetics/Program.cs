using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int, int> add = (num, num1) => num + num1;
            Func<int, int, int> sub = (num, num1) => num - num1;
            Func<int, int, int> multi = (num, num1) => num * num1;
            Action<int[]> print = (num) => Console.WriteLine(string.Join(" ", num));
            string command = "";

            while (command != "end")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        for (int i = 0; i < num.Length; i++)                      
                            num[i] = add(num[i], 1);
                        break;
                    case "multiply":
                        for (int i = 0; i < num.Length; i++)
                            num[i] = multi(num[i], 2);
                        break;
                    case "subtract":
                        for (int i = 0; i < num.Length; i++)
                            num[i] = sub(num[i], 1);
                        break;
                    case "print":
                        print(num);
                        break;
                }
            }
        }
    }
}
