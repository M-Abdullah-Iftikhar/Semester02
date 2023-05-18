using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge01.UI;


namespace Challenge01.BL
{
    class CoffeeShop
    {
        public CoffeeShop(string coffeeName)
        {
            this.coffeeName = coffeeName;
            orders = new List<string>();

        }

       public CoffeeShop()
        {

        }
        public string coffeeName;
        public static List<MenuItem> menu = new List<MenuItem>();
        public static List<string> orders;

        public static void addOrderToList(string s)
        {
            orders.Add(s);
        }

        public static void addItemToMenu(MenuItem item)
        {
            menu.Add(item);
        }

        public static bool isItemExist(string itemName)
        {
            foreach (MenuItem s in menu)
            {
                if (s.itemName == itemName)
                {
                    return true;
                }
            }
            return false;
        }

        public static int getOrderLength()
        {
            return orders.Count;
        }
        public static string getOrderNames(int x)
        {
            return orders[x];
        }

        public static float calculatePrice()
        {
            float price = 0;
            for(int x = 0;x < orders.Count;x++)
            {
                for(int y = 0;y<menu.Count;y++)
                {
                    if(orders[x] == menu[y].itemName)
                    {
                        price = price + menu[y].itemPrice;
                    }
                }
            }
            return price;
        }

        public static MenuItem cheapest()
        {

            float cheap = 0;
            int y = -1;
            for(int x = 0;x < menu.Count;x++)
            {
                
                if(x== 0)
                {
                    cheap = menu[x].itemPrice;
                }
                else if(cheap > menu[x].itemPrice)
                {
                    cheap = menu[x].itemPrice;
                    y = x;
                }

            }
            return menu[y];
        }

        public static int getMenuLegth()
        {
            return menu.Count;
        }

        public static string getFood(int x)
        {
            if(menu[x].itemType == "Food")
            {
                return menu[x].itemName;
            }
            return null;
        }

        public static string getDrink(int x)
        {
            if (menu[x].itemType == "Drink")
            {
                return menu[x].itemName;
            }
            return null;
        }

        public static void makeOrderListEmpty()
        {
            orders.Clear();
        }
    }
}
