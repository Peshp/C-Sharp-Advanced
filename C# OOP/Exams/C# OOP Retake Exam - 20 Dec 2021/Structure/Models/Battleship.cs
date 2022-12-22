using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const double ARMORTHIKNESS_DEFAULT = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, ARMORTHIKNESS_DEFAULT)
        {
            sonarMode = false;
        }
        public bool SonarMode => sonarMode;
        public void ToggleSonarMode()
        {
            sonarMode = !sonarMode;
            if(SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        
        public override void RepairVessel()
        {
            if (this.ArmorThickness < ARMORTHIKNESS_DEFAULT)
                this.ArmorThickness = ARMORTHIKNESS_DEFAULT;
        }

        public override string ToString()
        {          
            string output = SonarMode ? "ON" : "OFF";
            return $"Sonar mode: {output}";
        }
    }
}
