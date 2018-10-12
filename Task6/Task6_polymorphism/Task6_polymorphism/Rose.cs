using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_polymorphism
{
    class Rose : Flower, IGetCost
    {
        private double DefaultPrice { get; set; }
        private static string _name = "Rose";
        
        private string Size { get; set; }

        public Rose(double defaultPrice, string flowerSize = "normal", string color = "red"): base(_name, color)
        {
            DefaultPrice = defaultPrice;
            Size = flowerSize;
        }

        public void ChangeDefaultPrice(int newPrice)
        {
            DefaultPrice = newPrice;
        }

        public override double GetCost()
        {
            double flowerCost = DefaultPrice;
            if(Color != "red")
            {
                flowerCost *= 1.1;
            }
            if(Size == "small")
            {
                flowerCost *= 0.9;
            }else if(Size == "large")
            {
                flowerCost *= 1.1;
            }
            return flowerCost;
        }
    }
}
