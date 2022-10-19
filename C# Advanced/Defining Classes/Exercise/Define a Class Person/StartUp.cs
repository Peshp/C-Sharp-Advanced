using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());                     
            Family oldestMembers = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split();               
                
                Person oldPerson = new Person(token[0], int.Parse(token[1]));

                if (int.Parse(token[1]) > 30)
                    oldestMembers.AddPeople(oldPerson);                              
            }
          
            foreach (var p in oldestMembers.Order())
            {

            }
        }
    }
}
