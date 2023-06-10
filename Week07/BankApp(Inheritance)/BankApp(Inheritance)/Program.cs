using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_Inheritance_.UI;
using BankApp_Inheritance_.DL;
using BankApp_Inheritance_.BL;

namespace BankApp_Inheritance_
{
    class Program
    {
        static void Main(string[] args)
        {

            AdminClassDL.loadData();
            ClientClassDL.loadData();

            BankClassBL.checkAdmin = false;
            BankClassBL.loginCheck = false;
            bool logout = false;


            while (true)
            {
                string choice;
                logout = false;
                Console.Clear();
                BankClassUI.header();
                BankClassUI.SubMenuForMainMenu("Main");

                choice = BankClassUI.mainMenu();

                if (choice == "1")
                {
                    bool check = AdminClassUI.adminBankCode();

                    if (check == false)
                    {
                        BankClassUI.warning();
                        BankClassUI.press();
                        continue;
                    }
                    else if (check == true)
                    {
                        while (true)
                        {
                            BankClassBL.loginCheck = false;
                            logout = false;
                            bool checkUser1 = false;
                            string loginMenuCheck = BankClassUI.loginMenu();

                            while (true)
                            {
                                BankClassBL.loginCheck = false;
                                logout = false;
                                if (loginMenuCheck == "1")
                                {
                                    checkUser1 = AdminClassUI.login();

                                    if (checkUser1 == false)
                                    {
                                        break;
                                    }
                                    else if (checkUser1 == true)
                                    {
                                        AdminClassUI.adminMenu();
                                        break;
                                    }

                                }
                                else if (loginMenuCheck == "2")
                                {
                                    AdminClassUI.signUp();
                                    BankClassBL.loginCheck = false;

                                    break;
                                }
                                else if (loginMenuCheck == "3")
                                {
                                    logout = true;
                                    BankClassBL.loginCheck = false;
                                    break;
                                }

                            }
                            if (logout == true)
                            {
                                break;
                            }
                        }
                    }
                }
                else if (choice == "2")
                {
                    while (true)
                    {
                        BankClassBL.loginCheck = false;
                        logout = false;
                        bool checkUser1 = false;
                        string loginMenuCheck = BankClassUI.loginMenu();

                        while (true)
                        {
                            BankClassBL.loginCheck = false;
                            logout = false;
                            if (loginMenuCheck == "1")
                            {
                                checkUser1 = ClientClassUI.login();

                                if (checkUser1 == false)
                                {
                                    break;
                                }
                                else if (checkUser1 == true)
                                {
                                    ClientClassUI.clientMenu();
                                    break;
                                }

                            }
                            else if (loginMenuCheck == "2")
                            {
                                ClientClassUI.signUp();
                                BankClassBL.loginCheck = false;

                                break;
                            }
                            else if (loginMenuCheck == "3")
                            {
                                logout = true;
                                BankClassBL.loginCheck = false;
                                break;
                            }

                        }
                        if (logout == true)
                        {
                            break;
                        }
                    }
                }
                else if (choice == "3")
                {
                    ClientClassDL.storeData();
                    AdminClassDL.storeData();
                    BankClassUI.programmEnds();
                    break;
                }

            }

        }
    }
}
