using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BorderControl
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public Person(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public void IdsCalc(List<string> ids, string output)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i].EndsWith(output))
                    Console.WriteLine(ids[i]);
            }
        }
    }
}
