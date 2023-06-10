using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04.BL
{
    class Square : Shape
    {
        double side;

        public Square(string shape, double side) : base(shape)
        {
            this.side = side;
        }
        public double getSide()
        {
            return side;
        }
        public void setRadius(double side)
        {
            this.side = side;
        }
        public override double getArea()
        {
            return side*side;
        }
    }
}
