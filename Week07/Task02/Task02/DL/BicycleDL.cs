using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.BL;

namespace Task02.DL
{
    class BicycleDL
    {
        private List<Bicycle> Bicycles = new List<Bicycle>();

        public int getSpeed(int x)
        {
            return Bicycles[x].getSpeed();
        }

    }

}
