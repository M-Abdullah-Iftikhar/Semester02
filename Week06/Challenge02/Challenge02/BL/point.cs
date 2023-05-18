using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02.BL
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
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class boundry
    {
        public point topLeft ;
        public point topRight;
        public point bottomLeft;
        public point bottomRight;
        public boundry()
        {
            this.topLeft = new point(0,0);
            this.topRight = new point(0, 90);
            this.bottomLeft = new point(90, 0);
            this.bottomRight = new point(90, 90);
        }
        public boundry(point bottomleft, point bottomright, point topleft, point topright)
        {
            this.topLeft = topleft;
            this.topRight = topright;
            this.bottomLeft = bottomleft;
            this.bottomRight = bottomright;

        }
    }
    class gameObject
    {
        public char[,] shape ;
        public point startingP;
        public boundry premises;
        public string direction;
        public gameObject()
        {
            this.startingP.setXY(0, 0);
            this.premises.topLeft.setXY(0, 0);
            this.premises.topRight.setXY(0, 90);
            this.premises.bottomLeft.setXY(90, 0);
            this.premises.bottomRight.setXY(90, 90);
            this.direction = "lefttoright";
        }  
            public gameObject(char[,] shape, point startingP, boundry premises, string direction)
        {
            this.shape = shape;
            this.startingP = startingP;
            this.premises = premises;
            this.direction = direction;
        }
         
    }

}
