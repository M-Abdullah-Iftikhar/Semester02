using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2Lab4.BL
{
    public class Student
    {
        public Student(string name,int age,float fsc,float ecat)
        {
            this.name = name;
            this.age = age;
            this.FSc = fsc;
            this.Ecat = ecat;
        }
        public string name;
        public int age;
        public float FSc;
        public float Ecat;

        public List<DegreeProgram> degreeProgramList = new List<DegreeProgram>();
    }
}
