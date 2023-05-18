using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2Lab4_UAMS_.BL
{
    public class DegreeProgram
    {
        public DegreeProgram(string title, int duration,int seats,float merit,List<Subject> subjects)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
            this.merit = merit;
            this.subjects = subjects;
        }
        public DegreeProgram(string title)
        {
            this.title = title;
        }
        public string title;
        public int duration;
        public int seats;
        public float merit;
        public bool registeredProgram;

        public List<Subject> subjects = new List<Subject>();
    }
}
