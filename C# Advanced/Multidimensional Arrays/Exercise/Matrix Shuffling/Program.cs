using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];

            MatrixMethod(matrix);
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                    break;

                string[] token = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (IsInvalid(sizes, token) == false)               
                    Console.WriteLine("Invalid input!");
                else
                {                  
                    string current = matrix[int.Parse(token[1]), int.Parse(token[2])];
                    matrix[int.Parse(token[1]), int.Parse(token[2])] = matrix[int.Parse(token[3]), int.Parse(token[4])];
                    matrix[int.Parse(token[3]), int.Parse(token[4])] = current;
                    PrintMatrix(matrix);
                }                             
            }
        }

        private static string[,] PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            return matrix;
        }

        private static bool IsInvalid(int[] sizes, string[] token)
        {
            return
                token[0] == "swap"
                && token.Length == 5
                && int.Parse(token[1]) >= 0 && int.Parse(token[1]) < sizes[0]
                && int.Parse(token[2]) >= 0 && int.Parse(token[2]) < sizes[1]
                && int.Parse(token[3]) >= 0 && int.Parse(token[3]) < sizes[0]
                && int.Parse(token[4]) >= 0 && int.Parse(token[4]) < sizes[1];
        }

        private static string[,] MatrixMethod(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }
            return matrix;
        }
    }
}
