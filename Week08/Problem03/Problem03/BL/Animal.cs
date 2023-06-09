﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03.BL
{
    class Animal
    {
        protected string name;

        public Animal(string name)
        {
            this.name = name;
        }

        public virtual string greets()
        {
            return "Undefined";
        }

        public virtual string greets(Dog d)
        {
            return "Undefined";
        }

        public virtual string toString()
        {
            return "Animal[name= " + name + "]";
        }
    }
}
