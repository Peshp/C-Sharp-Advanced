using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartphone
    {
        void SmartphoneCalling(string number);  
        void SmartphoneBrowsing(string site);
    }
}
