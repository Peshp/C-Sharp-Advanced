using System;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string ascii = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ascii[j];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            string result = ISContainsSymbol(matrix, symbol);
            Console.WriteLine(result);
        }

        static string ISContainsSymbol(int[,] matrix, char symbol)
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    char g = (char)matrix[i, j];
                    if (symbol == g)
                    {
                        result = $"({i}, {j})";
                        return result;
                    }
                }
            }
            result = $"{symbol} does not occur in the matrix";
            return result;
        }
    }
}
