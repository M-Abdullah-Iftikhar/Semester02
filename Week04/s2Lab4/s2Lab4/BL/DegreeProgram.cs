using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2Lab4.BL
{
   public class DegreeProgram
    {
        public DegreeProgram (string title,int duration)
        {
            this.title = title;
            this.duration = duration;
        }
        public string title;
        public int duration;

        public List<Subject> subjects = new List<Subject>();
    }
}
