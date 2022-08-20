using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] == '(')
                {
                    stack.Push(i);
                }
                else if(text[i] == ')')
                {
                    int startIndex = stack.Pop();
                    string result = text.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
