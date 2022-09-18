using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int heigh = int.Parse(Console.ReadLine());
            long[][] pascal = new long[heigh][];
            int curr = 1;

            for (long row = 0; row < heigh; row++)
            {
                pascal[row] = new long[curr];
                long[] currRow = pascal[row];
                currRow[0] = 1;
                currRow[currRow.Length - 1] = 1;
                curr++;

                if(currRow.Length > 2)
                {
                    for (long i = 1; i < currRow.Length - 1; i++)
                    {
                        long[] previousRow = pascal[row - 1];
                        long sum = previousRow[i] + previousRow[i - 1];
                        currRow[i] = sum;
                    }
                }
            }

            foreach (long[] row in pascal)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
