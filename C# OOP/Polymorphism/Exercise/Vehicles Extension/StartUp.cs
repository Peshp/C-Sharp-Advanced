using System;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]),
                double.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine().Split();
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]),
                double.Parse(busInfo[2]));       

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "Drive":
                        if (command[1] == "Car")
                            car.Drive(double.Parse(command[2]));
                        else if(command[1] == "Truck")
                            truck.Drive(double.Parse(command[2]));
                        else if(command[1] == "Bus")
                            bus.Drive(double.Parse(command[2]));
                        break;
                    case "Refuel":
                        if (command[1] == "Car")
                            car.Refuel(double.Parse(command[2]));
                        else if(command[1] == "Truck")
                            truck.Refuel(double.Parse(command[2]));
                        else if(command[1] == "Bus")
                            bus.Refuel(double.Parse(command[2]));
                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(command[2]));
                        break;
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
