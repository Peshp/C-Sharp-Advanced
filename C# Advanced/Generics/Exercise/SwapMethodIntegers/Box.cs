using System;
using System.Collections.Generic;
using System.Text;

namespace SwapMethodIntegers
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
                sb.Append($"{item.GetType()}: {item}\n");
            }
            return sb.ToString().TrimEnd();
        }
        public void Swap(int first, int second)
        {
            T temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }
    }
}
