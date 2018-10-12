using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_polymorphism
{
    class Pion : Flower, IGetCost
    {
        private double DefaultPrice { get; set; }
        private static string _name = "Pion";
        private string OpeningStage { get; set; }

        public Pion(double defaultPrice, string stage = "closed", string color = "red") : base(_name, color)
        {
            DefaultPrice = defaultPrice;
        }

        public void ChangeDefaultPrice(int newPrice)
        {
            DefaultPrice = newPrice;
        }

        public override double GetCost()
        {
            double flowerCost = DefaultPrice;
            if (Color != "red")
            {
                flowerCost *= 1.1;
            }
            if(OpeningStage != "closed")
            {
                flowerCost *= 1.1;
            }
            return flowerCost;
        }
    }
}
