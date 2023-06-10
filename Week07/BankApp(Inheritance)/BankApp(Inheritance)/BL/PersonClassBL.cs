using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp_Inheritance_.BL
{
    class PersonClassBL
    {
        public PersonClassBL(string userName,string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public PersonClassBL()
        {

        }

        protected string userName;
        protected string password;
        public string getName()
        {
            return userName;
        }
        public void setName(string name)
        {
            this.userName = name;
        }

        public string getPassword()
        {
            return password;
        }
        public void setPassword(string pass)
        {
            this.password = pass;
        }


    }
}
