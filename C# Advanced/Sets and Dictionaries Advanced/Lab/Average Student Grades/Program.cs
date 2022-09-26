using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] students = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var grade = Convert.ToDecimal(students[1]);
                if (grades.ContainsKey(students[0]))
                    grades[students[0]].Add(grade);
                else
                    grades.Add(students[0], new List<decimal>() { grade });
            }

            foreach (var item in grades)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(x => x.ToString("F2")))} " +
                    $"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
