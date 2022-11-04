using System;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] shop = new char[n, n];

            int currRow = 0;
            int currCol = 0;
            int oldRow = 0;
            int oldCol = 0;
            for (int i = 0; i < n; i++)
            {
                char[] s = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    shop[i, j] = s[j];
                    if(shop[i, j] == 'A')
                    {
                        oldRow = i;
                        oldCol = j;

                        currRow = i;
                        currCol = j;
                    }
                }
            }   
            int coins = 0;
            
            while (coins < 64)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up": currRow--; break;
                    case "down": currRow++; break;
                    case "right": currCol++; break;
                    case "left": currCol--; break;
                }
                
                if(Left(currCol, currRow, n))
                {
                    if (shop[currRow, currCol] == 'M')
                    {                   
                        shop[oldRow, oldCol] = '-';
                        shop[currRow, currCol] = '-';
                        int rowM = 0;
                        int colM = 0;

                        for (int i = 0; i < shop.GetLength(0); i++)
                        {
                            for (int j = 0; j < shop.GetLength(1); j++)
                            {
                                if (shop[i, j] == 'M')
                                {
                                    rowM = i;
                                    colM = j;
                                }
                            }
                        }
                        shop[rowM, colM] = 'A';
                    }
                    else if (Char.IsDigit(shop[currRow, currCol]))
                    {
                        coins += int.Parse(shop[currRow, currCol].ToString());
                        shop[currRow, currCol] = 'A';
                        shop[oldRow, oldCol] = '-';
                    }
                    else if (shop[currRow, currCol] == '-')
                    {
                        shop[currRow, currCol] = 'A';
                        shop[oldRow, oldCol] = '-';
                    }
                }
                else
                {
                    shop[oldRow, oldCol] = '-';
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(shop[i, j] == 'A')
                        {
                            oldRow = i;
                            oldCol = j;

                            currRow = i;
                            currCol = j;
                        }
                    }
                }             
            }
            if(coins >= 65)           
                Console.WriteLine("Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {coins} gold coins. ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(shop[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool Left(int currCol, int currRow, int n)
        {
            return currRow >= 0 && currRow < n && currCol >= 0 && currCol < n;
        }
    }
}
