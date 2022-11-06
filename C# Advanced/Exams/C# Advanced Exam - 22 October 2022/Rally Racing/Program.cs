using System;
using System.Collections.Generic;

namespace Rally_Racing
{
    class Program
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());
            string[,] terrain = new string[n, n];
            string number = Console.ReadLine();

            int currRow = 0;
            int currCol = 0;
            int oldRow = 0;
            int oldCol = 0;
            int distance = 0;

            for (int i = 0; i < n; i++)
            {
                string[] t = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    terrain[i, j] = t[j];                   
                }
            }
            
            string command = Console.ReadLine();
            while (command != "End")
            {
                switch(command)
                {
                    case "up": currRow--; break;
                    case "down": currRow++; break;
                    case "right": currCol++; break;
                    case "left": currCol--; break;
                }              
                if(terrain[currRow, currCol] == ".")
                {
                    distance += 10;                   
                }
                else if(terrain[currRow, currCol] == "T")
                {
                    distance += 30;
                    int rowT = 0;
                    int colT = 0;

                    terrain[oldRow, oldCol] = ".";
                    terrain[currRow, currCol] = ".";
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if(terrain[i, j] == "T")
                            {
                                rowT = i;
                                colT = j;
                            }
                        }
                    }
                    terrain[rowT, colT] = ".";
                    currRow = rowT;
                    currCol = colT;
                }
                else if(terrain[currRow, currCol] == "F")
                {
                    terrain[currRow, currCol] = "C";
                    distance += 10;                   
                    Console.WriteLine($"Racing car {number} finished the stage!");
                    break;
                }
                oldRow = currRow;
                oldCol = currCol;
                command = Console.ReadLine();               
            }

            if(command == "End")
                Console.WriteLine($"Racing car {number} DNF.");
            Console.WriteLine($"Distance covered {distance} km.");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    terrain[currRow, currCol] = "C";
                    Console.Write(terrain[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
