using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04.BL
{
    class Rectangle : Shape
    {
        double length;
        double height;


        public Rectangle(string shape, double length,double height) : base(shape)
        {
            this.length = length;
            this.height = height;
        }
        public double getLength()
        {
            return length;
        }
        public void setRadius(double length)
        {
            this.length = length;
        }
        public double getHeight()
        {
            return height;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }

        public override double getArea()
        {
            return length * height;
        }
    }
}
