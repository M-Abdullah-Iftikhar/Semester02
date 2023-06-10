using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem04.BL;

namespace Problem04.UI
{
    class RectangleUI
    {
        public static Rectangle GetRectangleObj()
        {
            Console.Write("Enter Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter Height: ");
            double height = double.Parse(Console.ReadLine());
            Rectangle r = new Rectangle("Rectangle", width, height);

            return r;

        }

    }
}
