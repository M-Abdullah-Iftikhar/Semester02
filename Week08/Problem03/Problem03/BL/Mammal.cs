using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03.BL 
{
    class Mammal : Animal
    {
        public Mammal(string name) : base (name)
        {
      
        }

        public override string greets()
        {
            return "Undefined";
        }

        public override string greets(Dog d)
        {
            return "Undefined";
        }
        public override string toString()
        {
            return "Mammal[" +  base.toString() +"]";
        }
        
    }
}
