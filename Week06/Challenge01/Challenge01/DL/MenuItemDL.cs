using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge01.BL;


namespace Challenge01.DL
{
    class MenuItemDL
    {
        static List<MenuItem> itemList = new List<MenuItem>();

        public static void addItemToList(MenuItem item)
        {
            itemList.Add(item);
        }

       
    }
}
