using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BankApp_Inheritance_.BL;
using BankApp_Inheritance_.UI;

namespace BankApp_Inheritance_.DL
{
    class ClientClassDL
    {
        private static List<ClientClassBL> Clients = new List<ClientClassBL>();


        public static void addClientToList(ClientClassBL user)
        {
            Clients.Add(user);
        }
        public static ClientClassBL takeUserFromClientList(int x)
        {
            return Clients[x];
        }



        public static void delClientAccount(int x)
        {
            Clients.RemoveAt(x);
            storeData();


        }
        public static int checkUser(string name, string pass)
        {


            for (int x = 0; x < Clients.Count; x++)
            {
                if (name == Clients[x].getName() && pass == Clients[x].getPassword())
                {
                    return x;
                }
            }
            return -1;
        }
       

        public static void addUserCash(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].setCash(Clients[BankClassBL.CurrentUserIndex].getCash() + money);
        }
        public static void subtractUserCash(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].setCash(Clients[BankClassBL.CurrentUserIndex].getCash() - money);
        }
        public static void addUserTransactions(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].setTransactions(Clients[BankClassBL.CurrentUserIndex].getTransactions() + money);
        }
        public static void addUserDepositions(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].setDepositions(Clients[BankClassBL.CurrentUserIndex].getDepositions() + money);
        }

        public static int getClientListSize()
        {
            return Clients.Count;
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
        public static void loadData()
        {
            string  complaintCheck_, checkBook_, newCard_, funds_;

            string path = "D:\\Study\\OOP\\Week07\\BankApp(Inheritance)\\BankAppClientInheritance.txt";

            if (File.Exists(path))
            {
                string record, reviews_;
                StreamReader myFile = new StreamReader(path);



                while ((record = myFile.ReadLine()) != null)
                {
                    ClientClassBL temp = new ClientClassBL();

                    temp.setName(getField(record, 1));
                    temp.setPassword((getField(record, 2)));
                    temp.setCreditCardNo(getField(record, 3));
                    temp.setBills(getField(record, 4));
                    temp.setComplaints(getField(record, 5));
                    temp.setClientReviews(getField(record, 6));
                    temp.setLoans(int.Parse(getField(record, 7)));
                    temp.setCash(int.Parse(getField(record, 8)));
                    temp.setFundPayed(int.Parse(getField(record, 9)));
                    temp.setDepositions(int.Parse(getField(record, 10)));
                    temp.setTransactions(int.Parse(getField(record, 11)));
                    complaintCheck_ = getField(record, 12);
                    checkBook_ = getField(record, 13);
                    newCard_ = getField(record, 14);
                    funds_ = getField(record, 15);
                    reviews_ = getField(record, 16);

                    loadHelper(complaintCheck_, checkBook_, newCard_, funds_, reviews_, ref temp);


                    Clients.Add(temp);

                }
                myFile.Close();
            }
        }
        public static void loadHelper(string complaintCheck_, string checkBook_, string newCard_, string funds_, string reviews_, ref ClientClassBL temp)
        {

            if (complaintCheck_ == "True")
            {
                temp.setComplaintCheck(true);
            }
            else if (complaintCheck_ == "False")
            {
                temp.setComplaintCheck(false);
            }
            if (checkBook_ == "True")
            {
                temp.setCheckBook(true);
            }
            else if (checkBook_ == "False")
            {
                temp.setCheckBook(false);
            }
            if (newCard_ == "True")
            {
                temp.setNewCard(true);
            }
            else if (newCard_ == "False")
            {
                temp.setNewCard(false);
            }
            if (funds_ == "True")
            {
                temp.setFunds(true);
            }
            else if (funds_ == "False")
            {
                temp.setFunds(false);
            }
            if (reviews_ == "True")
            {
                temp.setReviewCheck(true);
            }
            else if (reviews_ == "False")
            {
                temp.setReviewCheck(false);
            }
        }
        public static void storeData()
        {
            string path = "D:\\Study\\OOP\\Week07\\BankApp(Inheritance)\\BankAppClientInheritance.txt";
            StreamWriter file = new StreamWriter(path);

            for (int x = 0; x < Clients.Count; x++)
            {
                file.WriteLine(Clients[x].getName() + ","
                     + Clients[x].getPassword() + ","
                     + Clients[x].getCreditCardNo() + ","
                     + Clients[x].getBill() + ","
                     + Clients[x].getComplaint() + ","
                     + Clients[x].getClientReviews() + ","
                     + Clients[x].getLoans() + ","
                     + Clients[x].getCash() + ","
                     + Clients[x].getFundPayed() + ","
                     + Clients[x].getDepositions() + ","
                     + Clients[x].getTransactions() + ","
                     + Clients[x].getComplaintCheck() + ","
                     + Clients[x].getCheckBook() + ","
                     + Clients[x].getNewCard() + ","
                     + Clients[x].getFunds() + ","
                     + Clients[x].getReviewCheck());

            }
            file.Flush();
            file.Close();
        }

        public static bool checkReviewDone()
        {
            if (Clients[BankClassBL.CurrentUserIndex].getReviewCheck() == false)
            {
                return true;
            }
            return false;
        }


    }
}
