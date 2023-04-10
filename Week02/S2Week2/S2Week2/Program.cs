using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Week2
{
    class Program
    {
        class students
        {
            public string name;
            public int rollNo;
            public float cgpa;
        }
        static void Main(string[] args)
        {

            w2Task1();
            Console.Read();
        }
        public static void w2Task1()
            {
            //first object
            students s1 = new students();
        Console.WriteLine("Enter Name of Student 1");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter RollNo of Student 1");
            s1.rollNo = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter cgpa of Student 1");
            s1.cgpa = float.Parse(Console.ReadLine());

        Console.WriteLine("Name: {0}  Roll No: {1} CGPA: {2}", s1.name, s1.rollNo, s1.cgpa);
            //2nd object
            students s2 = new students();
        s2.name = "bilal";
            s2.rollNo = 23;
            s2.cgpa = 3.15F;
            Console.WriteLine("Name: {0}  Roll No: {1} CGPA: {2}", s2.name, s2.rollNo, s2.cgpa);

            }

}
}
