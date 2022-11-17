using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private int age;
        private string lastName;
        private string firstName;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName
        {
            get { return this.FirstName; }
            private set
            {
                if (value.Length < 3)
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");             
                firstName = value;
            }
        }
            
        public string LastName
        {
            get { return this.LastName; }
            private set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");       
                lastName = value;
            }
        }
        public int Age
        {
            get { return this.Age; }
            private set
            {
                if (value < 1)
                    throw new ArgumentException("Age cannot be zero or a negative integer!");            
                age = value;
            }
        }
        public decimal Salary
        {
            get { return this.Salary; }
            private set
            {
                if (value < 650)
                    throw new ArgumentException("Salary cannot be less than 650 leva!");              
                salary = value;
            }
        }
        public void IncreaseSalary(decimal parcentage)
        {
            if (this.Age > 30)
                this.Salary += this.Salary * parcentage / 100;
            else
                this.Salary += this.Salary * parcentage / 200;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
