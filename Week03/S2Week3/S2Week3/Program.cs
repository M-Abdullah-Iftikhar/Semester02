using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2Week3.BL;

namespace S2Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            //task1();
            //task2();
            //task3();
            //task4();
            task5();
            Console.ReadKey();
        }

        public static void task1()
            {
            taskClass stu = new taskClass("mughal", 32, 23.6F);


            Console.WriteLine(stu.name + " " + stu.rollNo + " " + stu.marks);

            taskClass stu2 = new taskClass("mughal", 35, 3.5F);


            Console.WriteLine(stu2.name + " " + stu2.rollNo + " " + stu2.marks);

        }

        public static void task2()
        {
            taskClass stu = new taskClass("God", 32, 23.6F);


            Console.WriteLine(stu.name + " " + stu.rollNo + " " + stu.marks);

            taskClass stu2 = new taskClass(stu);


            Console.WriteLine(stu2.name + " " + stu2.rollNo + " " + stu2.marks);

        }

        public static void task3()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            foreach(var x in numbers)
            {
                Console.WriteLine(x);
            }
            

        }

        public static void task4()
        {
            //default Constructor
            taskClass2 emptyTime = new taskClass2();
            Console.Write("Empty Time: ");
            emptyTime.printTime();

            //one parameter

            taskClass2 hourTime = new taskClass2(8);
            Console.Write("Hours Time: ");
            hourTime.printTime();

            //two parameter

            taskClass2 minTime = new taskClass2(8,10);
            Console.Write("Minute Time: ");
            minTime.printTime();

            //three parameter

            taskClass2 fullTime = new taskClass2(8,10,10);
            Console.Write("Full Time: ");
            fullTime.printTime();



            //add secsl
            fullTime.addsecs();
            Console.Write("Full Time: sec++ ");
            fullTime.printTime();


            //add hours

            fullTime.addhours();
            Console.Write("Full Time: hours++ ");
            fullTime.printTime();

            //add mins

            fullTime.addmins();
            Console.Write("Full Time: min++ ");
            fullTime.printTime();

            // check if Equal
            bool flag = fullTime.isEqual(9, 11, 11);
            Console.WriteLine("Flag: " + flag);

            // check if equal with object

            taskClass2 cmp = new taskClass2(10, 12, 1);
            flag = fullTime.isEqual(cmp);
            Console.WriteLine("Object Flag: " + flag);

        }

        public static void task5()
        {
            taskClass2 time = new taskClass2();
            taskClass2 time1 = new taskClass2();


            time.hours = 4;
            time.mins = 25;
            time.secs = 25;

           time1 = time.elapsedTime(time);

            Console.WriteLine(time1.hours + " " + time1.mins + " " + time1.secs);

            time1 = time.remainingTime(time);

            Console.WriteLine(time1.hours + " " + time1.mins + " " + time1.secs);

            time1 = time.apartTime(time);

            Console.WriteLine(time1.hours + " " + time1.mins + " " + time1.secs);
        }
    
    }
}
