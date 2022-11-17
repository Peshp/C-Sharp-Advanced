using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {    
        private string name;
        private List<Person> firstTeam;
        private List<Person> reverseTeam;
        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reverseTeam = new List<Person>();
        }
        public string Name => this.name;
        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam;
        public IReadOnlyCollection<Person> ReverseTeam => this.reverseTeam;
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
                firstTeam.Add(person);
            else
                reverseTeam.Add(person);
        }
    }
}
