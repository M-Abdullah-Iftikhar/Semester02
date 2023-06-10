using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem03.BL;

namespace Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat c1 = new Cat("SnowBell");
            Cat c2 = new Cat("GarlField");

            Dog d1 = new Dog("Scooby");
            Dog d2 = new Dog("Doggy");



            List<Animal> animal = new List<Animal>();

            animal.Add(c1);
            animal.Add(c2);
            animal.Add(d1);
            animal.Add(d2);

            foreach(Animal a in animal)
            {
                Console.WriteLine(a.toString());
                Console.WriteLine(a.greets());
            }    



            Console.ReadKey();
        }
    }
}
