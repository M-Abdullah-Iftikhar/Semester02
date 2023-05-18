using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tests.DL;
using tests.BL;
using tests.UI;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassUI.addUsers();
            
            

            ClassUI.printUser();
            Console.ReadKey();

        }
    }
}
