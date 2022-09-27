using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            var cars = new HashSet<string>();

            while (command != "END")
            {
                command = Console.ReadLine();
                string[] token = command.Split(", ");

                switch (token[0])
                {
                    case "IN":
                        cars.Add(token[1]);
                        break;
                    case "OUT":
                        cars.Remove(token[1]);
                        break;
                }
            }

            if(cars.Count > 0)
                foreach (var item in cars)              
                    Console.WriteLine(item);   
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}
