using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_polymorphism
{
    class Carnation: Flower, IGetCost
    {
        private double DefaultPrice { get; set; }
        private static string _name = "Carnation";

        public Carnation(double defaultPrice, string color = "red") : base(_name, color)
        {
            DefaultPrice = defaultPrice;            
        }

        public void ChangeDefaultPrice(int newPrice)
        {
            DefaultPrice = newPrice;
        }

        public override double GetCost()
        {
            if (Color != "red")
            {
                return DefaultPrice * 1.2;
            }
            else
            {
                return DefaultPrice;
            }            
        }
    }
}
