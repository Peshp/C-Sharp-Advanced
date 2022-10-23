using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        class Box<T>
        {
            private List<T> list;
            public Box()
            {
                list = new List<T>();
            }
            public void Add(T element)
            {
                list.Insert(0, element);
            }
            public T Remove()
            {
                T topMost = list[0];
                list.RemoveAt(0);
                return topMost;
            }
            public int Count { get { return list.Count; } }
        }
        static void Main()
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }
}
