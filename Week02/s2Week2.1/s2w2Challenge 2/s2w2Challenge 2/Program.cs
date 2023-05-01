using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace s2w2Challenge_2
{
    class Program
    {
        class students
        {
            string names;
            string passwords;
                

            static void Main(string[] args)
            {
                students[] s = new students[10];
                int count = 0;
                string path = "D:\\Study\\OOP\\Week01\\signIn.txt";
                readData(path, ref s, ref count);

                int option;
                
                
                do
                {

                    
                    Console.Clear();
                    option = menu();
                    Console.Clear();
                    if (option == 1)
                    {
                        Console.WriteLine("Enter Name: ");
                        string n = Console.ReadLine();
                        Console.WriteLine("Enter Password: ");
                        string p = Console.ReadLine();

                        signIn(n, p,s,ref count);
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Enter Name: ");
                        string n = Console.ReadLine();
                        Console.WriteLine("Enter NewNew Password: ");
                        string p = Console.ReadLine();
                        signUp(path, n, p,ref count);
                    }
                }
                while (option < 3);
            }

            public static void main1()
            {
                string path = "D:\\Study\\OOP\\Week01\\signIn.txt";
                if (File.Exists(path))
                {
                    StreamReader myFile = new StreamReader(path);
                    string record;
                    while ((record = myFile.ReadLine()) != null)
                    {
                        Console.WriteLine(record);
                    }
                    myFile.Close();
                }
                else
                {
                    Console.WriteLine("Not Exists");
                }
            }

            public static int menu()
            {
                int option;
                Console.WriteLine("1. Sign in");
                Console.WriteLine("2. Sign up");
                Console.WriteLine("Enter Option");
                option = int.Parse(Console.ReadLine());

                return option;
            }

            public static string parseData(string record, int field)
            {
                int comma = 1;
                string item = "";
                for (int x = 0; x < record.Length; x++)
                {
                    if (record[x] == ',')
                    {
                        comma++;
                    }
                    else if (comma == field)
                    {
                        item = item + record[x];
                    }
                }
                return item;
            }

            static void readData(string path,ref students[] s, ref int count)
            {

                if (File.Exists(path))
                {
                    StreamReader myFile = new StreamReader(path);
                    string record;
                    while ((record = myFile.ReadLine()) != null)
                    {
                        students temp = new students();
                        s[count] = temp;

                        s[count].names = parseData(record, 1);
                        s[count].passwords = parseData(record, 2);
                        count++;


                    }
                    myFile.Close();
                }
                else
                {
                    Console.WriteLine("File not Exist");
                }
            }

            static void signIn(string n, string p,students[] s, ref int count)
            {
                bool check = false;
                for (int x = 0; x < count; x++)
                {
                    if (n == s[x].names && p == s[x].passwords)
                    {
                        Console.WriteLine("Valid User");
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    Console.WriteLine("Invalid User");
                }
                Console.ReadKey();
            }

            public static void signUp(string path, string n, string p,ref int count)
            {
                StreamWriter myFile = new StreamWriter(path, true);
                myFile.WriteLine(n + "," + p);
                myFile.Flush();
                myFile.Close();
                count++;
            }

        }
    }
}