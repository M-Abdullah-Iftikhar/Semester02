using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using s2Lab4_UAMS_.BL;

namespace s2Lab4_UAMS_
{
    class Program
    {

        

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<DegreeProgram> degreeProgram = new List<DegreeProgram>();

            int option = 0;
            while (option != 9)
            {
                Console.Clear();
                option = menu();

                if(option == 1)
                {
                    students.Add(addStudent(degreeProgram));
                }
                else if (option == 2)
                {
                    degreeProgram.Add(addProgram());
                }
                else if(option == 3)
                {
                    generateMerit(students,degreeProgram);
                }
                else if(option == 4)
                {
                    registeredStudents(students);
                }
                else if(option ==5)
                {
                    specificDegree(students);
                }
                press();

            }
            Console.WriteLine("Thank You for Using this Application");
            Console.ReadKey();
        }

        static int menu()
        {
            Console.WriteLine("1. Add Student ");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a specific Program");
            Console.WriteLine("6. Register Subjects for a specific Student");
            Console.WriteLine("7. Calculate Fees For all registered Students");
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
            Console.WriteLine("Enter Available seats");
            int seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter merit");
            float merit = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter How many Subjects to Enter");
            int num = int.Parse(Console.ReadLine());

            List<Subject> subs = new List<Subject>();
            for(int x = 0;x<num;x++)
            {
                subs.Add(addSubject());
            }

            DegreeProgram obj = new DegreeProgram(title, duration,seats,merit,subs);

            press();
            return obj;


        }

        static Student addStudent(List<DegreeProgram> degreePrograms)
        {
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student fsc marks: ");
            float fsc = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat marks: ");
            float ecat = float.Parse(Console.ReadLine());

            Console.WriteLine("Available Programs");
            for(int x = 0;x < degreePrograms.Count;x++)
            {
                Console.WriteLine(degreePrograms[x].title);
            }

            Console.WriteLine("Enter How many Preferences to Enter ");
            int num = int.Parse(Console.ReadLine());

            List<DegreeProgram> degreeProgramsList = new List<DegreeProgram>();

            for(int x = 0;x<num;x++)
            {
                
                Console.Write("Enter Preference " + x + 1 + ": ");
                string preference = Console.ReadLine();
                DegreeProgram temp = new DegreeProgram(preference);

                degreeProgramsList.Add(temp);
            }

            Student obj = new Student(name, age, fsc, ecat,degreeProgramsList);
           

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
            Console.WriteLine("Enter Subject Fees");
            float fee = int.Parse(Console.ReadLine());


            Subject obj = new Subject();
            obj.courseCode = code;
            obj.courseType = type;
            obj.creditHours = credit;
            obj.subjectFee = fee;

            press();

            return obj;

        }

        static void generateMerit(List<Student> students,List<DegreeProgram> degreePrograms)
        {
            for(int x = 0;x<students.Count;x++)
            {
                for (int y = 0; y < students[x].degreeProgramList.Count; y++)
                {
                    bool check = checkMerit(students[x], students[x].degreeProgramList[y].merit);
                    if (check == true)
                    {
                        Console.WriteLine(students[x].name + " got Admission in " + students[x].degreeProgramList[y].title);
                        
                        students[x].degreeProgramList[y].registeredProgram = true;
                        break;
                    }
                    else
                    {
                        
                        Console.WriteLine(students[x].name + " did not get Admission ");
                        students[x].degreeProgramList[y].registeredProgram = false;
                    }
                }
            }
        }


        static bool checkMerit(Student students,float merit)
        {
            float merit1 = (((students.FSc / 1100) * 0.7F) + ((students.Ecat / 400) * 0.3F)) * 100;
            
            if(merit1 > merit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void registeredStudents(List<Student> students)
        {
            for(int x = 0;x<students.Count;x++)
            {
                for(int y = 0;y<students[x].degreeProgramList.Count;y++)
                if(students[x].degreeProgramList[y].registeredProgram == true)
                {
                    Console.WriteLine("Name \t\t FSC \t\t Ecat \t\t Age");
                    Console.WriteLine(students[x].name + " \t\t " + students[x].FSc + " \t\t " + students[x].Ecat + " \t\t " + students[x].age);
                }
            }
        }

        static void specificDegree(List<Student> students)
        {
          
        }

        static void press()
        {

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        
    }
}
