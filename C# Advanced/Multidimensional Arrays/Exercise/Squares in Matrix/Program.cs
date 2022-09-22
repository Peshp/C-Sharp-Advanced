using System;
using System.Linq;

namespace _2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rols = sizes[0];
            int cols = sizes[1];
            char[,] matrix = new char[rols, cols];
            MatrixMethod(rols, cols, matrix);
            int count = 0;

            if(matrix.GetLength(0) > 1 && matrix.GetLength(1) > 1)
            {
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                    {
                        if (matrix[i, j] == matrix[i, j + 1] &&
                           matrix[i, j] == matrix[i + 1, j + 1] &&
                           matrix[i, j] == matrix[i + 1, j])
                        {
                            count++;
                        }                      
                    }
                }                                  
            }              
            Console.WriteLine(count);
        }

        private static char[,] MatrixMethod(int rols, int cols, char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }
            return matrix;
        }
    }
}
