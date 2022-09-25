using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] rows = Console.ReadLine().Split().Select(double.Parse).ToArray();
                matrix[i] = rows;
            }

            MatrixRows(matrix);
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                    break;

                string[] token = command.Split();
                switch (token[0])
                {
                    case "Add":
                        if (int.Parse(token[1]) >= 0 && int.Parse(token[1]) <= matrix.Length
                            && int.Parse(token[2]) >= 0 && int.Parse(token[2]) <= matrix.Length)
                            matrix[int.Parse(token[1])][int.Parse(token[2])] += int.Parse(token[3]);
                        break;
                    case "Subtract":
                        if (int.Parse(token[1]) >= 0 && int.Parse(token[1]) <= matrix.Length
                            && int.Parse(token[2]) >= 0 && int.Parse(token[2]) <= matrix.Length)
                            matrix[int.Parse(token[1])][int.Parse(token[2])] -= int.Parse(token[3]);
                        break;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private static double[][] MatrixRows(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }
                    for (int j = 0; j < matrix[i + 1].Length; j++)
                    {
                        matrix[i + 1][j] /= 2;
                    }
                }
            }
            return matrix;
        }
    }
}
