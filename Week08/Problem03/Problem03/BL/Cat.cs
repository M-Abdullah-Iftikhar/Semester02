using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03.BL
{
    class Cat : Mammal
    {
        public Cat(string name):base(name)
        {

        }

        public override  string greets()
        {
            return "Meow";
        }

        public override string toString()
        {
            return "Cat" + base.toString() + "]";
        }
    }
}
