using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings customStack = new StackOfStrings();
            var a = new List<string>();
            a.Add("a");
            a.Add("b");
            a.Add("c");
            customStack.AddRange(a);
            Console.WriteLine(customStack.IsEmpty());
            Console.WriteLine(string.Join("", customStack));
        }
    }
}
