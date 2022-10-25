using System;
using System.Linq;

namespace SwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.items.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
