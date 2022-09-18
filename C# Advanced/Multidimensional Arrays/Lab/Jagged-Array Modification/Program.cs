using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }
         
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                    break;

                string typeOf = command.Split()[0];   
                int row = int.Parse(command.Split()[1]);
                int col = int.Parse(command.Split()[2]);
                int value = int.Parse(command.Split()[3]);

                switch (typeOf)
                {
                    case "Add":
                        if(col > -1 && col < matrix.GetLength(1) && row > -1 && row < matrix.GetLength(0))
                            matrix[row, col] += value;
                        else
                            Console.WriteLine("Invalid coordinates");
                        break;
                    case "Subtract":
                        if (col > -1 && col < matrix.GetLength(1) && row > -1 && row < matrix.GetLength(0))
                            matrix[row, col] -= value;
                        else
                            Console.WriteLine("Invalid coordinates");                       
                        break;
                }
            }
            for (int row = 0; row < n; row++)
            {            
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
