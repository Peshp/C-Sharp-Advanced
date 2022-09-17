using System;
using System.Collections.Generic;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = new Queue<string>();
            string[] list = Console.ReadLine().Split(", ");

            for (int i = 0; i < list.Length; i++)
            {
                songs.Enqueue(list[i]);
            }
           
            while (true)
            {
                string command = Console.ReadLine();               

                if(songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                if(command.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if(command.Contains("Add"))
                {
                    string song = command.Substring(4);                   
                    if (songs.Contains(song))
                    {

                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if(command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }               
            }
        }
    }
}
