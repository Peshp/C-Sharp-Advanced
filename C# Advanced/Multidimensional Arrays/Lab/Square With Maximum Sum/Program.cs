using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int a = input.Split(", ").Select(int.Parse).First();
        int b = input.Split(", ").Select(int.Parse).Last();
        int[,] matrix = new int[a, b];
        for (int i = 0; i < a; i++)
        {
            int[] n = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            for (int j = 0; j < b; j++)
            {
                matrix[a, b] = n[j];
            }
        }

        int max = int.MinValue;
        int bigRow = -1;
        int bigCol = -1;
        for (int i = 0; i < a - 1; i++)
        {
            for (int j = 0; j < b - 1; j++)
            {
                int sum = matrix[i, j]
                    + matrix[i, j + 1]
                    + matrix[i + 1, j]
                    + matrix[i + 1, j + 1];

                if (sum > max)
                {
                    max = sum;
                    bigRow = i;
                    bigCol = j;
                }
            }
        }

        Console.WriteLine($"{matrix[bigRow, bigCol]} {matrix[bigCol, bigRow + 1]}");
        Console.WriteLine($"{matrix[bigRow + 1, bigCol]} {matrix[bigRow + 1, bigCol + 1]}");
        Console.WriteLine(max);
    }
}
