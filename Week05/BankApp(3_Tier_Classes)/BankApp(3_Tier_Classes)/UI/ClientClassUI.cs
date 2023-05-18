using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_3_Tier_Classes_.DL;
using BankApp_3_Tier_Classes_.BL;

namespace BankApp_3_Tier_Classes_.UI
{
    class ClientClassUI
    {

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
                    BankClassUI.press();
                    break;
                }
                else if (code.Length > 16)
                {
                    Console.WriteLine("You have entered a number with characters greater than 16");
                    Console.WriteLine("Please enter a credit card number of 16 characters");
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

                check = ClientClassDL.checkUser(name, pass);
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

        public static void clientMenu()
        {

            int logout = 0;

            while (true)
            {
                Console.Clear();
                BankClassUI.header();
                BankClassUI.userMenu("Client");
                string choice;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press 1 to Check Your Balance: ");
                Console.WriteLine("Press 2 to Withdraw Cash: ");
                Console.WriteLine("Press 3 to Deposit Cash: ");
                Console.WriteLine("Press 4 to Request For a Loan: ");
                Console.WriteLine("Press 5 to Pay Loan: ");
                Console.WriteLine("Press 6 to Send Cash to Another User: ");
                Console.WriteLine("Press 7 to Pay Bills:");
                Console.WriteLine("Press 8 to File a Complaint:");
                Console.WriteLine("Press 9 to Edit Your Account:");
                Console.WriteLine("Press 10 to pay for Funds: ");
                Console.WriteLine("Press 11 to Enter Other Services: ");
                Console.WriteLine("Press 12 to Give Your Reviews: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Press 13 to delete your account: ");
                Console.WriteLine("Press 14 to Logout: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();

                logout = clientMenuOptions(choice);

                if (logout == 1)
                {
                    bool check = ClientClassDL.checkReviewDone();
                    if (check == false)
                    {
                        clientReviewsOptions();
                    }
                    break;
                }
                else if (logout == 2)
                {
                    break;
                }
            }
        }
        public static int clientMenuOptions(string choice)
        {
            int logout = 0;

            if (choice == "1")
            {
                checkBalance();
            }
            else if (choice == "2")
            {
                cashWithdraw();
            }
            else if (choice == "3")
            {
                cashDeposit();
            }
            else if (choice == "4")
            {
                loanRequest();
            }
            else if (choice == "5")
            {
                loanPay();
            }
            else if (choice == "6")
            {
                sendCash();
            }
            else if (choice == "7")
            {
                payBills();
            }
            else if (choice == "8")
            {
                complaint();
            }
            else if (choice == "9")
            {
                editAccount();
            }
            else if (choice == "10")
            {
                clientFunds();
            }
            else if (choice == "11")
            {
                otherServices();
            }
            else if (choice == "12")
            {
                clientReviewsOptions();
            }
            else if (choice == "13")
            {
                bool check = deleteMyAccount();
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
                Console.WriteLine("Please Choose a valid Option");
                BankClassUI.press();
            }
            BankClassUI.press();
            return logout;
        }
        public static void checkBalance()
        {
            Console.Clear();
            BankClassUI.header();
            userClientMenu("Balance");
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);


            Console.WriteLine("Your Current Balance is: " + users.cash);
            Console.WriteLine("Your Current Loan to Pay is: " + users.loans);
            
        }
        public static void cashWithdraw()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            bool check = false;
            string withdraw = "0";

            while (check == false)
            {
                Console.Clear();
                BankClassUI.header();
                userClientMenu("Withdraw Cash");


                withdraw = takeWithdrawInput();
                check = intValidationsMoney(withdraw);

            }

                if (int.Parse(withdraw) <= users.cash)
                {
                ClientClassDL.subtractUserCash(int.Parse(withdraw));
                   
                    Console.WriteLine("You Have withdrawn: " + withdraw + " Rs");
                    Console.WriteLine("Your Remaining Balance is: " + users.cash);
                    AdminClassDL.subtractBankBalance(int.Parse(withdraw));

                ClientClassDL.addUserTransactions(int.Parse(withdraw));
                    
                    ClientClassDL.storeData();
                    
                }
                else if (int.Parse(withdraw) > users.cash)
                {
                    Console.WriteLine("Sorry! Your Account doesnt have Enough Balance: ");
                   
                }
            
        }

        public static string takeWithdrawInput()
        {
            Console.WriteLine("Enter cash to be Withdrawn: ");
            string withdraw = Console.ReadLine();

            return withdraw;
        }
        public static void cashDeposit()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            string deposit = "0";
            bool check = false;
            while (check == false)
            {

                Console.Clear();
                BankClassUI.header();
                userClientMenu("Deposite cash");


                

                deposit = takeCashInput();
                check = intValidationsMoney(deposit);
            }
           
            string creditCard = takeCreditCardInput();


            if (creditCard == users.creditCardNo)
            {
                
                AdminClassDL.addBankBalance(int.Parse(deposit));
                ClientClassDL.addUserCash(int.Parse(deposit));
                ClientClassDL.addUserDepositions(int.Parse(deposit));
                
                Console.WriteLine(deposit + " Rs. has been deposited in your account: ");
                ClientClassDL.storeData();
               
            }
            else
            {
                Console.WriteLine("Your Credit Card Number is Wrong: ");
                
            }
        }

        public static string takeCreditCardInput()
        {
           
            Console.WriteLine("Enter creditCard Number: ");
            string creditCard = Console.ReadLine();
            return creditCard;
        }

        public static string takeCashInput()
        {
            Console.WriteLine("Enter Cash to Deposit: ");
            string deposit = Console.ReadLine();
            return deposit;
        }
        public static void loanRequest()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            Console.Clear();
            BankClassUI.header();
            userClientMenu("Request Loans");
            int loan;
            int year;
            int month;
            int date;
            int sum;

            int currentDate;
            int currentMonth;
            int currentYear;

            Console.WriteLine("Enter Amount of Loan You want: ");
            loan = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Current year(202*): ");
            currentYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Current month(1-12): ");
            currentMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Current date of the month(1-30): ");
            currentDate = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter year in which you can repay(202*): ");
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month in which You can repay the loan(1-12): ");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter date of the month you can repay the loan(1-30): ");
            date = int.Parse(Console.ReadLine());

            sum = ((year - currentYear) * 365) + ((month - currentMonth) * 30) + (date - currentDate);

            if (users.loans > 0)
            {
                Console.WriteLine("Sorry! We Cannot Provide you more loan Because You Already have a loan to pay: ");
                BankClassUI.press();
            }
            else if (users.loans == 0)
            {

                if (loan >= 1000000)
                {
                    if (sum <= 360)
                    {
                        Console.WriteLine("You Have been Given the loan: ");
                        Console.WriteLine("ThankYou for Using this App: ");
                        users.cash = users.cash + loan;
                        users.loans = loan;
                        AdminClassDL.subtractBankBalance(loan);
                        ClientClassDL.storeData();
                        
                    }
                    else if (sum > 360)
                    {
                        Console.WriteLine("Sorry! We Can't Provide you " + loan + " Rs for more than a Year");
                       
                    }
                    BankClassUI.press();
                }
                else if (loan >= 100000 && loan < 1000000)
                {
                    if (sum <= 180)
                    {
                        Console.WriteLine("You Have been Given the loan: ");
                        Console.WriteLine("ThankYou for Using this App: ");
                        users.cash = users.cash + loan;
                        users.loans = loan;

                        AdminClassDL.subtractBankBalance(loan);
                        ClientClassDL.storeData();
                        
                    }
                    else if (sum > 180)
                    {
                        Console.WriteLine("Sorry! We Can't Provide you " + loan + " Rs for more than 6 Months");
                       
                    }
                    BankClassUI.press();
                }
                else if (loan < 100000)
                {
                    if (sum <= 90)
                    {
                        Console.WriteLine("You Have been Given the loan: ");
                        Console.WriteLine("ThankYou for Using this App: ");
                        users.cash = users.cash + loan;
                        users.loans = loan;
                        AdminClassDL.subtractBankBalance(loan);
                        
                        ClientClassDL.storeData();
                        
                    }
                    else if (sum > 90)
                    {
                        Console.WriteLine("Sorry! We Can't Provide you " + loan + " Rs for more than 3 Months");
                       
                    }
                    BankClassUI.press();
                }
            }
        }
        public static void loanPay()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            Console.Clear();
            BankClassUI.header();
            userClientMenu("Pay Loans");
            string creditCard;
            string payLoan = "0";
            bool check = false;

            if (users.loans == 0)
            {
                Console.WriteLine("You Dont have any loans to pay: ");
                BankClassUI.press();
            }

            else if (users.loans > 0)
            {
                
                while(check == false)
                {
                    Console.Clear();
                    BankClassUI.header();
                    userClientMenu("Pay Loans");
                    Console.WriteLine("You Have " + users.loans + " Rs to Pay");

                    Console.WriteLine("Enter Price You Want to pay: ");
                    payLoan = Console.ReadLine();

                    check = intValidationsMoney(payLoan);
                }
                
                
                Console.WriteLine("Enter creditCard Number: ");
                creditCard = Console.ReadLine();

                if (creditCard == users.creditCardNo && users.cash > int.Parse(payLoan))
                {

                    if (int.Parse(payLoan) >= users.loans)
                    {
                        AdminClassDL.addBankBalance(int.Parse(payLoan));

                        int payed;
                        payed = int.Parse(payLoan) - users.loans;
                        users.cash = users.cash + payed;
                        users.loans = 0;
                        Console.WriteLine("You have Paid more than you Were owed, Your dept has been payed");
                        Console.WriteLine("Remaining Money i.e. " + payLoan + " Rs. has been Deposited to your Account ");

                        BankClassUI.press();
                    }
                    else if (int.Parse(payLoan) < users.loans)
                    {
                        AdminClassDL.addBankBalance(int.Parse(payLoan));
                        
                        users.loans = users.loans - int.Parse(payLoan);
                        users.cash = users.cash - int.Parse(payLoan);
                        Console.WriteLine("Now you are Owed " + users.loans + " Rs. More");
                        BankClassUI.press();
                    }
                }
            }
        }
        public static void sendCash()
        {
            Console.Clear();
            BankClassUI.header();
            userClientMenu("Send Cash");
            int sendMoney;
            int reciever;
            string name;
            string pass;
            Console.WriteLine("Enter Name of User You want to send cash to: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter password of the user you want to send cash to: ");
            pass = Console.ReadLine();

            reciever = ClientClassDL.checkUser(name, pass);
            if (reciever == -1)
            {
                Console.WriteLine("This User isn't signed up in this Bank:");
                Console.WriteLine("Please Enter a valid User:");
                BankClassUI.press();
            }
            else if (reciever != -1)
            {
                ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
                ClientClassBL userR = ClientClassDL.takeUserFromClientList(reciever);

                Console.WriteLine("Enter Money you want to send: ");
                sendMoney = int.Parse(Console.ReadLine());
                if (users.cash >= sendMoney)
                {
                    users.cash = users.cash - sendMoney;
                    userR.cash = userR.cash + sendMoney;

                    Console.WriteLine("Your Remaining Balance is: " + users.cash);
                    ClientClassDL.storeData();
                   
                }
                else if (users.cash < sendMoney)
                {
                    Console.WriteLine("You Dont Have Enough Cash");
                }
                BankClassUI.press();
            }
        }
        public static void payBills()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            Console.Clear();
            BankClassUI.header();
            userClientMenu("payBills");
            int bill;

            Console.WriteLine("Enter Type of bill You Want to Pay(gas/Electricity/Phone): ");
            users.bills = Console.ReadLine();
            Console.WriteLine("Enter Amount of Bill to Pay: ");
            bill = int.Parse(Console.ReadLine());

            if (users.cash >= bill)
            {
                ClientClassDL.subtractUserCash(bill);
                AdminClassDL.addBankBalance(bill);
                Console.WriteLine("Your Bill Has Been Payed:");
                Console.WriteLine("Your Remaining Bank Balance is: " + users.cash + " Rs.");
                ClientClassDL.storeData();
                AdminClassDL.storeData();
                
            }
            else if (users.cash < bill)
            {
                Console.WriteLine("You Dont Have Sufficient Balance to Pay The Bill: ");
                
            }
        }
        public static void complaint()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            Console.Clear();
            BankClassUI.header();
            userClientMenu("Complaints");
            Console.WriteLine("Enter Your Complaint: ");
            users.complaints = Console.ReadLine();

            users.complaintCheck = true;

            ClientClassDL.storeData();
            
        }
        public static void editAccount()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            Console.Clear();
            BankClassUI.header();
            userClientMenu("Edit Account");

            users.userName = BankClassUI.signUpName("Main Menu > Login Menu > Clint Menu > Edit Account");

            users.password = BankClassUI.signUpPassword(users.userName, "Main Menu > Login Menu > Clint Menu > Edit Account");

            Console.WriteLine();

            Console.WriteLine("Your Account has been Edited: ");
            ClientClassDL.storeData();
            
        }
        public static void clientFunds()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            Console.Clear();
            BankClassUI.header();
            userClientMenu("Funds");

            int fund;
            string creditCard;
            Console.WriteLine("Enter Amount you want to give to funds: ");
            fund = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter creditCard Number: ");
            creditCard = Console.ReadLine();

            if (creditCard == users.creditCardNo && users.cash > fund)
            {
                ClientClassDL.subtractUserCash(fund);
                
                Console.WriteLine("Your Remaining Bank Balance is: " + users.cash + " Rs.");
                Console.WriteLine("Thank You for your donation: ");
                users.funds = true;
                users.fundPayed = users.fundPayed + fund;
                ClientClassDL.storeData();
                
            }
            else if (creditCard != users.creditCardNo || users.cash < fund)
            {
                Console.WriteLine("Invalid Credit Card Number or not enough bank balance: ");
                Console.WriteLine("You can NOT pay for the donation: ");
                
            }
        }
        public static string otherServicesOptions()
        {
            string choice;
            while (true)
            {
                Console.Clear();
                BankClassUI.header();
                userClientMenu("Other Services");

                Console.WriteLine("Press 1 to request for a check book: ");
                Console.WriteLine("Press 2 to request for a card: ");
                Console.WriteLine("Enter your choice: ");
                choice = Console.ReadLine();
                if (choice == "1" || choice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid Option: ");
                    BankClassUI.press();
                }
            }
            return choice;
        }
        public static void otherServices()
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            string choice = otherServicesOptions();

            if (choice == "1")
            {
                if (users.checkBook == false)
                {
                    users.checkBook = true;
                    Console.WriteLine("Your Request Has Been Sent: ");
                    ClientClassDL.storeData();
                   
                }
                else if (users.checkBook == true)
                {
                    Console.WriteLine("Sorry! You Already have a Book: ");
                    
                }
                BankClassUI.press();
            }
            else if (choice == "2")
            {
                if (users.newCard == false)
                {
                    users.newCard = true;
                    Console.WriteLine("Your Request Has Been Sent: ");
                    ClientClassDL. storeData();
                    
                }
                else if (users.newCard == true)
                {
                    Console.WriteLine("Sorry! You Already have a Card:");
                    
                }
                BankClassUI.press();
            }
        }
        public static void clientReviewsOptions()
        {
            bool check = false;
            while (check == false)
            {
                Console.Clear();
                BankClassUI.header();
                userClientMenu("Reviews");
                Console.WriteLine("<>---(<><><>)---(<><><>)---<>---(<><><>)---(<><><>)---<>");
                Console.WriteLine();

                string choice;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Dear Miss/Sir, Kindly give Reviews of your experience");
                Console.WriteLine("Your Reviews will help us improve our system");
                Console.WriteLine("choose any of the following Options");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1.Excellent");
                Console.WriteLine("2.Very Good");
                Console.WriteLine("3.Good");
                Console.WriteLine("4.Average");
                Console.WriteLine("5.Bad");
                Console.WriteLine("6.Very Bad");
                Console.WriteLine("7.Worst");
                Console.Write("Enter Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                choice = Console.ReadLine();

                check = clientReview(choice);
            }
            ClientClassDL.storeData();
        }
        public static bool clientReview(string choice)
        {
            ClientClassBL users = ClientClassDL.takeUserFromClientList(BankClassBL.CurrentUserIndex);
            bool check = false;
            if (choice == "1")
            {
                check = true;
                users.reviewCheck = true;
                users.clientReviews = "Excellent";
            }
            else if (choice == "2")
            {
                check = true;
                users.reviewCheck = true;
                users.clientReviews = "Very Good";
            }
            else if (choice == "3")
            {
                check = true;
                users.reviewCheck = true;
                users.clientReviews = "Good";
            }
            else if (choice == "4")
            {
                check = true;
                users.reviewCheck = true;
                users.clientReviews = "Average";
            }
            else if (choice == "5")
            {
                check = true;
                users.reviewCheck = true;
                users.clientReviews = "Bad";
            }
            else if (choice == "6")
            {
                check = true;
                users.reviewCheck = true;
                users.clientReviews = "Very Bad";
            }
            else if (choice == "7")
            {
                check = true;
                users.reviewCheck = true;
                users.clientReviews = "Worst";
            }
            else
            {
                check = false;
                users.reviewCheck = false;
                Console.WriteLine("Please Choose a valid Option");
                BankClassUI.press();
            }
            return check;
        }
        public static bool deleteMyAccount()
        {
            bool check;
            while (true)
            {
                Console.Clear();
                BankClassUI.header();
                userClientMenu("Remove Account");

                string choice;
                Console.WriteLine("Are you sure, you want to remove your account?(y,n)");
                choice = Console.ReadLine();

                if (choice == "y" || choice == "Y")
                {
                    delClient(BankClassBL.CurrentUserIndex);
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
                    Console.WriteLine("Please enter a Valid Option");
                    BankClassUI.press();
                }
            }

            return check;
        }
        public static void delClient(int x)
        {
            ClientClassDL.delClientAccount(x);
            Console.WriteLine("The account has been removed successfully");
            BankClassUI.press();
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

        public static bool intValidationsMoney(string code)
        {
            bool flag = false;
            int i = 0;
            while (i < code.Length)
            {
                
                if (code[i] > 47 && code[i] < 58)
                {
                    i++;
                    flag = true;
                }
                else
                {
                    flag = false;
                    Console.WriteLine("Enter Integer Digits Only");
                    BankClassUI.press();
                    
                    break;
                }
            }
            return flag;
        }

        public static string signUpCreditCardNo(string name, string pass, string head)
        {
            bool check = false;
            string creditCard = "";
            while (check == false)
            {
                Console.Clear();
                BankClassUI.header();
                BankClassUI.SubMenu(head);
                Console.WriteLine("Enter Your name(alphabets only): " + name);
                Console.WriteLine("Enter Your Password (atleast 8 characters long): " + pass);
                Console.WriteLine("Enter Credit Card Number(integer values Only & 16 characters long): ");
                creditCard = Console.ReadLine();
                check = intValidationsCreditCard(creditCard);
            }
            return creditCard;
        }
        public static void signUp()
        {

            Console.Clear();
            BankClassUI.header();
            BankClassUI.SubMenu("Login Menu");

            bool check = false;

            string name;
            string pass;
            string creditCardNo;




            name = BankClassUI.signUpName("Login Menu");
            pass = BankClassUI.signUpPassword(name, "Login Menu");
            creditCardNo = signUpCreditCardNo(name, pass, "Login Menu");





            check = AdminClassDL.checkAvailable(name, pass);

            if (check == true)
            {
                Console.WriteLine("User Already exists, try a different user name");
                BankClassUI.press();
            }
            else if (check == false)
            {

                ClientClassBL user = new ClientClassBL(name, pass,creditCardNo,"N/A","N/A","N/A",0,0,0,0,0, false, false, false, false, false);
                ClientClassDL.addClientToList(user);


            }
        }

    }
}
