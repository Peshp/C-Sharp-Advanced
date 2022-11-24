using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        string Id { get; set; }
        void IdsCalc(List<string> ids, string output);
    }
}
