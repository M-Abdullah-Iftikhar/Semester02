using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week07.BL
{
    class DayScholar : Student
    {

       public  DayScholar (string name, string session, bool isDayScholar, float entryTestMarks, float HSMarks, string pickupPoint,int busNo,int pickupDistance) : base (name, session, isDayScholar, entryTestMarks, HSMarks)
        {
            this.pickupPoint = pickupPoint;
            this.busNo = busNo;
            this.pickupDistance = pickupDistance;
            


        }
        public string pickupPoint;
        public int busNo;
        public float pickupDistance;


        public int getBusFee()
        {
            int fee = 0;

            return fee;
        }
    }
}
