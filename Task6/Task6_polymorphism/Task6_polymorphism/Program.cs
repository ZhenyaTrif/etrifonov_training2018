using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Flower f1 = new Rose(3.5);
            Flower f2 = new Tulip(2.0, "yelow");
            Flower f3 = new Carnation(3.0);
            Flower f4 = new Pion(4.0, "opened", "white");

            Bouquet bouquet = new Bouquet(f1, f2, f3, f4);
            Console.WriteLine("Bouquet cost = " + bouquet.Cost);
        }
    }
}
