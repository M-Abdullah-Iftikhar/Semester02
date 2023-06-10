using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02.BL
{
    class Person
    {
        protected string name;
        protected string address;


        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public string getName()
        {
            return name;
        }
        
        public void setName(string name)
        {
            this.name = name;
        }
        
        public string getAddress()
        {
            return address;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }

        public virtual string toString()
        {
            return "name: " + address + "Address: " + address;
        }

    }
}
