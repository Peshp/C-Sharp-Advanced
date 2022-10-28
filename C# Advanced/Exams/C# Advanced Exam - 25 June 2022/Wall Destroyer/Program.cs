using System;
using System.Linq;

namespace Wall_Destroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var walls = new char[n, n];
            int holes = 0;
            int rodes = 0;

            for (int i = 0; i < n; i++)
            {
                char[] symbol = Console.ReadLine().ToCharArray();
                for (int j = 0; j < symbol.Length; j++)
                    walls[i, j] = symbol[j];
            }

            int[] all = FindVanko(walls);
            string command = Console.ReadLine();
            while (command != "End")
            {               
                switch (command)
                {
                    case "up":
                        all = FindVanko(walls);
                        if (all[0] - 1 <= 0)
                            break;
                        else if (walls[all[0] - 1, all[1]] == 'R')
                        {
                            rodes++;
                            Console.WriteLine("Vanko hit a rod!");
                        }                          
                        else if(walls[all[0] - 1, all[1]] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{all[0] - 1}, {all[1]}]!");
                            walls[all[0] - 1, all[1]] = 'V';                           
                        }                          
                        else if(walls[all[0] - 1, all[1]] == 'C')
                        {
                            walls[all[0], all[1]] = '*';
                            walls[all[0] - 1, all[1]] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            PrintMatrix(walls);
                            return;
                        }
                        else
                        {
                            walls[all[0] - 1, all[1]] = 'V';
                            walls[all[0], all[1]] = '*';
                            holes++;
                        }
                        break;
                    case "down":
                        all = FindVanko(walls);
                        if (all[0] + 1 >= walls.GetLength(0))
                            break;
                        else if (walls[all[0] + 1, all[1]] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodes++;
                        }                          
                        else if (walls[all[0] + 1, all[1]] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{all[0] + 1}, {all[1]}]!");
                            walls[all[0], all[1] + 1] = 'V';                            
                        }                           
                        else if (walls[all[0] + 1, all[1]] == 'C')
                        {
                            walls[all[0], all[1]] = '*';
                            walls[all[0] + 1, all[1]] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            PrintMatrix(walls);
                            return;
                        }
                        else
                        {
                            walls[all[0] + 1, all[1]] = 'V';
                            walls[all[0], all[1]] = '*';
                            holes++;
                        }
                        break;
                    case "right":
                        all = FindVanko(walls);
                        if (all[1] + 1 >= walls.GetLength(1))
                            break;
                        else if (walls[all[0], all[1] + 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodes++;
                        }                           
                        else if (walls[all[0], all[1] + 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{all[0]}, {all[1] + 1}]!");
                            walls[all[0], all[1] + 1] = 'V';                           
                        }                           
                        else if (walls[all[0], all[1] + 1] == 'C')
                        {
                            walls[all[0], all[1]] = '*';
                            walls[all[0], all[1] + 1] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            PrintMatrix(walls);
                            return;
                        }
                        else
                        {
                            walls[all[0], all[1] + 1] = 'V';
                            walls[all[0], all[1]] = '*';
                            holes++;
                        }
                        break;
                    case "left":
                        all = FindVanko(walls);
                        if (all[1] - 1 < 0)
                            break;
                        else if (walls[all[0], all[1] - 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            rodes++;
                        }                          
                        else if (walls[all[0], all[1] - 1] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{all[0]}, {all[1] - 1}]!");
                            walls[all[0], all[1] - 1] = 'V';                          
                        }                          
                        else if (walls[all[0], all[1] - 1] == 'C')
                        {
                            walls[all[0], all[1]] = '*';
                            walls[all[0], all[1] - 1] = 'E';
                            holes++;
                            Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                            PrintMatrix(walls);
                            return;
                        }
                        else
                        {
                            walls[all[0], all[1] - 1] = 'V';
                            walls[all[0], all[1]] = '*';
                            holes++;
                        }
                        break;
                }                              
                command = Console.ReadLine();
            }
            holes++;
            Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rodes} rod(s).");
            PrintMatrix(walls);
        }

        private static void PrintMatrix(char[,] walls)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    Console.Write(walls[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static int[] FindVanko(char[,] walls)
        {
            int[] v = new int[2];
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    if (walls[i, j] == 'V')
                    {
                        v[0] = i;
                        v[1] = j;
                    }                                             
                }                   
            }
            return v;
        }
    }
}
