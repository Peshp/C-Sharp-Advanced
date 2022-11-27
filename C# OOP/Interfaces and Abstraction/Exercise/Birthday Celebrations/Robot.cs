using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IRobot
    {
        public string Model { get; set; }
        public string Id { get; set; }
        public Robot(string mode, string id)
        {
            this.Model = Model;
            this.Id = id;
        }
    }
}
