using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    class degreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects;
        public int seats;

        public degreeProgram(string degreeName,float degreeDuration,int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }

        public int calculateCreditHours()
        {
            int count = 0;
            for(int x = 0;x<subjects.Count;x++)
            {
                count = count + subjects[x].creditHours;
            }
            return count;
        }

        public bool addSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isSubjectExists(Subject sub)
        {
            foreach(Subject s in subjects)
            {
                if(s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
