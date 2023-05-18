using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTask01.BL
{
    public class Student
    {
        public Student(string name, int rollNo, int ecat)
        {
            this.name = name;
            this.rollNo = rollNo;
            this.ecat = ecat;
        }
        public string name;
        public int rollNo;
        public int ecat;
    }
}
