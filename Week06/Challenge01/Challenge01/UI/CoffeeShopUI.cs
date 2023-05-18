using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge01.DL;
using Challenge01.BL;

namespace Challenge01.UI
{
    class CoffeeShopUI
    {
        public static void addOrder()
        {
            Console.WriteLine("Enter Order Name");
            string order = Console.ReadLine();

            bool check = CoffeeShop.isItemExist(order);
            if (check == false)
            {
                Console.WriteLine("This item i Currently Unavailable");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else if (check == true)
            {
                CoffeeShop.addOrderToList(order);

            }
        }

        public static string shopName()
        {
            Console.WriteLine("Enter Shop Name");
            string shopName = Console.ReadLine();

            return shopName;
        }

        public static void fullFillOrder()
        {
            int size = CoffeeShop.getOrderLength();
            if (size > 0)
            {
                for(int x = 0; x< size;x++)
                {
                    string name = CoffeeShop.getOrderNames(x);
                    Console.WriteLine("The " + name + " is Ready!");
                }
                CoffeeShop.makeOrderListEmpty();

            }
            else
            {
                Console.WriteLine("No Order is Available");
                
            }
        }
        public static void listOrders()
        {
            int size = CoffeeShop.getOrderLength();
            if (size > 0)
            {
                for (int x = 0; x < size; x++)
                {
                    string name = CoffeeShop.getOrderNames(x);
                    Console.WriteLine( name + " is Pending");
                }

            }
            else
            {
                Console.WriteLine("No Order is Available");

            }
        }

        public static void dueAmount()
        {
            float price = CoffeeShop.calculatePrice();

            Console.WriteLine("Total Amount of Orders is "+  price);
        }

        public static void cheapestItem()
        {
            MenuItem cheap = CoffeeShop.cheapest();
            Console.WriteLine("Cheapest Item is: " + cheap.itemName);
            Console.WriteLine("Cheapest Item price is: " + cheap.itemPrice);
        }

        public static void foodOnly()
        {
            int size = CoffeeShop.getMenuLegth();
            for(int x = 0;x < size; x++)
            {
                string food = CoffeeShop.getFood(x);
                if(food!=null)
                {
                    Console.WriteLine(food);
                }
               
            }
        }
        public static void drinksOnly()
        {
            int size = CoffeeShop.getMenuLegth();
            for (int x = 0; x < size; x++)
            {
                string drink = CoffeeShop.getDrink(x);
                if(drink != null)
                {
                    Console.WriteLine(drink);
                }
   
            }
        }

    }
}