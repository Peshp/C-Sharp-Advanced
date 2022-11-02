using System;
using System.Text;

namespace Beaver_at_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] terrain = new char[n, n];
            int currRow = 0;
            int currCol = 0;
            int wood = 0;
            int currWood = 0;
            string regex = @"[a-z]";
            StringBuilder branchs = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string ground = Console.ReadLine();
                for (int j = 0; j < ground.Length; j++)
                {
                    terrain[i, j] = ground[j];
                    if (terrain[i, j] == 'B')
                    {
                        currRow = i;
                        currCol = j;
                    }
                    if (Char.IsLower(terrain[i, j]))
                        currWood++;
                }                                   
            }            

            int oldRow = currRow;
            int oldCol = currCol;

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "up": currRow--; break;
                    case "down": currRow++; break;
                    case "right": currCol++; break;
                    case "left": currCol--; break;
                }

                if(currRow >= 0 && currRow < n && currCol >= 0 && currCol < n)
                {
                    if(Char.IsLower(terrain[currRow, currCol]))
                    {
                        wood++;
                        branchs.Append(terrain[currRow, currCol]);
                        terrain[currRow, currCol] = 'B';
                        terrain[oldRow, oldCol] = '-';
                    }     
                    else if(terrain[currRow, currCol] == 'F')
                    {
                        FishMethod(terrain, currRow, currCol, oldRow, oldCol, regex, wood, branchs);
                        terrain[currRow, currCol] = '-';
                    }
                }
                else
                {
                    if (wood > 0)
                        wood--;
                }
                command = Console.ReadLine();
            }
            if(wood == currWood)
            {
                Console.WriteLine($"The Beaver successfully collect {wood} wood branches:" +
                    $"{string.Join(", ", branchs)}");
            }
            else
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {wood} branches left.");

            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    Console.Write(terrain[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void FishMethod(char[,] terrain, int currRow, int currCol, int oldRow, int oldCol,
            string regex, int wood, StringBuilder branchs)
        {
            if(currRow != 0 && currRow < terrain.GetLength(0) &&
                currCol != 0 && currCol < terrain.GetLength(1))
            {
                if (oldRow > currRow)
                {
                    if (Char.IsLower(terrain[0, currCol]))
                    {
                        wood++;
                        branchs.Append(terrain[0, currCol]);
                    }                      
                    terrain[0, currCol] = 'B';
                }                  
                else if(oldRow < currRow)
                {
                    if (Char.IsLower(terrain[terrain.GetLength(0) - 1, currCol]))
                    {
                        wood++;
                        branchs.Append(terrain[terrain.GetLength(0) - 1, currCol]);
                    }                       
                    terrain[terrain.GetLength(0), currCol] = 'B';
                }                   
                if (oldCol < currCol)
                {
                    if (Char.IsLower(terrain[currRow, terrain.GetLength(1) - 1]))
                    {
                        wood++;
                        branchs.Append(terrain[currRow, terrain.GetLength(1) - 1]);
                    }                       
                    terrain[currRow, terrain.GetLength(1)] = 'B';
                }                   
                else if(oldCol > currCol)
                {
                    if (Char.IsLower(terrain[currRow, 0]))
                    {
                        wood++;
                        branchs.Append(terrain[currRow, 0]);
                    }                      
                    terrain[currRow, 0] = 'B';
                }                   
            }
            else
            {
                if (oldRow > currRow)
                {
                    if (Char.IsLower(terrain[terrain.GetLength(0) - 1, currCol]))
                    {
                        branchs.Append(terrain[terrain.GetLength(0), currCol]);
                        wood++;
                    }                        
                    terrain[terrain.GetLength(0) - 1, currCol] = 'B';
                }                   
                else if(oldRow < currRow)
                {
                    if (Char.IsLower(terrain[0, currCol]))
                    {
                        branchs.Append(terrain[0, currCol]);
                        wood++;
                    }                      
                    terrain[0, currCol] = 'B';
                }                  
                else if(oldCol < currCol)
                {
                    if (Char.IsLower(terrain[currRow, 0]))
                    {
                        branchs.Append(terrain[currRow, 0]);
                        wood++;
                    }                      
                    terrain[currRow, 0] = 'B';
                }                   
                else if(oldCol > currCol)
                {
                    if (Char.IsLower(terrain[currRow, terrain.GetLength(1) - 1]))
                    {
                        branchs.Append(terrain[currRow, terrain.GetLength(1) - 1]);
                        wood++;
                    }                       
                    terrain[currRow, terrain.GetLength(1)] = 'B';
                }                   
            }
        }
    }
}
