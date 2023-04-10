using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_week_2_Challenge_1
{
    class products
    {
        public string ID;
        public string name;
        public float price;
        public string category;
        public string brandName;
        public string country;

        static void Main(string[] args)
        {
            products[] s = new products[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addProducts();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewProducts(s, count);
                }
                else if (option == '3')
                {
                    totalWorth(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }


            }
            while (option != '4');
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 for adding a Product: ");
            Console.WriteLine("Press2 for viewing products: ");
            Console.WriteLine("Press3 to view Total worth: ");
            Console.WriteLine("Press4 exit: ");
            choice = char.Parse(Console.ReadLine());
            return choice;


        }
        static products addProducts()
        {
            Console.Clear();
            products p1 = new products();
            Console.WriteLine("Enter product ID: ");
            p1.ID = Console.ReadLine();

            Console.WriteLine("Enter product Name: ");
            p1.name = Console.ReadLine();

            Console.WriteLine("Enter Product Price: ");
            p1.price = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Category: ");
            p1.category = Console.ReadLine();

            Console.WriteLine("Enter Brand Name: ");
            p1.brandName = Console.ReadLine();

            Console.WriteLine("Enter country: ");
            p1.country = Console.ReadLine();

            return p1;
        }

        static void viewProducts(products[] s, int count)
        {
            Console.Clear();
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Product ID: {0}  Name: {1} Price: {2} Category: {3} brand Name: {4}  Country: {5}", s[x].ID, s[x].name, s[x].price, s[x].category, s[x].brandName, s[x].country);
            }
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();

        }
        static void totalWorth(products[] p, int count)
        {
            float sum = 0F;
            for (int x = 0; x < count; x++)
            {
                sum = sum + p[x].price;
            }
            Console.WriteLine("Net Worth is: " + sum);
            Console.ReadKey();
        }
    }
}
