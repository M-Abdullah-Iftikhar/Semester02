using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using s2Week2._1.BL;

namespace Test.BL
{
    class program
    {
        


        static void Main(string[] args)
        {
            students[] s = new students[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewStudents(s, count);
                }
                else if (option == '3')
                {
                    topStudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }


            }
            while (option != '4');
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 for adding a Student: ");
            Console.WriteLine("Press2 for viewing a Student: ");
            Console.WriteLine("Press3 for top 3 Students: ");
            Console.WriteLine("Press4 exit: ");
            choice = char.Parse(Console.ReadLine());
            return choice;


        }
        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.WriteLine("Enter Name: ");
            s1.name = Console.ReadLine();

            Console.WriteLine("Enter Roll No: ");
            s1.rollNo =int.Parse(Console.ReadLine());

            Console.WriteLine("Enter CGPA: ");
            s1.cgpa =float.Parse( Console.ReadLine());

            Console.WriteLine("Enter Department: ");
            s1.department = Console.ReadLine();

            Console.WriteLine("isHostalide(y/n): ");
            s1.isHostalide =char.Parse( Console.ReadLine());

            return s1;
        }

        static void viewStudents(students[] s, int count)
        {
            Console.Clear();
            for(int x = 0;x<count;x++)
            {
                Console.WriteLine("Name: {0}  RollNo: {1} CGPA: {2} Department: {3} isHostalide: {4}", s[x].name,s[x].rollNo,s[x].cgpa,s[x].department,s[x].isHostalide);
            }
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();
            
        }
        static void topStudent(students[] s, int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if(count == 1)
            {
                viewStudents(s, 1);
            }
            else if(count == 2)
            {
                for (int x = 0;x<2;x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudents(s, 2);
            }
            else
            {
                for(int x = 0;x<3;x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudents(s, 3);
            }
            Console.WriteLine("Press Enter to Exit..");
            Console.ReadKey();
        }

        static int largest(students[] s,int start,int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int x = 0;x<end;x++)
            {
                if(large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }

    }




}