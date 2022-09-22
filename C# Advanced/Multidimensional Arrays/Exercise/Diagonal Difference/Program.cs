using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = nums[j];
                }
            }

            int first = 0;
            int second = 0;

            for (int i = 0; i < size; i++)
            {
                first += matrix[i, i];
                second += matrix[i, size - i - 1];
            }

            Console.WriteLine(Math.Abs(first - second));        
        }
    }
}
