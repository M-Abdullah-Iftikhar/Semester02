using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.BL;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            MountainBike B = new MountainBike(123,12321, 2, 3);

            int c = B.getCadence();

            Console.WriteLine(c);

            MountainBike B1 = new MountainBike(111, 1111, 11, 11111);

            c = B1.getCadence();

            Console.WriteLine(c);

            B1.setCadence(121);

            c = B1.getCadence();

            Console.WriteLine(c);

            c = B.getCadence();

            Console.WriteLine(c);

            Console.ReadKey();
        
        }
    }
}
