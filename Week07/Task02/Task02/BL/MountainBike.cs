using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.BL
{
    class MountainBike : Bicycle
    {
        private int seaHeight;

        public MountainBike(int seaHeight,int cadence,int speed,int gear) : base(cadence,speed,gear)
        {
            this.seaHeight = seaHeight;

        }

        public void setSeaHeight(int seaHeight)
        {
            this.seaHeight = seaHeight;
        }
        public int getheight()
        {
            return seaHeight;
        }
    }
}
