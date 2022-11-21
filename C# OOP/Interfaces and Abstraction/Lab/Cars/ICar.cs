using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Model { get => this.Model; }
        public string Color { get => this.Color; }
        public string Start();
        public string Stop();
    }
}
