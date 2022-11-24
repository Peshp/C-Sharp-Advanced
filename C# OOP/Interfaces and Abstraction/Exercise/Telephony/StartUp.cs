using System;
using System.Collections.Generic;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smart = new Smartphone();
            StationaryPhone phone = new StationaryPhone();

            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            foreach (var item in numbers)
            {
                if (item.Length == 10)
                    smart.SmartphoneCalling(item);
                else if (item.Length == 7)
                    phone.StationaryCalling(item);
            }

            foreach (var item in sites)
                smart.SmartphoneBrowsing(item);
        }
    }
}
