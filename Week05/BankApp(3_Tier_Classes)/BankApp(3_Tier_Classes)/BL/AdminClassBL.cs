using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_3_Tier_Classes_.DL;
using BankApp_3_Tier_Classes_.UI;

namespace BankApp_3_Tier_Classes_.BL
{
   public  class AdminClassBL
    {
       public  AdminClassBL(string name, string pass)
        {
            this.userName = name;
            this.password = pass;
            
        }
        public string userName;
        public string password; 
        
        
    }
}
