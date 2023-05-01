using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Week3.BL
{
    class taskClass
    {
        public taskClass(taskClass stu)
        {
            name = stu.name;
            rollNo = stu.rollNo;

            marks = stu.marks;
        }
        public taskClass(string name_,int rollNo_,float marks_)
        {
            name = name_;
            rollNo = rollNo_;
            marks = marks_;

        }
        public string name;
        public int rollNo;
        public float marks;
    }
}
