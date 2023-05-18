using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge01.BL;
using Challenge01.DL;
using Challenge01.UI;


namespace Challenge01
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string option = "";
            string shop = CoffeeShopUI.shopName();
            CoffeeShopDL.shopObject = new CoffeeShop(shop);
            while (option != "9")
            {
                Console.Clear();
                option = MenuItemUI.optionMenu();

                if (option == "1")
                {
                    CoffeeShop.addItemToMenu(MenuItemUI.addMenuItem());

                }
                else if (option == "2")
                {
                    CoffeeShopUI.addOrder();
                }
                else if (option == "3")
                {
                    CoffeeShopUI.fullFillOrder();
                }
                else if (option == "4")
                {
                    CoffeeShopUI.listOrders();
                }
                else if (option == "5")
                {
                    CoffeeShopUI.dueAmount();
                }
                else if (option == "6")
                {
                    CoffeeShopUI.cheapestItem();
                }
                else if (option == "7")
                {
                    CoffeeShopUI.drinksOnly();
                }
                else if (option == "8")
                {
                    CoffeeShopUI.foodOnly();
                }

                Console.ReadKey();
            }

        }
    }
}
