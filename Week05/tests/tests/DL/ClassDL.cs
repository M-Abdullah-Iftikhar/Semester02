
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tests.BL;
using tests.UI;

namespace tests.DL
{
   public static class ClassDL
    {
        public static List<ClassBL> bankClass = new List<ClassBL>();

        public static void addUserInList(ClassBL user)
        {
            
                bankClass.Add(user);
            
        }

        public static ClassBL takeUserFromList(int x)
        {
            return bankClass[x];
        }
    }

   
}
