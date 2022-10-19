using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }      
        public Family()
        {
            People = new List<Person>();
        }
        public void AddPeople(Person member)
        {
            People.Add(member);
        }
        public Person Order()
        {
            return People.OrderBy(p => p.Name);
        }
    }
}
