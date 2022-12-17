using System;
using System.Collections.Generic;
using System.Linq;

namespace Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> valid = new List<int>();
            while (valid.Count < 10)
            {                
                try
                {
                    if (!valid.Any())
                        valid.Add(ReadNumber(1, 100));
                    else
                        valid.Add(ReadNumber(valid.Max(), 100));
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                }
                catch(ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
            Console.WriteLine(string.Join(", ", valid));
        }

        static int ReadNumber(int v1, int v2)
        {
            string input = Console.ReadLine();
            int num;
            try
            { num = int.Parse(input); }
            catch
            { throw new FormatException("Invalid Number!"); }

            if (int.Parse(input) <= v1 || int.Parse(input) >= v2)
                throw new ArgumentException($"Your number is not in range {v1} - 100!");
            return num;
        }
    }
}
