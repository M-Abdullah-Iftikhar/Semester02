using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    class Student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;
        public List<degreeProgram> preferences;
        public List<Subject> registeredSubject;
        public degreeProgram registeredDegree;

        public Student(string name,int age, double fscMarks,double ecatMarks,List<degreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            registeredSubject = new List<Subject>();
        }

        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F)) *100;
        }

        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if(registeredDegree != null && registeredDegree.isSubjectExists(s) && stCH + s.creditHours <=9)
            {
                registeredSubject.Add(s);
                return true;
            }
            return false;
        }

        public int getCreditHours()
        {
            int count = 0;
            foreach(Subject sub in registeredSubject)
            {
                count = count + sub.creditHours;
            }
            return count;
        }

        public float calculateFee()
        {
            float fee = 0;
            if(registeredDegree != null)
            {
                foreach(Subject sub in registeredSubject)
                {
                    fee = fee + sub.subjectFees;
                }
            }
            return fee;
        }
    }
}
