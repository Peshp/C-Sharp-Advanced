using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IStationary
    {         
        public void StationaryCalling(string number)
        {     
            if(number.Any(char.IsLetter))
                Console.WriteLine("Invalid number!");
            else
                Console.WriteLine($"Dialing... {number}");
        }
    }
}
