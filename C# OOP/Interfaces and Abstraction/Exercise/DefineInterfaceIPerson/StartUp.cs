﻿using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {        
            IPerson person = new Citizen(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
