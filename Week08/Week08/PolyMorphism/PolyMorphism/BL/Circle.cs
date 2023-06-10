using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorphism.BL
{
    class Circle
    {
        protected double radius = 1.0F;
        protected string color = "Red";
        public Circle()
        {

        }
        public  Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }

        public double getRadius()
        {
            return radius;
        }
        public void setRadius(double radius)
        {
            this.radius = radius;
        }
        public string getColor()
        {
            return color;
        }
        public void setColor(string color)
        {
            this.color = color;
        }

        public double getArea()
        {
            double area = 2 * 3.14F * radius;
            return area;
        }

        public string toString()
        {
            return " Color: " + color + "Radius" + radius;
        }

    }
}
