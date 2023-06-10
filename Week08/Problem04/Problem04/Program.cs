using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem04.BL;

namespace Problem04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Console.Write("Enter Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter Height: ");
            double height = double.Parse(Console.ReadLine());
            Rectangle r1 = new Rectangle("Rectangle", width, height);



            Console.Write("Enter Radius: ");
            double radius = double.Parse(Console.ReadLine());
            Circle c1 = new Circle("Circle", radius);


            Console.Write("Enter Side: ");
            double side = double.Parse(Console.ReadLine());
            Square s1 = new Square("Square", side);



            Console.Write("Enter Width: ");
            double width2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Height: ");
            double height2 = double.Parse(Console.ReadLine());
            Rectangle r2 = new Rectangle("Rectangle", width2, height2);



            Console.Write("Enter Radius: ");
            double radius2 = double.Parse(Console.ReadLine());
            Circle c2 = new Circle("Circle", radius2);


            shapes.Add(r1);
            shapes.Add(c1);
            shapes.Add(s1);
            shapes.Add(r2);
            shapes.Add(c2);

            foreach(Shape s in shapes)
            {
                Console.WriteLine("The Shape is " + s.getShape() + " & its Area is " + s.getArea());
            }

            Console.ReadKey();

        }
    }
}
