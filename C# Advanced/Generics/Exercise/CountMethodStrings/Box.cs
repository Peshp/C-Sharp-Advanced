using System;
using System.Collections.Generic;
using System.Text;

namespace CountMethodStrings
{
    public class Box<T>
    {
        public Box()
        {
            items = new List<T>();
        }
        public List<T> items { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
        public int MinFind(T check)
        {
            int count = 0;

            foreach (var item in items)
            {
                if (item.ToString().CompareTo(check) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
