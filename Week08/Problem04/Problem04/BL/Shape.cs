using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04.BL
{
    class Shape
    {
        string shape;

        public Shape(string shape)
        {
            this.shape = shape;
        }

        public string getShape()
        {
            return shape;
        }
        public void setRadius(string shape)
        {
            this.shape = shape;
        }

        public virtual double getArea()
        {
            return 0.0F;
        }
    }
}
