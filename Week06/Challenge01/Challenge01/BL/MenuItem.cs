using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge01.BL
{
    public class MenuItem
    {

        public MenuItem(string itemName,string itemType,float itemPrice)
        {
            this.itemName = itemName;
            this.itemType = itemType;
            this.itemPrice = itemPrice;
        }
        public MenuItem()
        {

        }
        public string itemName;
        public string itemType;
        public float itemPrice;

    }
}
