using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tests.DL;
using tests.BL;

namespace tests.UI
{
    public class ClassUI
    {

        public static void printUser()
        {
            for(int x = 0;x < ClassDL.bankClass.Count;x++)
            {
               ClassBL temp = ClassDL.takeUserFromList(x);
                Console.WriteLine(temp.name);
                Console.WriteLine(temp.pass);
            }

        }
        public static void addUsers()
        {
            Console.WriteLine("Enter a Number");
            int num = int.Parse(Console.ReadLine());

            for (int x = 0; x < num; x++)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Pass: ");
                string pass = Console.ReadLine();

                ClassBL user = new ClassBL(name, pass);

                ClassDL.addUserInList(user);
            }
        }
    }
}
