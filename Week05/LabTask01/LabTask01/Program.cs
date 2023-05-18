using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabTask01.BL;

namespace LabTask01
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Ahmad", 15, 120);
            Student s2 = new Student("Hassan", 11, 115);
            Student s3 = new Student("Ali", 13, 250);

            List<Student> studentList = new List<Student>() { s1, s2, s3 };

            List<Student> sortedList = studentList.OrderBy(o => o.rollNo).ToList();
            foreach(Student s in sortedList)
            {
                Console.WriteLine("{0} \t {1} \t \t {2}", s.name, s.rollNo, s.ecat);
            }
           

            Console.WriteLine("-----------------------");
            self_1a();

            Console.WriteLine("-------------------------");
            self_a2();

            Console.ReadKey();
        }

        public static void self_1a()
        {
            List<string> strList = new List<string>();

            Console.WriteLine("Enter a Number");
            int num = int.Parse(Console.ReadLine());
            for(int x = 0;x<num;x++)
            {
                Console.WriteLine("Enter a string");
                strList.Add(Console.ReadLine());
            }

            strList.Sort();
            foreach(string a in strList)
            {
                Console.WriteLine(a);
            }
        }

        public static void self_a2()
        {
            List<float> fltList = new List<float>();

            Console.WriteLine("Enter a Number");
            int num = int.Parse(Console.ReadLine());
            for (int x = 0; x < num; x++)
            {
                Console.WriteLine("Enter a floating point");
                fltList.Add(float.Parse(Console.ReadLine()));
            }

            fltList.Sort();
            foreach (float a in fltList)
            {
                Console.WriteLine(a);
            }
        }


    }
}

