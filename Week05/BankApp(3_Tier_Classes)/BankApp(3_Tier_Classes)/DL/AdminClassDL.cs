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
    public static class AdminClassDL
    {
        public static List<AdminClassBL> Admin = new List<AdminClassBL>();
        public static int bankBalance;
        public static string bankCode;

        public static bool checkAdminBankCode(string bankCode1)
        {
            if (bankCode1 == bankCode)
            {
                return true;
            }
            return false;
        }

        public static AdminClassBL takeUserFromAdminList(int x)
        {
            return Admin[x];
        }

        public static int checkUser(string name, string pass)
        {


            for (int x = 0; x < Admin.Count; x++)
            {
                if (name == Admin[x].userName && pass == Admin[x].password)
                {
                    return x;
                }
            }
            return -1;
        }

        public static void delAdminAccount(int x)
        {
            Admin.RemoveAt(x);
            storeData();


        }

        public static bool checkAvailable(string name, string pass)
        {

            for (int x = 0; x < Admin.Count; x++)
            {
                if (name == Admin[x].userName && pass == Admin[x].password)
                {

                    return true;
                }
            }
            return false;
        }

        public static int giveAdminNumber ()
            {
            return Admin.Count;
            }
        public static void addAdminToList(AdminClassBL user)
        {
            Admin.Add(user);
        }

        public static void subtractBankBalance(int money)
        {
            bankBalance = bankBalance - money;
        }
        public static void addBankBalance(int money)
        {
            bankBalance = bankBalance + money;
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
            

            string path = "D:\\Study\\OOP\\Week05\\BankApp(3_Tier_Classes)\\BankAppAdmin3Tier.txt";

            if (File.Exists(path))
            {
                string record;
                StreamReader myFile = new StreamReader(path);



                while ((record = myFile.ReadLine()) != null)
                {
                    

                    string userName = getField(record, 1);
                    string password = getField(record, 2);
                    bankCode = getField(record, 3);
                    bankBalance = int.Parse(getField(record, 4));
                    AdminClassBL temp = new AdminClassBL(userName,password);


                    Admin.Add(temp);

                }
                myFile.Close();
            }
        }
        
        public static void storeData()
        {
            string path = "D:\\Study\\OOP\\Week05\\BankApp(3_Tier_Classes)\\BankAppAdmin3Tier.txt";
            StreamWriter file = new StreamWriter(path);

            for (int x = 0; x < Admin.Count; x++)
            {
                file.WriteLine(Admin[x].userName + ","
                     + Admin[x].password + ","
                     + bankCode + ","
                     + bankBalance);
            }
            file.Flush();
            file.Close();
        }

    }
}
