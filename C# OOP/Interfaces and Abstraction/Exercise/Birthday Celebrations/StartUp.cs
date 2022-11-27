using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("", 0, "", "");
            Pet pet = new Pet("", "");
            List<string> births = new List<string>();
            while (true)
            {             
                string input = Console.ReadLine();
                if (input == "End")
                    break;
                string[] token = input.Split();
                switch (token[0])
                {
                    case "Citizen":
                        person = new Person(token[1], int.Parse(token[2]), token[3], token[4]);
                        births.Add(person.Birthdate);
                        break;
                    case "Pet":
                        pet = new Pet(token[1], token[2]);
                        births.Add(pet.Birthdate);
                        break;
                    case "Robot":
                        Robot robot = new Robot(token[1], token[2]);
                        break;
                }
            }       
            person.Birthyear(births.ToArray(), int.Parse(Console.ReadLine()));           
        }
    }
}
