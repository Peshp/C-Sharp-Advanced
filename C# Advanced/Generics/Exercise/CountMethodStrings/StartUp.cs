﻿using System;

namespace CountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
                box.items.Add(Console.ReadLine());
           
            Console.WriteLine(box.MinFind(Console.ReadLine()));
        }
    }
}
