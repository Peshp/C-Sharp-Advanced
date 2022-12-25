using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            switch (type)
            {
                case "SuperCar": car = new SuperCar(make, model, VIN, horsePower); break;
                case "TunedCar": car = new TunedCar(make, model, VIN, horsePower); break;
                default: return "Invalid car type!";
            }
            cars.Add(car);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;
            ICar car = cars.FindBy(carVIN);
            if (car == null)
                throw new ArgumentException("Car cannot be found!");

            switch (type)
            {
                case "ProfessionalRacer": racer = new ProfessionalRacer(username, car); break;
                case "StreetRacer": racer = new StreetRacer(username, car); break;
                default: throw new ArgumentException("Invalid racer type!");
            }
            racers.Add(racer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);
            if (racerOne == null)
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            if(racerTwo == null)
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRacer racer in racers.Models.OrderByDescending(x => x.DrivingExperience).
                ThenBy(x => x.Username))
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
