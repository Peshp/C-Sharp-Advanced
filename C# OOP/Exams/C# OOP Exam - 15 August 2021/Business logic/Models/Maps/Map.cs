using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
                return $"Race cannot be completed because both racers are not available!";
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            if(racerOne.IsAvailable() && !racerTwo.IsAvailable())
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";

            racerOne.Race();
            racerTwo.Race();

            double racingBehaviorMultiplier1 = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            double chanceOfWinning1 = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplier1;
            double racingBehaviorMultiplier2 = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            double chanceOfWinning2 = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplier1;

            IRacer winner = null;
            if (chanceOfWinning1 > chanceOfWinning2)
                winner = racerOne;
            else if (chanceOfWinning2 > chanceOfWinning1)
                winner = racerTwo;
            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
        }
    }
}
