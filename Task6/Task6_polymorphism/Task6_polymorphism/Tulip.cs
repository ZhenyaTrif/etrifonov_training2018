using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_polymorphism
{
    class Tulip : Flower, IGetCost
    {
        private double DefaultPrice { get; set; }
        private static string _name = "Tulip";

        public Tulip(double defaultPrice, string flowerColor = "red") : base(_name, flowerColor)
        {
            DefaultPrice = defaultPrice;
        }

        public void ChangeDefaultPrice(int newPrice)
        {
            DefaultPrice = newPrice;
        }

        public override double GetCost()
        {
            if(Color != "red")
            {
                return DefaultPrice * 1.1;
            }
            else
            {
                return DefaultPrice;
            }
        }
    }
}
