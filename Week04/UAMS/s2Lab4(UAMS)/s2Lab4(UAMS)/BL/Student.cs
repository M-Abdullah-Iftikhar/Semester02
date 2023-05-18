using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2Lab4_UAMS_.BL
{
    public class Student
    {
        public Student(string name, int age, float fsc, float ecat,List<DegreeProgram> degreeProgramList)
        {
            this.name = name;
            this.age = age;
            this.FSc = fsc;
            this.Ecat = ecat;
            this.degreeProgramList = degreeProgramList;
        }
        public string name;
        public int age;
        public float FSc;
        public float Ecat;
        public bool registeredStudent;

        public List<DegreeProgram> degreeProgramList = new List<DegreeProgram>();
    
    }
}
