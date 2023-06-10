using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04.BL
{
    class Circle : Shape
    {
        double radius;

        public Circle(string shape,double radius):base(shape)
        {
            this.radius = radius;
        }

        public double getRadius()
        {
            return radius;
        }
        public void setRadius(double radius)
        {
            this.radius = radius;
        }

        public override double getArea()
        {
            return 3.14F * radius * radius;
        }


    }
}
