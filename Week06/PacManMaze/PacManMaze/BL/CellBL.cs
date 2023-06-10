using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManMaze.BL
{
    class CellBL
    {
        CellBL(char value, int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.value = value;
        }
        int X;
        int Y;
        char value;

        public char getValue()
        {
            return value;
        }
        public void setValue(char value)
        {
            this.value = value;
        }

        public int getX()
        {
            return X;
        }
        public void setX(int X)
        {
            this.X = X;
        }

        public int getY()
        {
            return Y;
        }
        public void setY(int Y)
        {
            this.Y = Y;
        }

    }
}
