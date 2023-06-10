using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyMorphism.BL;

namespace PolyMorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Cylinder c1 = new Cylinder();
            Cylinder c2 = new Cylinder(3.0F);
            Cylinder c3 = new Cylinder(4.0F,2.0F);

            double area = c1.getVolume();
            Console.WriteLine(area);

            double area2 = c2.getVolume();
            Console.WriteLine(area2);

            double area3 = c3.getVolume();
            Console.WriteLine(area3);

            c1.setHeight(4.0);

            double area4 = c1.getArea();

            Console.ReadKey();

        }
    }
}
