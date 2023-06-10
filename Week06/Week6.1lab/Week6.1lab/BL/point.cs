
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6._1lab.BL
{
    class point
    {
        public int x;
        public int y;
        public point()
        {

        }
        public point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
