using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_polymorphism
{
    class Bouquet
    {
        private Flower[] Flowers { get; set; }
        public double Cost { get; private set; }

        public Bouquet(params Flower[] flowers)
        {
            Flowers = flowers;
            CalculateBouquetCost();
        }

        private void CalculateBouquetCost()
        {
            if (Flowers.Length == 0)
            {
                Cost = 0;
            }
            else
            {
                Cost = 0;
                for (int i = 0; i < Flowers.Length; i++)
                {
                    Cost += Flowers[i].GetCost();
                }
            }
        }
    }
}
