using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel
    {
        private const double DEFAULT_ARMORTHIKNESS = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness) 
            : base(name, mainWeaponCaliber, speed, DEFAULT_ARMORTHIKNESS)
        {
            submergeMode = false;
        }
        public bool SubmergeMode => submergeMode;

        public void ToggleSubmergeMode()
        {
            submergeMode = !submergeMode;
            if (SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }
        public override void RepairVessel()
        {
            if (this.ArmorThickness < DEFAULT_ARMORTHIKNESS)
                this.ArmorThickness = DEFAULT_ARMORTHIKNESS;
        }

        public override string ToString()
        {
            string output = SubmergeMode ? "ON" : "OFF";
            return $"Submerge mode: {output}";
        }
    }
}
