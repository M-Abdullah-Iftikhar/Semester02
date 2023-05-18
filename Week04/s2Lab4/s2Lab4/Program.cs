using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using s2Lab4.BL;

namespace s2Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            while (option != 9)
            {
                Console.Clear();
                 option = menu();



            }
            Console.WriteLine("Thank You for Using this Application");
            Console.ReadKey();
        }


        static int menu()
        {
            Console.WriteLine("1. to add Degree Program: ");
            Console.WriteLine("2. to add Subject");
            Console.WriteLine("3. to add student");
            Console.WriteLine("4. Generate Merit");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter 9 to exit");
            Console.ForegroundColor = ConsoleColor.White;
            int option = int.Parse(Console.ReadLine());

            return option;
        }
        static DegreeProgram addProgram()
        {


            Console.WriteLine("Enter Program Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Program Duration: ");
            int duration = int.Parse(Console.ReadLine());

            DegreeProgram obj = new DegreeProgram(title, duration);

            return obj;


        }

        static Student addStudent()
        {
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student fsc marks: ");
            float fsc = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat marks: ");
            float ecat = float.Parse(Console.ReadLine());

            Student obj = new Student(name, age, fsc, ecat);

            return obj;
        }

        static Subject addSubject()
        {
            Console.WriteLine("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Subject Type");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Credit Hours");
            int credit = int.Parse(Console.ReadLine());

            Subject obj = new Subject();
            obj.courseCode = code;
            obj.courseType = type;
            obj.creditHours = credit;

            return obj;

        }
    }
}