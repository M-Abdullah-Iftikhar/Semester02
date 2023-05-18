using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week03_BankApp_Behaviours_.BL;
using System.IO;

namespace week03_BankApp_Behaviours_
{
    class Program
    {
        //
        //
        //////////////////////////////////////////
        //              Variables               //
        //////////////////////////////////////////
        //
        //
        /////////////////////////////////////
        //
        //
        //
        //
        //////////////////////////////////////////////

        static void Main(string[] args)
        {
            List<bankClass> users = new List<bankClass>();
            bankClass bankInfo = new bankClass();




            loadData(users, bankInfo);

            bankInfo.checkAdmin = false;
            bankInfo.loginCheck = false;
            bool logout = false;


            while (true)
            {
                string choice;
                logout = false;
                Console.Clear();
                header();
                SubMenuForMainMenu("Main");

                choice = mainMenu();

                if (choice == "1")
                {
                    bool check = adminBankCode(users, bankInfo);

                    if (check == false)
                    {
                        warning();
                        press();
                        continue;
                    }
                    else if (check == true)
                    {
                        bankInfo.checkAdmin = true;
                    }
                }
                else if (choice == "2")
                {
                    bankInfo.checkAdmin = false;
                }
                else if (choice == "3")
                {
                    storeData(users);
                    programmEnds();
                    break;
                }
                while (true)
                {
                    bankInfo.loginCheck = false;
                    logout = false;
                    int checkUser1 = -2;
                    string loginMenuCheck = loginMenu();

                    while (true)
                    {
                        bankInfo.loginCheck = false;
                        logout = false;
                        if (loginMenuCheck == "1")
                        {
                            checkUser1 = login(users, bankInfo);

                            if (checkUser1 == 3)
                            {
                                break;
                            }
                            bankInfo.loginCheck = true;
                        }
                        else if (loginMenuCheck == "2")
                        {
                            signUp(users, bankInfo);
                            bankInfo.loginCheck = false;
                            checkUser1 = -1;
                            break;
                        }
                        else if (loginMenuCheck == "3")
                        {
                            logout = true;
                            bankInfo.loginCheck = false;
                            break;
                        }
                        if (bankInfo.loginCheck == true)
                        {

                            if (checkUser1 == 1)
                            {
                                bankInfo.checkUser2 = confirmRole(users, bankInfo);
                                if (bankInfo.checkUser2 == true)
                                {
                                    adminMenu(users, bankInfo);
                                    bankInfo.loginCheck = false;
                                    break;
                                }
                                else if (bankInfo.checkUser2 == false)
                                {
                                    Console.WriteLine("This is a Clients's User Name, You Cannot Access a Clients Account from Admin Menu: ");
                                    press();
                                    break;
                                }
                            }
                            else if (checkUser1 == 2)
                            {
                                bankInfo.checkUser2 = confirmRole(users, bankInfo);
                                if (bankInfo.checkUser2 == false)
                                {
                                    clientMenu(users, bankInfo);
                                    bankInfo.loginCheck = false;
                                    break;
                                }
                                else if (bankInfo.checkUser2 == true)
                                {
                                    Console.WriteLine("This is a Manager's User Name, You Cannot Access Manager's Account from Client Menu: ");
                                    press();
                                    break;
                                }
                            }
                        }
                    }
                    if (logout == true)
                    {
                        break;
                    }
                }
            }

        }
        //
        //////////////////////////////////////////////
        //////////////////////////////////////////////
        //
        //
        //
        //
        ///////////////////////////////////////
        //        MainMenu Functions         //
        ///////////////////////////////////////
        //
        //
        public static string mainMenu()
        {
            string choice;

            while (true)
            {
                Console.Clear();
                header();
                SubMenuForMainMenu("Main");
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
        public static int login(List<bankClass> users, bankClass bankInfo)
        {

            int check = -1;
            string name;
            string pass;

            for (int x = 0; x < 4; x++)
            {
                if (x > 2)
                {
                    warning();
                    press();
                    break;
                }
                Console.Clear();
                header();
                SubMenu("Login Menu");
                name = signUpName("Login Menu");
                pass = signUpPassword(name, "Login Menu");

                check = checkUser(name, pass, users);
                bankInfo.CurrentUserIndex = check;

                if (check != -1 && bankInfo.checkAdmin == true)
                {
                    return 1;
                }
                else if (check != -1 && bankInfo.checkAdmin == false)
                {
                    return 2;
                }
                else if (check == -1)
                {
                    Console.WriteLine("you have entered wrong userName or password");
                    press();
                }
            }

            return 3;

        }
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
        public static void signUp(List<bankClass> users, bankClass bankInfo)
        {

            Console.Clear();
            header();
            SubMenu("Login Menu");
            
            bool check = false;

            string name;
            string pass;
            string creditCard = "";
            


            name = signUpName("Login Menu");
            pass = signUpPassword(name, "Login Menu");
            if (bankInfo.checkAdmin == false)
            {
                creditCard = signUpCreditCardNo(name, pass, "Login Menu");
            }

            check = checkAvailable(name, pass, users);

            if (check == true)
            {
                Console.WriteLine("User Already exists, try a different user name");
                press();
            }
            else if (check == false)
            {
                bankClass temp = new bankClass();
                temp.userName = name;
                temp.password = pass;
                temp.loans = 0;
                if (bankInfo.checkAdmin == true)
                {
                    temp.creditCardNo = bankInfo.bankCode;
                    temp.isAdmin = true;
                    temp.cash = bankInfo.bankBalance;
                }
                else if (bankInfo.checkAdmin == false)
                {
                    temp.creditCardNo = creditCard;
                    temp.isAdmin = false;
                    temp.cash = 0;
                }
                users.Add(temp);

                storeData(users);
            }
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
        public static string signUpCreditCardNo(string name, string pass, string head)
        {
            bool check = false;
            string creditCard = "";
            while (check == false)
            {
                Console.Clear();
                header();
                SubMenu(head);
                Console.WriteLine("Enter Your name(alphabets only): " + name);
                Console.WriteLine("Enter Your Password (atleast 8 characters long): " + pass);
                Console.WriteLine("Enter Credit Card Number(integer values Only & 16 characters long): ");
                creditCard = Console.ReadLine();
                check = intValidationsCreditCard(creditCard);
            }
            return creditCard;
        }
        public static string signUpbankCode(string name, string pass, string head)
        {
            bool check = false;
            string bankCode1 = "";
            while (check == false)
            {
                Console.Clear();
                header();
                userAdminMenu(head);
                Console.WriteLine("Enter Your name(alphabets only): " + name);
                Console.WriteLine("Enter Your Password (atleast 8 characters long): " + pass);
                Console.WriteLine("Enter Bank Code(integers values only && atleast 8 characters long): ");
                bankCode1 = Console.ReadLine();
                check = intValidationsBankCode(bankCode1);
            }
            return bankCode1;
        }
        //
        //
        ////////////////////////////////////////
        //          AdminFunctions            //
        ////////////////////////////////////////
        //
        //
        public static bool adminBankCode(List<bankClass> users, bankClass bankInfo)
        {
            string bankCode1 = "";

            for (int x = 0; bankCode1 != bankInfo.bankCode; x++)
            {

                Console.Clear();
                header();
                SubMenuForMainMenu("Main");
                Console.WriteLine("It is a manager Account: ");
                Console.WriteLine("Please Enter Bank Code: ");
                bankCode1 = Console.ReadLine();
                if (x > 4)
                {
                    return false;
                }
            }

            return true;
        }
        public static void adminMenu(List<bankClass> users, bankClass bankInfo)
        {
            bool logout = false;
            while (true)
            {
                Console.Clear();
                header();
                userMenu("Admin");

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

                logout = adminMenuOptions(choice, users, bankInfo);

                if (logout == true)
                {
                    break;
                }
            }
        }
        public static bool adminMenuOptions(string choice, List<bankClass> users, bankClass bankInfo)
        {
            bool logout = false;
            if (choice == "1")
            {
                clientName(users);
            }
            else if (choice == "2")
            {
                delAccount(true, users, bankInfo);
            }
            else if (choice == "3")
            {
                clientRequests(users);
            }
            else if (choice == "4")
            {
                clientComplaint(users);
            }
            else if (choice == "5")
            {
                transaction(users);
            }
            else if (choice == "6")
            {
                clientLoans(users);
            }
            else if (choice == "7")
            {
                clientDonations(users);
            }
            else if (choice == "8")
            {
                adminBalance(users, bankInfo);
            }
            else if (choice == "9")
            {
                clientDetails(users);
            }
            else if (choice == "10")
            {
                editAdmin(users, bankInfo);
            }
            else if (choice == "11")
            {
                checkReviews(users);
            }
            else if (choice == "12")
            {
                logout = true;
            }
            else
            {
                Console.WriteLine("Please Choose a valid Option");
                press();
            }
            return logout;
        }
        public static void clientName(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Client Names");

            for (int x = 0; x < users.Count; x++)
            {
                if (users[x].isAdmin == false)
                {
                    Console.WriteLine("\tName is: " + users[x].userName + "\tPassword is: " + users[x].password);
                    Console.WriteLine();
                }
            }
            press();
        }
        public static void clientRequests(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Requests");
            for (int x = 0; x < users.Count; x++)
            {
                if (users[x].isAdmin == false)
                {
                    Console.WriteLine("\t~~~~< Name is: " + users[x].userName + " >~~~~");
                    Console.WriteLine("\t::Requests::");
                    if (users[x].checkBook == true || users[x].newCard == true)
                    {
                        if (users[x].checkBook == true)
                        {
                            Console.WriteLine("Check Book is Requested: ");
                        }
                        if (users[x].newCard == true)
                        {
                            Console.WriteLine("Credit Card is Requested ");
                        }
                    }
                    else if (users[x].checkBook == false && users[x].newCard == false)
                    {
                        Console.WriteLine("No Request is present");
                    }
                    Console.WriteLine();
                }
            }
            press();
        }
        public static void clientComplaint(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Complaints");
            for (int x = 0; x < users.Count; x++)
            {
                if (users[x].isAdmin == false)
                {

                    Console.WriteLine("\t~~~~< Name is: " + users[x].userName + " >~~~~");
                    if (users[x].complaintCheck == true)
                    {
                        Console.WriteLine("Complaint is: " + users[x].complaints);
                    }
                    else if (users[x].complaintCheck == false)
                    {
                        Console.WriteLine("No complain is present");
                    }
                    Console.WriteLine();
                }
            }
            press();
        }
        public static void clientLoans(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Due Loans");
            for (int x = 0; x < users.Count; x++)
            {
                if (users[x].isAdmin == false)
                {
                    Console.WriteLine("\t~~~~< Name is: " + users[x].userName + " >~~~~");
                    Console.WriteLine("Bank Balance is: " + users[x].cash + "\tloan to pay is:" + users[x].loans);
                    Console.WriteLine();
                }
            }
            press();
        }
        public static void transaction(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Transactions");
            for (int x = 0; x < users.Count; x++)
            {
                if (users[x].isAdmin == false)
                {
                    Console.WriteLine("\t~~~~< Name is: " + users[x].userName + " >~~~~");
                    Console.WriteLine("Total Transactions Made are: " + users[x].transactions);
                    Console.WriteLine("Total Depositions made are: " + users[x].depositions);
                    Console.WriteLine();
                }
            }
            press();
        }
        public static void clientDonations(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Donations");
            for (int x = 0; x < users.Count; x++)
            {
                if (users[x].isAdmin == false)
                {
                    Console.WriteLine("\t~~~~< Name is: " + users[x].userName + " >~~~~");
                    Console.WriteLine("Total Donation Given is: " + users[x].fundPayed);
                    Console.WriteLine();
                }
            }
            press();
        }
        public static void adminBalance(List<bankClass> users, bankClass bankInfo)
        {
            Console.Clear();
            header();
            userAdminMenu("Bank Balance");
            Console.WriteLine("Current Bank Balance is: " + users[bankInfo.CurrentUserIndex].cash);
            press();
        }
        public static void clientDetails(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Client's Details");
            string name, pass;


            Console.WriteLine("Enter name of user you want to search: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter password of the user you are searching: ");
            pass = Console.ReadLine();

            int check = checkUser(name, pass, users);

            if (check != -1)
            {
                if (users[check].isAdmin == false)
                {
                    Console.WriteLine("\t~~~< Name is: " + users[check].userName + " >~~~\t~~~< Password is: " + users[check].password + " >~~~");
                    Console.WriteLine("Bank Balance is: " + users[check].cash + "\tloan to pay is:" + users[check].loans + "\tDonation Payed is:" + users[check].fundPayed);

                    Console.WriteLine("\tRequests/Complaints/Reviews");
                    if (users[check].complaintCheck == true || users[check].checkBook == true || users[check].newCard == true || users[check].reviewCheck == true)
                    {
                        if (users[check].checkBook == true)
                        {
                            Console.WriteLine("Check Book is Requested: ");
                        }
                        if (users[check].newCard == true)
                        {
                            Console.WriteLine("Credit Card is Requested ");
                        }
                        if (users[check].complaintCheck == true)
                        {
                            Console.WriteLine("Complaint is: " + users[check].complaints);
                        }
                        if (users[check].reviewCheck == true)
                        {
                            Console.WriteLine("Review is: " + users[check].clientReviews);
                        }
                    }
                    else if (users[check].complaintCheck == false && users[check].checkBook == false && users[check].newCard == false)
                    {
                        Console.WriteLine("No Request or complaint is present");
                    }
                }
                else if (users[check].isAdmin == true)
                {
                    Console.WriteLine("Sorry! You Cant view another Managers Account");
                }
            }
            else if (check == -1)
            {
                Console.WriteLine("User not found");
            }
            press();
        }
        public static void editAdmin(List<bankClass> users, bankClass bankInfo)
        {
            Console.Clear();
            header();
            userAdminMenu("Edit Account");

            users[bankInfo.CurrentUserIndex].userName = signUpName("Login Menu > Admin Menu > Edit Account");
            users[bankInfo.CurrentUserIndex].password = signUpPassword(users[bankInfo.CurrentUserIndex].userName, "Login Menu > Admin Menu > Edit Account");
            bankInfo.bankCode = signUpbankCode(users[bankInfo.CurrentUserIndex].userName, users[bankInfo.CurrentUserIndex].password, "Login Menu > Admin Menu > Edit Account");

            users[bankInfo.CurrentUserIndex].creditCardNo = bankInfo.bankCode;

            Console.WriteLine("Your Account has been updated");
            Console.WriteLine("Thank You for using our Service");
            storeData(users);
            press();
        }
        public static void checkReviews(List<bankClass> users)
        {
            Console.Clear();
            header();
            userAdminMenu("Reviews");
            for (int x = 0; x < users.Count; x++)
            {
                if (users[x].isAdmin == false)
                {
                    Console.WriteLine("\t~~~~< Name is: " + users[x].userName + " >~~~~");

                    if (users[x].reviewCheck == true)
                    {
                        Console.WriteLine("Review is: " + users[x].clientReviews);
                    }
                    else if (users[x].reviewCheck == false)
                    {
                        Console.WriteLine("No Review is present");
                    }
                    Console.WriteLine();
                }
            }
            press();
        }
        public static void delAccount(bool checkAdmin, List<bankClass> users, bankClass bankInfo)
        {

            Console.Clear();
            header();
            userAdminMenu("Remove Account");

            string name;
            string pass;

            name = signUpName("Login Menu > Admin Menu > Remove Account");
            pass = signUpPassword(name, "Login Menu > Admin Menu > Remove Account");

            int y = checkUser(name, pass, users);

            if (y == -1)
            {
                Console.WriteLine("User Not Found");
                press();
            }
            else if (y != -1)
            {
                if (users[y].isAdmin == false)
                {
                    delClient(y, users);
                }

                else if (users[y].isAdmin == true)
                {
                    delAdmin(y, users, bankInfo);
                }
            }
        }
        public static void delClient(int index, List<bankClass> users)
        {
            users.RemoveAt(index);
            storeData(users);
            Console.WriteLine("The account has been removed successfully");
            press();
        }
        public static void delAdmin(int index, List<bankClass> users, bankClass bankInfo)
        {
            
            int choice;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It is a Manager's account, are you sure you want to remove this account");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press 1 to Remove account: ");
            Console.WriteLine("Press 2 to Keep it: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {

                bool check = adminBankCodeDel(bankInfo.bankCode);
                if (check == true)
                {
                    users.RemoveAt(index);
                    storeData(users);
                    Console.WriteLine("The account has been removed successfully");
                    press();
                }
                else if (check == false)
                {
                    warning();
                    press();
                }
            }
            else if (choice == 2)
            {
                press();
            }
        }
        public static bool adminBankCodeDel(string bankCode)
        {
            string bankCode1 = "";

            for (int x = 0; bankCode1 != bankCode; x++)
            {
                Console.Clear();
                header();
                userAdminMenu("Remove Account");
                if (x > 4)
                {
                    return false;
                }
                Console.WriteLine("Please Enter Bank Code: ");
                bankCode1 = Console.ReadLine();
                if (bankCode1 != bankCode)
                {
                    Console.WriteLine("Incorrect Bank Code");
                    Console.WriteLine("Please Enter Correct BankCode");
                    press();
                }
            }
            Console.Clear();
            header();
            userAdminMenu("Remove Account");
            return true;
        }
        //
        //
        ///////////////////////////////////////
        //         client Functions          //
        ///////////////////////////////////////
        //
        //
         public static void clientMenu(List<bankClass> users, bankClass bankInfo)
         {

             int logout = 0;

             while (true)
             {
                 Console.Clear();
                 header();
                 userMenu("Client");
                 string choice;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine( "Press 1 to Check Your Balance: " );
                 Console.WriteLine( "Press 2 to Withdraw Cash: " );
                 Console.WriteLine( "Press 3 to Deposit Cash: " );
                 Console.WriteLine( "Press 4 to Request For a Loan: " );
                 Console.WriteLine( "Press 5 to Pay Loan: " );
                 Console.WriteLine( "Press 6 to Send Cash to Another User: " );
                 Console.WriteLine( "Press 7 to Pay Bills:" );
                 Console.WriteLine( "Press 8 to File a Complaint:" );
                 Console.WriteLine( "Press 9 to Edit Your Account:" );
                 Console.WriteLine( "Press 10 to pay for Funds: " );
                 Console.WriteLine( "Press 11 to Enter Other Services: " );
                 Console.WriteLine( "Press 12 to Give Your Reviews: " );
                 Console.ForegroundColor = ConsoleColor.DarkRed;
                 Console.WriteLine( "Press 13 to delete your account: " );
                 Console.WriteLine( "Press 14 to Logout: " );
                 Console.ForegroundColor = ConsoleColor.Blue;
                 Console.WriteLine( "Enter Your Choice: ");
                 Console.ForegroundColor = ConsoleColor.White;
                 choice = Console.ReadLine();

                 logout = clientMenuOptions(choice, users, bankInfo);

                 if (logout == 1)
                 {
                     if (users[bankInfo.CurrentUserIndex].reviewCheck == false)
                     {
                         clientReviewsOptions(users, bankInfo);
                     }
                     break;
                 }
                 else if(logout == 2)
                {
                    break;
                }
             }
         }
         public static int clientMenuOptions(string choice,List<bankClass> users, bankClass bankInfo)
         {
             int logout = 0;

             if (choice == "1")
             {
                 checkBalance(users, bankInfo);
             }
             else if (choice == "2")
             {
                 cashWithdraw(users, bankInfo);
             }
             else if (choice == "3")
             {
                 cashDeposit(users, bankInfo);
             }
             else if (choice == "4")
             {
                 loanRequest(users, bankInfo);
             }
             else if (choice == "5")
             {
                 loanPay(users, bankInfo);
             }
             else if (choice == "6")
             {
                 sendCash(users, bankInfo);
             }
             else if (choice == "7")
             {
                 payBills(users, bankInfo);
             }
             else if (choice == "8")
             {
                 complaint(users, bankInfo);
             }
             else if (choice == "9")
             {
                 editAccount(users, bankInfo);
             }
             else if (choice == "10")
             {
                 clientFunds(users, bankInfo);
             }
             else if (choice == "11")
             {
                 otherServices(users, bankInfo);
             }
             else if (choice == "12")
             {
                 clientReviewsOptions(users, bankInfo);
             }
             else if (choice == "13")
             {
                 bool check = deleteMyAccount(users,bankInfo);
                 if (check == true)
                 {
                     logout = 2;
                 }
             }
             else if (choice == "14")
             {
                 logout = 1;
             }
             else
             {
                 Console.WriteLine( "Please Choose a valid Option" );
                 press();
             }
             return logout;
         }
         public static void checkBalance(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Balance");

             Console.WriteLine( "Your Current Balance is: " + users[bankInfo.CurrentUserIndex].cash );
             Console.WriteLine( "Your Current Loan to Pay is: " + users[bankInfo.CurrentUserIndex].loans);
             press();
         }
         public static void cashWithdraw(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Withdraw Cash");
             {

                 int withdraw;
                 Console.WriteLine( "Enter cash to be Withdrawn: ");
                 withdraw = int.Parse(Console.ReadLine());

                 if (withdraw <= users[bankInfo.CurrentUserIndex].cash)
                 {
                     users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash - withdraw;
                     Console.WriteLine( "You Have withdrawn: " + withdraw + " Rs" );
                     Console.WriteLine( "Your Remaining Balance is: " + users[bankInfo.CurrentUserIndex].cash);
                     bankInfo.bankBalance = bankInfo.bankBalance - withdraw;
                     users[bankInfo.CurrentUserIndex].transactions = users[bankInfo.CurrentUserIndex].transactions + withdraw;
                     storeData(users);
                     press();
                 }
                 else if (withdraw > users[bankInfo.CurrentUserIndex].cash)
                 {
                     Console.WriteLine( "Sorry! Your Account doesnt have Enough Balance: " );
                     press();
                 }
             }
         }
         public static void cashDeposit(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Deposite cash");
             string creditCard;

             
             int deposit;
             Console.WriteLine( "Enter Cash to Deposit: ");
             deposit = int.Parse(Console.ReadLine());
             Console.WriteLine( "Enter creditCard Number: ");
             creditCard = Console.ReadLine();

             if (creditCard == users[bankInfo.CurrentUserIndex].creditCardNo)
             {
                 bankInfo.bankBalance = bankInfo.bankBalance + deposit;
                 users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash + deposit;
                 users[bankInfo.CurrentUserIndex].depositions = users[bankInfo.CurrentUserIndex].depositions + deposit;
                 Console.WriteLine( deposit + " Rs. has been deposited in your account: " );
                 storeData(users);
                 press();
             }
             else
             {
                 Console.WriteLine( "Your Credit Card Number is Wrong: " );
                 press();
             }
         }
         public static void loanRequest(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Request Loans");
             int loan;
             int year;
             int month;
             int date;
             int sum;

             int currentDate;
             int currentMonth;
             int currentYear;

             Console.WriteLine( "Enter Amount of Loan You want: " );
             loan = int.Parse(Console.ReadLine());

             Console.WriteLine( "Enter Current year(202*): ");
             currentYear = int.Parse(Console.ReadLine());
             Console.WriteLine( "Enter Current month(1-12): ");
             currentMonth = int.Parse(Console.ReadLine());
             Console.WriteLine( "Enter Current date of the month(1-30): ");
             currentDate = int.Parse(Console.ReadLine());

             Console.WriteLine();
             Console.WriteLine( "Enter year in which you can repay(202*): ");
             year = int.Parse(Console.ReadLine());
             Console.WriteLine( "Enter month in which You can repay the loan(1-12): ");
             month = int.Parse(Console.ReadLine());
             Console.WriteLine( "Enter date of the month you can repay the loan(1-30): ");
             date = int.Parse(Console.ReadLine());

             sum = ((year - currentYear) * 365) + ((month - currentMonth) * 30) + (date - currentDate);

             if (users[bankInfo.CurrentUserIndex].loans > 0)
             {
                 Console.WriteLine( "Sorry! We Cannot Provide you more loan Because You Already have a loan to pay: " );
                 press();
             }
             else if (users[bankInfo.CurrentUserIndex].loans == 0)
             {

                 if (loan >= 1000000)
                 {
                     if (sum <= 360)
                     {
                         Console.WriteLine( "You Have been Given the loan: " );
                         Console.WriteLine( "ThankYou for Using this App: " );
                         users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash + loan;
                         users[bankInfo.CurrentUserIndex].loans = loan;
                         bankInfo.bankBalance = bankInfo.bankBalance - loan;
                         press();
                     }
                     else if (sum > 360)
                     {
                         Console.WriteLine( "Sorry! We Can't Provide you " + loan + " Rs for more than a Year" );
                         press();
                     }
                 }
                 else if (loan >= 100000 && loan < 1000000)
                 {
                     if (sum <= 180)
                     {
                         Console.WriteLine( "You Have been Given the loan: " );
                         Console.WriteLine( "ThankYou for Using this App: " );
                         users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash + loan;
                         users[bankInfo.CurrentUserIndex].loans = loan;
                         bankInfo.bankBalance = bankInfo.bankBalance - loan;
                         storeData(users);
                         press();
                     }
                     else if (sum > 180)
                     {
                         Console.WriteLine( "Sorry! We Can't Provide you " + loan + " Rs for more than 6 Months" );
                         press();
                     }
                 }
                 else if (loan < 100000)
                 {
                     if (sum <= 90)
                     {
                         Console.WriteLine( "You Have been Given the loan: " );
                         Console.WriteLine( "ThankYou for Using this App: " );
                         users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash + loan;
                         users[bankInfo.CurrentUserIndex].loans = loan;
                         bankInfo.bankBalance = bankInfo.bankBalance - loan;
                         storeData(users);
                         press();
                     }
                     else if (sum > 90)
                     {
                         Console.WriteLine( "Sorry! We Can't Provide you " + loan + " Rs for more than 3 Months" );
                         press();
                     }
                 }
             }
         }
         public static void loanPay(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Pay Loans");
             string creditCard;
             int payLoan;

             if (users[bankInfo.CurrentUserIndex].loans == 0)
             {
                 Console.WriteLine( "You Dont have any loans to pay: " );
                 press();
             }

             else if (users[bankInfo.CurrentUserIndex].loans > 0)
             {
                 Console.WriteLine( "You Have " + users[bankInfo.CurrentUserIndex].loans + " Rs to Pay" );
                 Console.WriteLine( "Enter Price You Want to pay: ");
                 payLoan = int.Parse(Console.ReadLine());
                 Console.WriteLine( "Enter creditCard Number: ");
                 creditCard = Console.ReadLine();

                 if (creditCard == users[bankInfo.CurrentUserIndex].creditCardNo && users[bankInfo.CurrentUserIndex].cash > payLoan)
                 {

                     if (payLoan >= users[bankInfo.CurrentUserIndex].loans)
                     {
                         bankInfo.bankBalance = bankInfo.bankBalance + payLoan;
                         payLoan = payLoan - users[bankInfo.CurrentUserIndex].loans;
                         users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash + payLoan;
                         users[bankInfo.CurrentUserIndex].loans = 0;
                         Console.WriteLine( "You have Paid more than you Were owed, Your dept has been payed" );
                         Console.WriteLine( "Remaining Money i.e. " + payLoan + " Rs. has been Deposited to your Account " );

                         press();
                     }
                     else if (payLoan < users[bankInfo.CurrentUserIndex].loans)
                     {
                         bankInfo.bankBalance = bankInfo.bankBalance + payLoan;
                         users[bankInfo.CurrentUserIndex].loans = users[bankInfo.CurrentUserIndex].loans - payLoan;
                         users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash - payLoan;
                         Console.WriteLine( "Now you are Owed " + users[bankInfo.CurrentUserIndex].loans + " Rs. More" );
                         press();
                     }
                 }
             }
         }
         public static void sendCash(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Send Cash");
             int sendMoney;
             int reciever;
             string name;
             string pass;
             Console.WriteLine( "Enter Name of User You want to send cash to: ");
             name = Console.ReadLine();
             Console.WriteLine( "Enter password of the user you want to send cash to: ");
             pass = Console.ReadLine();

             reciever = checkUser(name, pass,users);
             if (reciever == -1)
             {
                 Console.WriteLine( "This User isn't signed up in this Bank:" );
                 Console.WriteLine( "Please Enter a valid User:" );
                 press();
             }
             else if (reciever != -1)
             {
                 Console.WriteLine( "Enter Money you want to send: ");
                 sendMoney = int.Parse(Console.ReadLine());
                 if (users[bankInfo.CurrentUserIndex].cash >= sendMoney)
                 {
                     users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash - sendMoney;
                     users[reciever].cash = users[reciever].cash + sendMoney;

                     Console.WriteLine( "Your Remaining Balance is: " + users[bankInfo.CurrentUserIndex].cash);
                     storeData(users);
                     press();
                 }
                 else if (users[bankInfo.CurrentUserIndex].cash < sendMoney)
                 {
                     Console.WriteLine( "You Dont Have Enough Cash");
                 }
             }
         }
         public static void payBills(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("payBills");
             int bill;

             Console.WriteLine( "Enter Type of bill You Want to Pay(gas/Electricity/Phone): ");
             users[bankInfo.CurrentUserIndex].bills = Console.ReadLine();
             Console.WriteLine( "Enter Amount of Bill to Pay: ");
             bill = int.Parse(Console.ReadLine());

             if (users[bankInfo.CurrentUserIndex].cash >= bill)
             {
                 users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash - bill;
                 bankInfo.bankBalance = bankInfo.bankBalance + bill;
                 Console.WriteLine( "Your Bill Has Been Payed:" );
                 Console.WriteLine( "Your Remaining Bank Balance is: " + users[bankInfo.CurrentUserIndex].cash + " Rs." );
                 storeData(users);
                 press();
             }
             else if (users[bankInfo.CurrentUserIndex].cash < bill)
             {
                 Console.WriteLine( "You Dont Have Sufficient Balance to Pay The Bill: ");
                 press();
             }
         }
         public static void complaint(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Complaints");
             Console.WriteLine( "Enter Your Complaint: ");
            users[bankInfo.CurrentUserIndex].complaints = Console.ReadLine();
             
             users[bankInfo.CurrentUserIndex].complaintCheck = true;
             
             storeData(users);
             press();
         }
         public static void editAccount(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Edit Account");

             users[bankInfo.CurrentUserIndex].userName = signUpName("Main Menu > Login Menu > Clint Menu > Edit Account");

             users[bankInfo.CurrentUserIndex].password = signUpPassword(users[bankInfo.CurrentUserIndex].userName, "Main Menu > Login Menu > Clint Menu > Edit Account");

             Console.WriteLine();

             Console.WriteLine( "Your Account has been Edited: " );
             storeData(users);
             press();
         }
         public static void clientFunds(List<bankClass> users, bankClass bankInfo)
         {
             Console.Clear();
             header();
             userClientMenu("Funds");

             int fund;
             string creditCard;
             Console.WriteLine( "Enter Amount you want to give to funds: ");
             fund = int.Parse(Console.ReadLine());

             Console.WriteLine( "Enter creditCard Number: ");
             creditCard = Console.ReadLine();

             if (creditCard == users[bankInfo.CurrentUserIndex].creditCardNo && users[bankInfo.CurrentUserIndex].cash > fund)
             {
                 users[bankInfo.CurrentUserIndex].cash = users[bankInfo.CurrentUserIndex].cash - fund;
                 Console.WriteLine( "Your Remaining Bank Balance is: " + users[bankInfo.CurrentUserIndex].cash + " Rs." );
                 Console.WriteLine( "Thank You for your donation: " );
                 users[bankInfo.CurrentUserIndex].funds = true;
                 users[bankInfo.CurrentUserIndex].fundPayed = users[bankInfo.CurrentUserIndex].fundPayed + fund;
                 storeData(users);
                 press();
             }
             else if (creditCard != users[bankInfo.CurrentUserIndex].creditCardNo || users[bankInfo.CurrentUserIndex].cash < fund)
             {
                 Console.WriteLine( "Invalid Credit Card Number or not enough bank balance: " );
                 Console.WriteLine( "You can NOT pay for the donation: " );
                 press();
             }
         }
         public static string otherServicesOptions(List<bankClass> users, bankClass bankInfo)
         {
             string choice;
             while (true)
             {
                 Console.Clear();
                 header();
                 userClientMenu("Other Services");

                 Console.WriteLine( "Press 1 to request for a check book: " );
                 Console.WriteLine( "Press 2 to request for a card: " );
                 Console.WriteLine( "Enter your choice: ");
                 choice = Console.ReadLine();
                 if (choice == "1" || choice == "2")
                 {
                     break;
                 }
                 else
                 {
                     Console.WriteLine( "Please Enter a Valid Option: " );
                     press();
                 }
             }
             return choice;
         }
         public static void otherServices(List<bankClass> users, bankClass bankInfo)
         {
             string choice = otherServicesOptions(users, bankInfo);

             if (choice == "1")
             {
                 if (users[bankInfo.CurrentUserIndex].checkBook == false)
                 {
                     users[bankInfo.CurrentUserIndex].checkBook = true;
                     Console.WriteLine( "Your Request Has Been Sent: " );
                     storeData(users);
                     press();
                 }
                 else if (users[bankInfo.CurrentUserIndex].checkBook == true)
                 {
                     Console.WriteLine( "Sorry! You Already have a Book: ");
                     press();
                 }
             }
             else if (choice == "2")
             {
                 if (users[bankInfo.CurrentUserIndex].newCard == false)
                 {
                     users[bankInfo.CurrentUserIndex].newCard = true;
                     Console.WriteLine( "Your Request Has Been Sent: " );
                     storeData(users);
                     press();
                 }
                 else if (users[bankInfo.CurrentUserIndex].newCard == true)
                 {
                     Console.WriteLine( "Sorry! You Already have a Card:");
                     press();
                 }
             }
         }
         public static void clientReviewsOptions(List<bankClass> users, bankClass bankInfo)
         {
             bool check = false;
             while (check == false)
             {
                 Console.Clear();
                 header();
                 userClientMenu("Reviews");
                 Console.WriteLine( "<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>" );
                 Console.WriteLine();

                 string choice; 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine( "Dear Miss/Sir, Kindly give Reviews of your experience" );
                 Console.WriteLine( "Your Reviews will help us improve our system" );
                 Console.WriteLine( "choose any of the following Options" );
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine( "1.Excellent" );
                 Console.WriteLine( "2.Very Good" );
                 Console.WriteLine( "3.Good" );
                 Console.WriteLine( "4.Average" );
                 Console.WriteLine( "5.Bad" );
                 Console.WriteLine( "6.Very Bad" );
                 Console.WriteLine( "7.Worst" );
                Console.Write("Enter Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();

                 check = clientReview(choice,users,bankInfo);
             }
             storeData(users);
         }
         public static bool clientReview(string choice, List<bankClass> users, bankClass bankInfo)
         {
             bool check = false;
             if (choice == "1")
             {
                 check = true;
                 users[bankInfo.CurrentUserIndex].reviewCheck = true;
                 users[bankInfo.CurrentUserIndex].clientReviews = "Excellent";
             }
             else if (choice == "2")
             {
                 check = true;
                 users[bankInfo.CurrentUserIndex].reviewCheck = true;
                 users[bankInfo.CurrentUserIndex].clientReviews = "Very Good";
             }
             else if (choice == "3")
             {
                 check = true;
                 users[bankInfo.CurrentUserIndex].reviewCheck = true;
                 users[bankInfo.CurrentUserIndex].clientReviews = "Good";
             }
             else if (choice == "4")
             {
                 check = true;
                 users[bankInfo.CurrentUserIndex].reviewCheck = true;
                 users[bankInfo.CurrentUserIndex].clientReviews = "Average";
             }
             else if (choice == "5")
             {
                 check = true;
                 users[bankInfo.CurrentUserIndex].reviewCheck = true;
                 users[bankInfo.CurrentUserIndex].clientReviews = "Bad";
             }
             else if (choice == "6")
             {
                 check = true;
                 users[bankInfo.CurrentUserIndex].reviewCheck = true;
                 users[bankInfo.CurrentUserIndex].clientReviews = "Very Bad";
             }
             else if (choice == "7")
             {
                 check = true;
                 users[bankInfo.CurrentUserIndex].reviewCheck = true;
                 users[bankInfo.CurrentUserIndex].clientReviews = "Worst";
             }
             else
             {
                 check = false;
                 users[bankInfo.CurrentUserIndex].reviewCheck = false;
                 Console.WriteLine( "Please Choose a valid Option" );
                 press();
             }
             return check;
         }
         public static bool deleteMyAccount(List<bankClass> users, bankClass bankInfo)
         {
             bool check;
             while (true)
             {
                 Console.Clear();
                 header();
                 userClientMenu("Remove Account");

                 string choice;
                 Console.WriteLine( "Are you sure, you want to remove your account?(y,n)");
                 choice = Console.ReadLine();

                 if (choice == "y" || choice == "Y")
                 {
                     delClient(bankInfo.CurrentUserIndex, users);
                     check = true;
                     break;
                 }
                 else if (choice == "n" || choice == "N")
                 {
                     check = false;
                     break;
                 }
                 else
                 {
                     Console.WriteLine( "Please enter a Valid Option" );
                     press();
                 }
             }

             return check;
         }
        
        //
        //
        /////////////////////////////////////////
        //         Other Functions             //
        /////////////////////////////////////////
        //
        //
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
        public static void userAdminMenu(string subMenu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = "Main Menu > Login Menu > Admin Menu > " + subMenu;
            Console.WriteLine(message);
            Console.WriteLine("<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void userClientMenu(string subMenu)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = "Main Menu > Login Menu > Clint Menu > " + subMenu;
            Console.WriteLine(message);
            Console.WriteLine("<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>"
                 );
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static int checkUser(string name, string pass, List<bankClass> users)
        {


            for (int x = 0; x < users.Count; x++)
            {
                if (name == users[x].userName && pass == users[x].password)
                {
                    return x;
                }
            }
            return -1;
        }
        public static bool checkAvailable(string name, string pass, List<bankClass> users)
        {
            for (int x = 0; x < users.Count; x++)
            {
                if (name == users[x].userName && pass == users[x].password)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool confirmRole(List<bankClass> users, bankClass bankInfo)
        {

            for (int x = 0; x < users.Count; x++)
            {
                if (users[bankInfo.CurrentUserIndex].userName == users[x].userName && users[bankInfo.CurrentUserIndex].password == users[x].password)
                {
                    if (users[x].isAdmin == true)
                    {
                        return true;
                    }
                }
            }
            return false;
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
        public static string getField(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount = commaCount + 1;
                }
                else if (commaCount == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void loadData(List<bankClass> users, bankClass bankInfo)
        {
            string isAdmin_, complaintCheck_, checkBook_, newCard_, funds_;

            string path = "D:\\Study\\OOP\\Week02\\bankApp(lists)\\bankApp.txt";

            if (File.Exists(path))
            {
                string record, reviews_;
                StreamReader myFile = new StreamReader(path);



                while ((record = myFile.ReadLine()) != null)
                {
                    bankClass temp = new bankClass();

                    temp.userName = getField(record, 1);
                    temp.password = getField(record, 2);
                    temp.loans = int.Parse(getField(record, 3));
                    temp.cash = int.Parse(getField(record, 4));
                    temp.creditCardNo = getField(record, 5);
                    isAdmin_ = getField(record, 6);
                    temp.bills = getField(record, 7);
                    temp.complaints = getField(record, 8);
                    complaintCheck_ = getField(record, 9);
                    checkBook_ = getField(record, 10);
                    newCard_ = getField(record, 11);
                    funds_ = getField(record, 12);
                    temp.fundPayed = int.Parse(getField(record, 13));
                    temp.depositions = int.Parse(getField(record, 14));
                    temp.transactions = int.Parse(getField(record, 15));
                    reviews_ = getField(record, 16);
                    temp.clientReviews = getField(record, 17);

                    loadHelper(isAdmin_, complaintCheck_, checkBook_, newCard_, funds_, reviews_, ref temp);
                    if (temp.isAdmin == true)
                    {
                        bankInfo.bankBalance = temp.cash;
                        bankInfo.bankCode = temp.creditCardNo;
                    }

                    users.Add(temp);

                }
                myFile.Close();
            }
        }
        public static void loadHelper(string isAdmin_, string complaintCheck_, string checkBook_, string newCard_, string funds_, string reviews_, ref bankClass temp)
        {
            if (isAdmin_ == "True")
            {
                temp.isAdmin = true;
            }
            else if (isAdmin_ == "False")
            {
                temp.isAdmin = false;
            }
            if (complaintCheck_ == "True")
            {
                temp.complaintCheck = true;
            }
            else if (complaintCheck_ == "False")
            {
                temp.complaintCheck = false;
            }
            if (checkBook_ == "True")
            {
                temp.checkBook = true;
            }
            else if (checkBook_ == "False")
            {
                temp.checkBook = false;
            }
            if (newCard_ == "True")
            {
                temp.newCard = true;
            }
            else if (newCard_ == "False")
            {
                temp.newCard = false;
            }
            if (funds_ == "True")
            {
                temp.funds = true;
            }
            else if (funds_ == "False")
            {
                temp.funds = false;
            }
            if (reviews_ == "True")
            {
                temp.reviewCheck = true;
            }
            else if (reviews_ == "False")
            {
                temp.reviewCheck = false;
            }
        }
        public static void storeData(List<bankClass> users)
        {
            string path = "D:\\Study\\OOP\\Week02\\bankApp(lists)\\bankApp.txt";
            StreamWriter file = new StreamWriter(path);

            for (int x = 0; x < users.Count; x++)
            {
                file.WriteLine(users[x].userName + ","
                     + users[x].password + ","
                     + users[x].loans + ","
                     + users[x].cash + ","
                     + users[x].creditCardNo + ","
                     + users[x].isAdmin + ","
                     + users[x].bills + ","
                     + users[x].complaints + ","
                     + users[x].complaintCheck + ","
                     + users[x].checkBook + ","
                     + users[x].newCard + ","
                     + users[x].funds + ","
                     + users[x].fundPayed + ","
                     + users[x].depositions + ","
                     + users[x].transactions + ","
                     + users[x].reviewCheck + ","
                     + users[x].clientReviews);
            }
            file.Flush();
            file.Close();
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
        public static bool intValidationsCreditCard(string code)
        {
            bool flag = false;
            int i = 0;
            while (i < code.Length)
            {
                if (code.Length < 16)
                {
                    Console.WriteLine("You have entered a number with characters less than 16");
                    Console.WriteLine("Please enter a credit card number of 16 characters");
                    press();
                    break;
                }
                else if (code.Length > 16)
                {
                    Console.WriteLine("You have entered a number with characters greater than 16");
                    Console.WriteLine("Please enter a credit card number of 16 characters");
                    press();
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
                    press();
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

    }
}
