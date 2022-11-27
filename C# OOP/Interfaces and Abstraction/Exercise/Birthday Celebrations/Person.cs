using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebrations
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public Person(string name, int age, string id, string birth)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birth;
        }

        public void Birthyear(string[] birthyears, int output)
        {
            for (int i = 0; i < birthyears.Length; i++)
            {
                int[] year = birthyears[i].Split("/").Select(int.Parse).ToArray();
                if(year[2] == output)
                    Console.WriteLine(birthyears[i]);
            }
        }
    }
}
