using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BL
{
    class Products
    {
        
        public string name;
        public string category;
        public float price;
        public int quantity;
        public int minQuantity;

        public Products addProducts()
        {
            Console.Clear();
            Products p1 = new Products();

            Console.WriteLine("Enter product Name: ");
            p1.name = Console.ReadLine();

            Console.WriteLine("Enter Product Price: ");
            p1.price = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Category: ");
            p1.category = Console.ReadLine();

            Console.WriteLine("Enter quantity Present: ");
            p1.quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter country: ");
            p1.minQuantity = int.Parse(Console.ReadLine());

            return p1;
        }

        public int highestPrice(List<Products> p)
        {

            int y = 0;
            for (int x = 0; x < p.Count; x++)
            {
                if (x == 0)
                {
                    y = x;
                }
                else if (p[x].price > p[x - 1].price)
                {
                    y = x;
                }
            }
            return y;
        }

        public void viewProducts(List<Products> p)
        {
            Console.Clear();
            for (int x = 0; x < p.Count; x++)
            {
                Console.WriteLine("Name: {0}   Price: {1}    Category: {2}    Quantity: {3}   ThresHold Quantity: {4}", p[x].name, p[x].price, p[x].category, p[x].quantity, p[x].minQuantity);
            }
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();

        }

        public void salesTax(List<Products> p)
        {
            Console.Clear();
            for (int x = 0; x < p.Count; x++)
            {
                float salePrice = 0F;
                if (p[x].category == "fruit")
                {
                    salePrice = (p[x].price) - ((p[x].price) * 0.05F);
                }
                else if (p[x].category == "grocery")
                {
                    salePrice = (p[x].price) - ((p[x].price) * 0.1F);
                }
                else
                {
                    salePrice = (p[x].price) - ((p[x].price) * 0.15F);
                }
                Console.WriteLine("Name: {0}   Price after Discount: {1}    Category: {2}    Quantity: {3}   ThresHold Quantity: {4}", p[x].name, salePrice, p[x].category, p[x].quantity, p[x].minQuantity);
            }
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();
        }

        public void stockOrder(List<Products> p)
        {
            Console.Clear();

            bool check = false;

            Console.WriteLine("product(s) to be ordered are: ");
            for (int x = 0; x < p.Count; x++)
            {
                if (p[x].quantity < p[x].minQuantity)
                {
                    Console.WriteLine("Name: {0}   Price: {1}    Category: {2}    Quantity: {3}   ThresHold Quantity: {4}", p[x].name, p[x].price, p[x].category, p[x].quantity, p[x].minQuantity);
                    check = true;
                }
            }
            if (check == false)
            {
                Console.WriteLine("No products is to b ordered: ");
            }
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();
        }
    }
    
}
