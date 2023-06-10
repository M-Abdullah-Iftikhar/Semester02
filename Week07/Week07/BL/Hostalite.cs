using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week07.BL
{
    class Hostalite : Student
    {

        public Hostalite (string name,string session,bool isDayScholar,float entryTestMarks,float HSMarks, int roomNumber,bool isFridgeAvailable,bool isNetAvailable) : base (name,session,isDayScholar,entryTestMarks,HSMarks)
        {
            this.roomNumber = roomNumber;
            this.isFridgeAvailable = isFridgeAvailable;
            this.isNetAvailable = isNetAvailable;


        }

        public int roomNumber;
        public bool isFridgeAvailable;
        public bool isNetAvailable;
        public int getHostalFee()
        {
            int fee = 0;
            return fee;
        }

    }
}
