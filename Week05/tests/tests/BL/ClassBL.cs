using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tests.DL;
using tests.UI;

namespace tests.BL
{
    public class ClassBL
    {
       public ClassBL(string name,string pass)
        {
            this.name = name;
            this.pass = pass;
            

        }
        public string name;
        public string pass;
        public static string id;


    }
}
