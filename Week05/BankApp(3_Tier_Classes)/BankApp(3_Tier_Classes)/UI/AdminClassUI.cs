using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_3_Tier_Classes_.DL;
using BankApp_3_Tier_Classes_.BL;

namespace BankApp_3_Tier_Classes_.UI
{
    class AdminClassUI
    {
        public static bool adminBankCode()
        {
            string bankCode = "";
            bool check = false;

            for (int x = 0; check == false; x++)
            {

                Console.Clear();
                BankClassUI.header();
                BankClassUI.SubMenuForMainMenu("Main");
                Console.WriteLine("It is a manager Account: ");
                Console.WriteLine("Please Enter Bank Code: ");
                bankCode = Console.ReadLine();
                check = AdminClassDL.checkAdminBankCode(bankCode);
                if (x > 4)
                {
                    return false;
                }
            }

            return true;
        }


        public static bool login()
        {

            int check = -1;
            string name;
            string pass;

            for (int x = 0; x < 4; x++)
            {
                if (x > 2)
                {
                    BankClassUI.warning();
                    BankClassUI.press();
                    break;
                }
                Console.Clear();
                BankClassUI.header();
                BankClassUI.SubMenu("Login Menu");
                name = BankClassUI.signUpName("Login Menu");
                pass = BankClassUI.signUpPassword(name, "Login Menu");

                check = AdminClassDL.checkUser(name, pass);
                BankClassBL.CurrentUserIndex = check;

                if (check != -1)
                {
                    return true;
                }

                else if (check == -1)
                {
                    Console.WriteLine("you have entered wrong userName or password");
                    BankClassUI.press();
                }
            }

            return false;

        }

        public static void signUp()
        {

            Console.Clear();
            BankClassUI.header();
            BankClassUI.SubMenu("Login Menu");

            bool check = false;

            string name;
            string pass;




            name = BankClassUI.signUpName("Login Menu");
            pass = BankClassUI.signUpPassword(name, "Login Menu");


            check = AdminClassDL.checkAvailable(name, pass);

            if (check == true)
            {
                Console.WriteLine("User Already exists, try a different user name");
                BankClassUI.press();
            }
            else if (check == false)
            {

                AdminClassBL user = new AdminClassBL(name, pass);
                AdminClassDL.addAdminToList(user);


            }
        }
        public static string signUpbankCode(string name, string pass, string head)
        {
            bool check = false;
            string bankCode1 = "";
            while (check == false)
            {
                Console.Clear();
                BankClassUI.header();
                userAdminMenu(head);
                Console.WriteLine("Enter Your name(alphabets only): " + name);
                Console.WriteLine("Enter Your Password (atleast 8 characters long): " + pass);
                Console.WriteLine("Enter Bank Code(integers values only && atleast 8 characters long): ");
                bankCode1 = Console.ReadLine();
                check = intValidationsBankCode(bankCode1);
            }
            return bankCode1;
        }
        public static bool intValidationsBankCode(string code)
        {
            bool flag = false;
            int i = 0;
            while (i < code.Length)
            {
                if (code.Length < 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a Bank Code of atleast 8 characters");
                    Console.ForegroundColor = ConsoleColor.White;
                    BankClassUI.press();
                    break;
                }
                if (code[i] > 47 && code[i] < 58)
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

        public static void adminMenu()
        {
            bool logout = false;
            while (true)
            {
                Console.Clear();
                BankClassUI.header();
                BankClassUI.userMenu("Admin");

                string choice;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press 1 to view All Clients: ");
                Console.WriteLine("Press 2 to Remove an Exsiting Client: ");
                Console.WriteLine("Press 3 to View Requests: ");
                Console.WriteLine("Press 4 to Manage Complaints: ");
                Console.WriteLine("Press 5 to View Transaction History: ");
                Console.WriteLine("Press 6 to Check Due Loans: ");
                Console.WriteLine("Press 7 to Check Donations:");
                Console.WriteLine("Press 8 to Check Available Bank Balance:");
                Console.WriteLine("Press 9 to Search for a specific Client:");
                Console.WriteLine("Press 10 to Edit your account: ");
                Console.WriteLine("Press 11 to Check Reviews of Customers: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Press 12 to Logout: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();

                logout = adminMenuOptions(choice);

                if (logout == true)
                {
                    break;
                }
            }
        }
        public static bool adminMenuOptions(string choice)
        {
            bool logout = false;
            if (choice == "1")
            {
                clientName();
            }
            else if (choice == "2")
            {
                delAccount();
            }
            else if (choice == "3")
            {
                clientRequests();
            }
            else if (choice == "4")
            {
                clientComplaint();
            }
            else if (choice == "5")
            {
                transaction();
            }
            else if (choice == "6")
            {
                clientLoans();
            }
            else if (choice == "7")
            {
                clientDonations();
            }
            else if (choice == "8")
            {
                adminBalance();
            }
            else if (choice == "9")
            {
                clientDetails();
            }
            else if (choice == "10")
            {
                editAdmin();
            }
            else if (choice == "11")
            {
                checkReviews();
            }
            else if (choice == "12")
            {
                logout = true;
            }
            else
            {
                Console.WriteLine("Please Choose a valid Option");
                BankClassUI.press();
            }
            return logout;
        }
        public static void clientName()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Client Names");

            int size = ClientClassDL.giveClientNumber();

            for (int x = 0; x < size; x++)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(x);

                Console.WriteLine("\tName is: " + users.userName + "\tPassword is: " + users.password);
                Console.WriteLine();

            }
            BankClassUI.press();
        }
        public static void clientRequests()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Requests");
            int size = ClientClassDL.giveClientNumber();
            for (int x = 0; x < size; x++)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(x);

                Console.WriteLine("\t~~~~< Name is: " + users.userName + " >~~~~");
                Console.WriteLine("\t::Requests::");
                if (users.checkBook == true || users.newCard == true)
                {
                    if (users.checkBook == true)
                    {
                        Console.WriteLine("Check Book is Requested: ");
                    }
                    if (users.newCard == true)
                    {
                        Console.WriteLine("Credit Card is Requested ");
                    }
                }
                else if (users.checkBook == false && users.newCard == false)
                {
                    Console.WriteLine("No Request is present");
                }
                Console.WriteLine();

            }
            BankClassUI.press();
        }
        public static void clientComplaint()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Complaints");

            int size = ClientClassDL.giveClientNumber();
            for (int x = 0; x < size; x++)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(x);

                Console.WriteLine("\t~~~~< Name is: " + users.userName + " >~~~~");
                if (users.complaintCheck == true)
                {
                    Console.WriteLine("Complaint is: " + users.complaints);
                }
                else if (users.complaintCheck == false)
                {
                    Console.WriteLine("No complain is present");
                }
                Console.WriteLine();

            }
            BankClassUI.press();
        }
        public static void clientLoans()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Due Loans");
            int size = ClientClassDL.giveClientNumber();
            for (int x = 0; x < size; x++)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(x);

                Console.WriteLine("\t~~~~< Name is: " + users.userName + " >~~~~");
                Console.WriteLine("Bank Balance is: " + users.cash + "\tloan to pay is:" + users.loans);
                Console.WriteLine();

            }
            BankClassUI.press();
        }
        public static void transaction()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Transactions");
            int size = ClientClassDL.giveClientNumber();

            for (int x = 0; x < size; x++)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(x);

                Console.WriteLine("\t~~~~< Name is: " + users.userName + " >~~~~");
                Console.WriteLine("Total Transactions Made are: " + users.transactions);
                Console.WriteLine("Total Depositions made are: " + users.depositions);
                Console.WriteLine();

            }
            BankClassUI.press();
        }
        public static void clientDonations()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Donations");
            int size = ClientClassDL.giveClientNumber();

            for (int x = 0; x < size; x++)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(x);

                Console.WriteLine("\t~~~~< Name is: " + users.userName + " >~~~~");
                Console.WriteLine("Total Donation Given is: " + users.fundPayed);
                Console.WriteLine();

            }
            BankClassUI.press();
        }
        public static void adminBalance()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Bank Balance");
            Console.WriteLine("Current Bank Balance is: " + AdminClassDL.bankBalance);
            BankClassUI.press();
        }
        public static void clientDetails()
        {

            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Client's Details");
            string name, pass;


            Console.WriteLine("Enter name of user you want to search: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter password of the user you are searching: ");
            pass = Console.ReadLine();

            int check = ClientClassDL.checkUser(name, pass);

            ClientClassBL users = ClientClassDL.takeUserFromClientList(check);

            if (check != -1)
            {



                Console.WriteLine("\t~~~< Name is: " + users.userName + " >~~~\t~~~< Password is: " + users.password + " >~~~");
                Console.WriteLine("Bank Balance is: " + users.cash + "\tloan to pay is:" + users.loans + "\tDonation Payed is:" + users.fundPayed);

                Console.WriteLine("\tRequests/Complaints/Reviews");
                if (users.complaintCheck == true || users.checkBook == true || users.newCard == true || users.reviewCheck == true)
                {
                    if (users.checkBook == true)
                    {
                        Console.WriteLine("Check Book is Requested: ");
                    }
                    if (users.newCard == true)
                    {
                        Console.WriteLine("Credit Card is Requested ");
                    }
                    if (users.complaintCheck == true)
                    {
                        Console.WriteLine("Complaint is: " + users.complaints);
                    }
                    if (users.reviewCheck == true)
                    {
                        Console.WriteLine("Review is: " + users.clientReviews);
                    }
                }
                else if (users.complaintCheck == false && users.checkBook == false && users.newCard == false)
                {
                    Console.WriteLine("No Request or complaint is present");
                }


            }
            else if (check == -1)
            {
                Console.WriteLine("User not found");
            }
            BankClassUI.press();
        }
        public static void editAdmin()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Edit Account");
            AdminClassBL users = AdminClassDL.takeUserFromAdminList(BankClassBL.CurrentUserIndex);

            users.userName = BankClassUI.signUpName("Login Menu > Admin Menu > Edit Account");
            users.password = BankClassUI.signUpPassword(users.userName, "Login Menu > Admin Menu > Edit Account");
            AdminClassDL.bankCode = signUpbankCode(users.userName, users.password, "Login Menu > Admin Menu > Edit Account");



            Console.WriteLine("Your Account has been updated");
            Console.WriteLine("Thank You for using our Service");
            AdminClassDL.storeData();
            BankClassUI.press();
        }
        public static void checkReviews()
        {
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Reviews");


            int size = ClientClassDL.giveClientNumber();
            for (int x = 0; x < size; x++)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(x);

                Console.WriteLine("\t~~~~< Name is: " + users.userName + " >~~~~");

                if (users.reviewCheck == true)
                {
                    Console.WriteLine("Review is: " + users.clientReviews);
                }
                else if (users.reviewCheck == false)
                {
                    Console.WriteLine("No Review is present");
                }
                Console.WriteLine();

            }
            BankClassUI.press();
        }
        public static void delAccount()
        {
            string choice = delAccountMenu();

            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Remove Account");
            

            string name;
            string pass;

            name = BankClassUI.signUpName("Login Menu > Admin Menu > Remove Account");
            pass = BankClassUI.signUpPassword(name, "Login Menu > Admin Menu > Remove Account");

            int y = AdminClassDL.checkUser(name, pass);

            if (y == -1)
            {
                Console.WriteLine("User Not Found");
                BankClassUI.press();
            }
            else if (y != -1)
            {
                if (choice == "1")
                {
                    delAdmin(y);
                }
                else if (choice == "2")
                {
                    ClientClassUI.delClient(y);
                }

            }
        }

        public static string delAccountMenu()
            {
            

            string choice;
            
          
            while(true)
            {
                Console.Clear();
                BankClassUI.header();
                userAdminMenu("Remove Account");

                Console.WriteLine("1. To Remove an Admin Account");
                Console.WriteLine("2. To Remove a Client Account");
                Console.WriteLine("Enter Choice");
                choice = Console.ReadLine();

                if(choice == "1" || choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Choice");
                    BankClassUI.press();
                }

            }
            return choice;



        }
        
        public static void delAdmin(int index)
        {

            string choice = delAdminMenu();
            
            if (choice == "1")
            {

                bool check = adminBankCodeDel();
                if (check == true)
                {
                    AdminClassDL.delAdminAccount(index);
                    Console.WriteLine("The account has been removed successfully");
                    BankClassUI.press();
                }
                else if (check == false)
                {
                    BankClassUI.warning();
                    BankClassUI.press();
                }
            }
            else if (choice == "2")
            {
                BankClassUI.press();
            }
        }

        public static string delAdminMenu()
        {
            string choice;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("It is a Manager's account, are you sure you want to remove this account");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press 1 to Remove account: ");
                Console.WriteLine("Press 2 to Keep it: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your choice: ");
                choice = Console.ReadLine();

                if (choice == "1" || choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Choice");
                    BankClassUI.press();
                }
            }
            return choice;


        }

       
        public static bool adminBankCodeDel()
        {
            string bankCode1 = "";

            for (int x = 0; bankCode1 != AdminClassDL.bankCode; x++)
            {
                Console.Clear();
                BankClassUI.header();
                userAdminMenu("Remove Account");
                if (x > 4)
                {
                    return false;
                }
                Console.WriteLine("Please Enter Bank Code: ");
                bankCode1 = Console.ReadLine();
                if (bankCode1 != AdminClassDL.bankCode)
                {
                    Console.WriteLine("Incorrect Bank Code");
                    Console.WriteLine("Please Enter Correct BankCode");
                    BankClassUI.press();
                }
            }
            Console.Clear();
            BankClassUI.header();
            userAdminMenu("Remove Account");
            return true;
        }
        public static void userAdminMenu(string subMenu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = "Main Menu > Login Menu > Admin Menu > " + subMenu;
            Console.WriteLine(message);
            Console.WriteLine("<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>");
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
