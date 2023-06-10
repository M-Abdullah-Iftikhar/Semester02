using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.BL
{
    public class Bicycle
    {
        public Bicycle(int cadence, int gear, int speed)
        {
            this.cadence = cadence;
            this.gear = gear;
            this.speed = speed;

        }

        protected static List<string> records = new List<string>();
        protected int cadence;
        protected int gear;
        protected int speed;

        public void setCadence(int cadence)
        {
            this.cadence = cadence;
        }
        public void setGear(int gear)
        {

        }
        public void setSpeed(int speed)
        {

        }
        public int getSpeed()
        {
            return speed;
        }
        public void applyBreak(int decrement)
        {

        }

        public int getCadence()
        {
            return cadence;
        }




    }
}
