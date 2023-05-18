using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2Lab5_Tasks.BL
{
    public class Student
    {
        public Student(string name,int rollNo,int ecat)
        {
            this.name = name;
            this.rollNo = rollNo;
            this.ecat = ecat;
        }
        public Student ()
        {
            
        }
        public string name;
        public int rollNo;
        public int ecat;
        static List<Student> studentList = new List<Student>();

        static void addUser(Student students)
        {
            studentList.Add(students);

        }
    }
}
