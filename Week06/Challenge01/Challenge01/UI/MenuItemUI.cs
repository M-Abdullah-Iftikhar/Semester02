using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge01.BL;
using Challenge01.DL;

namespace Challenge01.UI
{
    public class MenuItemUI
    {
        public static string optionMenu()
        {
            string choice = "";

            while (true)
            {


                Console.WriteLine("1. Add item to Menu");
                Console.WriteLine("2. place an order");
                Console.WriteLine("3. Order Status");
                Console.WriteLine("4. Show Order List");
                Console.WriteLine("5. View Due Amount");
                Console.WriteLine("6. View Cheepest Item");
                Console.WriteLine("7. View All Drinks");
                Console.WriteLine("8. View All Food Items");
                Console.WriteLine("9. Exit");
                choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7" || choice == "8" || choice == "9")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid option");
                    Console.WriteLine("Press any key to Continue");
                    Console.ReadKey();
                }


            }
            return choice;
        }

        

        public static MenuItem addMenuItem()
        {
            
            Console.WriteLine("Enter Name of Item");
            string itemName = Console.ReadLine();
            Console.WriteLine("Enter Type of item");
            string itemType = Console.ReadLine();

            Console.WriteLine("Enter Price of Item");
            float itemPrice = float.Parse(Console.ReadLine());

            MenuItem item = new MenuItem(itemName, itemType, itemPrice);

            return item;
        }



    }
}
