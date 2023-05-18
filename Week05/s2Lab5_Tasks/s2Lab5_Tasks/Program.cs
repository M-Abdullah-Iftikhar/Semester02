using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using s2Lab5_Tasks.BL;

namespace s2Lab5_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of users to add: ");
            int num = int.Parse(Console.ReadLine());

           for(int x = 0;x < num;x++)
            {
                
            }
           


            Console.ReadKey();
        }


        public static Student takeInput()
        {
            
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter rollNo");
                int rollNo = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter ecat marks");
                int ecat = int.Parse(Console.ReadLine());

                Student students = new Student(name, rollNo, ecat);

            return students;
        }
    }
}
