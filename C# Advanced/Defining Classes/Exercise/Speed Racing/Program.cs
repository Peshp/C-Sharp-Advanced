using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carinf = Console.ReadLine().Split();              
                cars.Add(new Car(carinf[0], double.Parse(carinf[1]), double.Parse(carinf[2])));
            }
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                    break;
                string model = command.Split().Skip(1).First();                
                double km = double.Parse(command.Split().Last());
                Car currCar = cars.Find(c => c.Model == model);
                currCar.Drive(km);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
