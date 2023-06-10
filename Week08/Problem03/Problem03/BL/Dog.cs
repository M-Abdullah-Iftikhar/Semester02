using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03.BL 
{
    class Dog : Mammal
    {
        public Dog(string name) : base(name)
        {

        }

        public override string greets()
        {
            return "Woof";
        }
        public override string greets(Dog another)
        {
              return "Woooof";
        }

        public override string toString()
        {
            return "Dog[" + base.toString() + "]";
        }
    }
}
