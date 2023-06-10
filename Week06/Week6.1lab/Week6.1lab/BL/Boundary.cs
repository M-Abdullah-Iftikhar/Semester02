using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6._1lab.BL
{
    class Boundary
    {
        public point topleft;
        public point topright;
        public point bottomleft;
        public point bottomright;
        public Boundary()
        {
           this. bottomleft.setXY (90, 0);
           this. bottomright.setXY (90, 90);
           this. topleft.setXY (0, 0);
           this. topright.setXY (0, 90);
        }
        public Boundary(point bottomleft,point bottomright, point topleft, point topright)
        {
            this.topleft=topleft;
            this.topright=topright;
            this.bottomleft = bottomleft;
            this.bottomright = bottomright;

        }
    }
}
