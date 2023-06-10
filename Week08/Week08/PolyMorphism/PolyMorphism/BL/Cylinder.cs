using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorphism.BL
{
    class Cylinder : Circle
    {
        private double height = 2.0F;
        public Cylinder()
        {
            this.height = 3.0F;
        }
        public Cylinder(double radius):base(radius)
        {

        }
        public Cylinder(double radius, double height):base(radius)
        {
            this.height = height;
        }
        public Cylinder(double radius, double height,string color) : base(radius,color) 
        {
            this.height = height;
        }

        public double getHeight()
        {
            return height;
        }
        public void setHeight(double height)
        {
            this.height = height;
        }

        public double getVolume()
        {
            double volume = 3.14F * radius * radius * height;

            return volume;
        }
        public string toString()
        {
            return " Color: " + color + "::Radius: " + radius + "::Height: " + height;
        }


    }
}
