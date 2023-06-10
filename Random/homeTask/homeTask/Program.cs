using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\MUGHAL RAJ\\Desktop\\homeTask\\homeTask\\text.txt";
            string[] names = new string[100];
            int uOrder;
            int uprice;
            int orders = 1;
            int orders1 = 1;
            int[] prices = new int[100];
            int[] price1 = new int[100];

           bool check = readdata(path, names, orders, orders1, prices, price1);
            if (check == true)
            {
                Console.Write("Enter No. of Order");
                uOrder = int.Parse(Console.ReadLine());
                Console.Write("Enter Minimum Price");
                uprice = int.Parse(Console.ReadLine());
                calculate(names, orders, orders1, prices, price1, uOrder, uprice);
            }
            else
            {
                Console.WriteLine(" No Data ");

            }
            Console.ReadKey();
        }
        static string parseData(string record, int field)
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
        static bool readdata(string path, string[] names, int orders, int orders1, int[] prices, int[] price1)
        {

            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                record = filevariable.ReadLine();
                names[0] = parseData(record, 1);
                orders = int.Parse(parseData(record, 2));
                int y = 0;
                for (int x = 3; x < 11; x++)
                {
                    prices[y] = int.Parse(parseData(record, x));
                    y++;
                }
                record = filevariable.ReadLine();
                names[1] = parseData(record, 1);
                orders1 = int.Parse(parseData(record, 2));
                int z = 0;
                for (int x = 3; x < 11; x++)
                {
                    price1[z] = int.Parse(parseData(record, x));
                    z++;
                }


                filevariable.Close();
                return true;
            }
            else
            {
                Console.WriteLine(" Not Exists");
                return false;
            }
        }
        static void calculate (string[] names, int orders, int orders1, int[] prices, int[] price1, int uOrder, int uprice)
            {
            int sum=0;
            int ave = 0;
               for(int x=0; x < uOrder; x++ )
               {
                sum = sum + prices[x];
               }
            ave = sum / uOrder;
            
            if (ave > uprice)
            {
                Console.WriteLine(" "+ names[0]) ;
            }
            int sum1 = 0;
            int ave1 = 0;

            for (int x = 0; x < uOrder; x++)
                {
                    sum1 = sum1 + price1[x];
                }
                ave1 = sum1 / uOrder;
            if (ave1 > uprice)
            {
                Console.WriteLine(" " + names[1]);
            }
        }

    }
}
