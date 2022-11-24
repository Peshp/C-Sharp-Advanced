using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {       
        public void SmartphoneBrowsing(string site)
        {
            if (site.Any(char.IsDigit))
                Console.WriteLine("Invalid URL!");
            else
                Console.WriteLine($"Browsing: {site}!");
        }
        public void SmartphoneCalling(string number)
        {
            if (number.Any(char.IsLetter))
                Console.WriteLine("Invalid number!");
            else
                Console.WriteLine($"Calling... {number}");
        }
    }
}
