using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList();
            rndList.Add("Shte");
            rndList.Add("eba");
            rndList.Add("judge e hubav");
            rndList.Add("na judge");
            rndList.Add("maikata");
            rndList.RandomString();
            Console.WriteLine(string.Join(" ", rndList));
        }
    }
}
