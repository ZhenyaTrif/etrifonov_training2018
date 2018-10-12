using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_polymorphism
{
    abstract class Flower: IGetCost
    {
        public string Name { get; private set; }
        public string Color { get; private set; }

        public Flower(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public abstract double GetCost();
    }
}
