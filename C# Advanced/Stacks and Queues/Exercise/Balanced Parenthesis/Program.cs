using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string arr = Console.ReadLine();
            var queue = new Queue<char>();
            var stack = new Stack<char>();

            bool yesOrno = false;
            for (int i = 0; i < arr.Length; i++)
            {
                queue.Enqueue(arr[i]);
                stack.Push(arr[i]);
            }
         
            for (int i = 0; i < queue.Count; i++)
            {
                char item = queue.Dequeue();
                char item2 = stack.Pop();

                if (item == '(')
                {
                    if (item2 == ')')                    
                        yesOrno = true;                   
                    else
                    {
                        yesOrno = false;
                        break;
                    }                       
                }
                else if(item == '{')
                {
                    if (item2 == '}')
                        yesOrno = true;
                    else
                    {
                        yesOrno = false;
                        break;
                    }                       
                }
                else if(item == '[')
                {
                    if (item2 == ']')
                        yesOrno = true;
                    else
                    {
                        yesOrno = false;
                        break;
                    }                       
                }          
            }
            if (yesOrno == true)           
                Console.WriteLine("YES");            
            else           
                Console.WriteLine("NO");          
        }
    }
}
