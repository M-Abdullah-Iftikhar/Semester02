using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Week3.BL
{
    class taskClass2
    {

        public int hours;
        public int mins;
        public int secs;
        public taskClass2()
        {
            hours = 0;
            mins = 0;
            secs = 0;

        }
        public taskClass2(int h)
        {
            hours = h;
            

        }
        public taskClass2(int h,int m)
        {
            hours = h;
            mins = m;
            secs = 0;

        }
        public taskClass2(int h,int m,int s)
        {
            hours = h;
            mins = m;
            secs = s;

        }

        

        public void addsecs()
        {
            secs++;
        }
        public void addmins()
        {
            mins++;
        }
        public void addhours()
        {
            hours++;
        }


        public void printTime()
        {
            Console.WriteLine(hours + " " + mins + " " + secs);
        }
        public bool isEqual(int h ,int m, int s)
        {
            if(hours == h && mins == m && secs == s)
            {
                return true;
            }
            return false;
        }
        public bool isEqual(taskClass2 temp)
        {
            if (hours == temp.hours && mins == temp.mins && secs == temp.secs)
            {
                return true;
            }
            return false;

        }
        public taskClass2 elapsedTime(taskClass2 time)
        {
            taskClass2 time1 = new taskClass2();

            time1.hours = time.hours - 0;
            time1.mins = time.mins - 0;
            time1.secs = time.secs - 0;

            return time1;

        }

        public taskClass2 remainingTime(taskClass2 time)
        {
            taskClass2 time1 = new taskClass2();

            time1.hours = 24 - time.hours;
            time1.mins = 60 - time.mins;
            time1.secs = 60 - time.secs;

            return time1;

        }

        public taskClass2 apartTime(taskClass2 time)
        {
            taskClass2 time1 = new taskClass2();

            
            time1.hours = 24 - time.hours;
            time1.mins = 60 - time.mins;
            time1.secs = 60 - time.secs;

            time1.hours = time1.hours - time.hours;
            time1.mins = time1.mins - time.mins;
            time1.secs = time1.secs - time.secs;


            return time1;

        }

    }
}
