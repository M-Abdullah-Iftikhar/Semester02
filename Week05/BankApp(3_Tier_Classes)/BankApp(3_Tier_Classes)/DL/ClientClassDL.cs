using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp_3_Tier_Classes_.UI;
using BankApp_3_Tier_Classes_.BL;
using System.IO;


namespace BankApp_3_Tier_Classes_.DL
{
    public static class ClientClassDL
    {
        public static List<ClientClassBL> Clients = new List<ClientClassBL>();


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
                if (name == Clients[x].userName && pass == Clients[x].password)
                {
                    return x;
                }
            }
            return -1;
        }
        public static int giveClientNumber()
        {
            return Clients.Count;
        }

        public static void addUserCash(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].cash = Clients[BankClassBL.CurrentUserIndex].cash + money;
        }
        public static void subtractUserCash(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].cash = Clients[BankClassBL.CurrentUserIndex].cash - money;
        }
        public static void addUserTransactions(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].transactions = Clients[BankClassBL.CurrentUserIndex].transactions + money;
        }
        public static void addUserDepositions(int money)
        {
            Clients[BankClassBL.CurrentUserIndex].depositions = Clients[BankClassBL.CurrentUserIndex].depositions + money;
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
            string isAdmin_, complaintCheck_, checkBook_, newCard_, funds_;

            string path = "D:\\Study\\OOP\\Week05\\BankApp(3_Tier_Classes)\\BankAppClient3Tier.txt";

            if (File.Exists(path))
            {
                string record, reviews_;
                StreamReader myFile = new StreamReader(path);



                while ((record = myFile.ReadLine()) != null)
                {
                    ClientClassBL temp = new ClientClassBL();

                    temp.userName = getField(record, 1);
                    temp.password = getField(record, 2);
                    temp.creditCardNo = getField(record, 3);
                    temp.bills = getField(record, 4);
                    temp.complaints = getField(record, 5);
                    temp.clientReviews = getField(record, 6);
                    temp.loans = int.Parse(getField(record, 7));
                    temp.cash = int.Parse(getField(record, 8));
                    temp.fundPayed = int.Parse(getField(record, 9));
                    temp.depositions = int.Parse(getField(record, 10));
                    temp.transactions = int.Parse(getField(record, 11));
                    complaintCheck_ = getField(record, 12);
                    checkBook_ = getField(record, 13);
                    newCard_ = getField(record, 14);
                    funds_ = getField(record, 15);
                    reviews_ = getField(record, 16);

                    loadHelper( complaintCheck_, checkBook_, newCard_, funds_, reviews_, ref temp);
                    

                    Clients.Add(temp);

                }
                myFile.Close();
            }
        }
        public static void loadHelper( string complaintCheck_, string checkBook_, string newCard_, string funds_, string reviews_, ref ClientClassBL temp)
        {
            
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
        public static void storeData()
        {
            string path = "D:\\Study\\OOP\\Week05\\BankApp(3_Tier_Classes)\\BankAppClient3Tier.txt";
            StreamWriter file = new StreamWriter(path);

            for (int x = 0; x < Clients.Count; x++)
            {
                file.WriteLine(Clients[x].userName + ","
                     + Clients[x].password + ","
                     + Clients[x].creditCardNo + ","
                     + Clients[x].bills + ","
                     + Clients[x].complaints + ","
                     + Clients[x].clientReviews + ","
                     + Clients[x].loans + ","
                     + Clients[x].cash + ","
                     + Clients[x].fundPayed + ","
                     + Clients[x].depositions + ","
                     + Clients[x].transactions + ","
                     + Clients[x].complaintCheck + ","
                     + Clients[x].checkBook + ","
                     + Clients[x].newCard + ","
                     + Clients[x].funds + ","
                     + Clients[x].reviewCheck);
                     
            }
            file.Flush();
            file.Close();
        }

        public static bool checkReviewDone()
        {
            if (Clients[BankClassBL.CurrentUserIndex].reviewCheck == false)
            {
                return true;
            }
            return false;
        }


    }
}
