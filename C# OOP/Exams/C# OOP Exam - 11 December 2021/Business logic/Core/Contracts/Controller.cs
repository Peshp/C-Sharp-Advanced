using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            gyms = new List<IGym>();
            equipment = new EquipmentRepository();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, 
            string motivation, int numberOfMedals)
        {
            IGym gym = gyms.Find(g => g.Name == gymName);
            IAthlete athlete;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "BoxingGym")
                    return OutputMessages.InappropriateGym;
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != "WeightliftingGym")
                    return OutputMessages.InappropriateGym;
            }
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            gym.AddAthlete(athlete);
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment2;
            if (equipmentType == "BoxingGloves")
                equipment2 = new BoxingGloves();
            else if (equipmentType == "Kettlebell")
                equipment2 = new Kettlebell();
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            equipment.Add(equipment2);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
                gym = new BoxingGym(gymName);
            else if (gymType == "WeightliftingGym")
                gym = new WeightliftingGym(gymName);
            else
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.Find(g => g.Name == gymName);
            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment desiredEquipment = equipment.Models.FirstOrDefault(e => e.GetType().Name == equipmentType);
            if (desiredEquipment == null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            if(gym != null)
            {
                gym.AddEquipment(desiredEquipment);
                equipment.Remove(desiredEquipment);
            }
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            return String.Join(Environment.NewLine, gyms.Select(g => g.GymInfo()));
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.Find(g => g.Name == gymName);
            gym.Exercise();
            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
