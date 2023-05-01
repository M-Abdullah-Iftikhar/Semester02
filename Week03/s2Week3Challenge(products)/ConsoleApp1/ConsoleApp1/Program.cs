using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.BL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Products> p = new List<Products>();
            char option;

            do
            {
                option = menu();
                if (option == '1')
                {
                    Products p1 = new Products();

                    p1 = p1.addProducts();
                    p.Add(p1);

                }
                else if (option == '2')
                {
                    Products p1 = new Products();
                    p1.viewProducts(p);
                }
                else if (option == '3')
                {
                    Products p1 = new Products();
                    int x = p1.highestPrice(p);
                    Console.WriteLine("Name: {0}   Price: {1}    Category: {2}    Quantity: {3}   ThresHold Quantity: {4}", p[x].name, p[x].price, p[x].category, p[x].quantity, p[x].minQuantity);
                    Console.WriteLine("Press Enter to Exit..");
                    Console.ReadKey();

                }
                else if (option == '4')
                {
                    Products p1 = new Products();
                    p1.salesTax(p);
                }
                else if (option == '5')
                {
                    Products p1 = new Products();
                    p1.stockOrder(p);
                }
                else if (option == '6')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }


            }
            while (option != '6');
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 for adding a Product: ");
            Console.WriteLine("Press2 for viewing products: ");
            Console.WriteLine("Press3 to view product with highest price: ");
            Console.WriteLine("Press4 to view sale Price: ");
            Console.WriteLine("Press5 to view products to be ordered: ");
            Console.WriteLine("Press6 exit: ");
            choice = char.Parse(Console.ReadLine());
            return choice;


        }
        

        
        
        
    }
}
