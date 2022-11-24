using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IPerson person = new Person("", 0, "");
            IRobot robot = new Robot("", "");
           
            List<string> idS = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                    break;
                string[] token = input.Split();
                if(token.Length == 3)
                {
                    person = new Person(token[0], int.Parse(token[1]), token[2]);
                    idS.Add(person.Id);
                }
                else if(token.Length == 2)
                {
                    robot = new Robot(token[0], token[1]);
                    idS.Add(robot.Id);
                }              
            }
            person.IdsCalc(idS, Console.ReadLine());
        }
    }
}
