using System;
using System.Linq;

namespace ClassBoxData
{
    pu2. Animal Farmblic class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Box box = new Box(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                Console.WriteLine(box);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
