using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week07.BL
{
    class Student
    {
        Student(string name, string session, bool isDayScholar, float entryTestMarks, float HSMarks) : base(name, session, isDayScholar, entryTestMarks, HSMarks)
        {
            this.name = name;
            this.session = session;
            this.isDayScholar = isDayScholar;
            this.entryTestMarks = entryTestMarks;
            this.HSMarks = HSMarks;

        }
        public string name;
        public string session;
        public bool isDayScholar;
        public float entryTestMarks;
        public float HSMarks;

        public double calculateMerit()
        {
            double merit = 0.0;

            return merit;
        }
    }


}
