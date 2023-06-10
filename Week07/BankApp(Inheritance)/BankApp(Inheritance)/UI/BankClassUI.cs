using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_Inheritance_.BL;
using BankApp_Inheritance_.DL;

namespace BankApp_Inheritance_.UI
{
    class BankClassUI
    {

        public static string loginMenu()
        {
            string choice;
            while (true)
            {
                Console.Clear();
                header();
                SubMenu("Login Menu");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press 1 to Login to Your Account: ");
                Console.WriteLine("Press 2 to create a Account: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Press 3 to Change User: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a Valid Option: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    press();
                }
            }

            return choice;
        }


        public static string mainMenu()
        {
            string choice;

            while (true)
            {
                Console.Clear();
                BankClassUI.header();
                BankClassUI.SubMenuForMainMenu("Main");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press 1 to Enter as an Manager: ");
                Console.WriteLine("Press 2 to Enter as a Client: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Press 3 to Close the Application: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();
                if (choice == "1" || choice == "3" || choice == "2")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Please Enter a Valid Option: ");
                    press();
                }
            }
            return choice;
        }

        public static void header()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            Console.WriteLine("<>                                                                                                            <>");
            Console.WriteLine("<>  oooooooooo.        .o.       ooooo      ooo oooo    oooo            .o.                                   <>");
            Console.WriteLine("<>  `888'   `Y8b      .888.      `888b.     `8' `888   .8P'            .888.                                  <>");
            Console.WriteLine("<>   888     888     .8'888.      8 `88b.    8   888  d8'             .8'888.     oo.ooooo.  oo.ooooo.        <>");
            Console.WriteLine("<>   888oooo888'    .8' `888.     8   `88b.  8   88888[              .8' `888.     888' `88b  888' `88b       <>");
            Console.WriteLine("<>   888    `88b   .88ooo8888.    8     `88b.8   888`88b.           .88ooo8888.    888   888  888   888       <>");
            Console.WriteLine("<>   888    .88P  .8'     `888.   8       `888   888  `88b.        .8'     `888.   888   888  888   888  .o.  <>");
            Console.WriteLine("<>  o888bood8P'  o88o     o8888o o8o        `8  o888o  o888o      o88o     o8888o  888bod8P'  888bod8P'  Y8P  <>");
            Console.WriteLine("<>                                                                                 888        888             <>");
            Console.WriteLine("<>                                                                                o888o      o888o            <>");
            Console.WriteLine("<>                                                                                                            <>");
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            Console.WriteLine("<><><>---<>---<>---<>---<>---<>---<>---<>--< BANK MANAGEMENT SYSTEM >--<>---<>---<>---<>---<>---<>---<>---<><><>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void SubMenuForMainMenu(string subMenu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = subMenu + "Menu";
            Console.WriteLine(message);
            Console.WriteLine("<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void SubMenu(string subMenu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = "Main Menu > " + subMenu;
            Console.WriteLine(message);
            Console.WriteLine("<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void userMenu(string subMenu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = "Main Menu > Login Menu > " + subMenu;
            Console.WriteLine(message);
            Console.WriteLine("<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>");
            Console.ForegroundColor = ConsoleColor.White;
        }



        public static void warning()
        {
            Console.Clear();
            header();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have entered Wrong info too many times: ");
            Console.WriteLine("now you will be sent to previous Manu: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Thank You for your cooperation");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void press()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        public static void programmEnds()
        {
            Console.Clear();
            header();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Thanks For Using this Application");
            Console.WriteLine("GoodBye! & Have a good day");
            press();
        }

        public static string signUpName(string head)
        {
            string name = "";
            bool check = false;
            while (check == false)
            {
                Console.Clear();
                header();
                SubMenu(head);
                Console.WriteLine("Enter Your name(alphabets only): ");
                name = Console.ReadLine();
                check = abcValidation(name);
            }
            return name;
        }
        public static string signUpPassword(string name, string head)
        {
            string pass = "";
            int length = 0;
            while (length < 8)
            {
                Console.Clear();
                header();
                SubMenu(head);
                Console.WriteLine("Enter Your name(alphabets only): " + name);
                Console.WriteLine("Enter Your Password (atleast 8 characters long): ");
                pass = Console.ReadLine();
                length = pass.Length;
                if (length < 8)
                {
                    Console.WriteLine("PLease Enter a strong Password(atleast 8 characters long): ");
                    press();
                }
            }
            return pass;
        }

        public static bool abcValidation(string name)
        {

            bool flag = false;
            int i = 0;
            while (i < name.Length)
            {
                if (name.Length < 3)
                {
                    Console.WriteLine("Please enter a name of atleast 3 characters");
                    press();
                    break;
                }
                if ((name[i] > 63 && name[i] < 91) || (name[i] > 96 && name[i] < 123) || name[i] == 32)
                {
                    i++;
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

    }
}
