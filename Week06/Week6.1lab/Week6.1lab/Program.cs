using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6._1lab.BL;
using System.Threading;

namespace Week6._1lab
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] gameobj = new char[5, 3] { { '*', ' ', ' ' }, { '*', '*', ' ' }, { '*', '*', '*' }, { '*', '*', ' ' }, { '*', ' ', ' ' }};
            char[,] gameobj1 = new char[5, 3] { { ' ', ' ', '*' }, { ' ', '*', '*' }, { '*', '*', '*' }, { ' ', '*', '*' }, { ' ', ' ', '*' }};
            char[,] gameobj3 = new char[5, 3] { { '*', ' ', ' ' }, { '*', '*', ' ' }, { '*', '*', '*' }, { '*', '*', ' ' }, { '*', ' ', ' ' } };
            Boundary b = new Boundary(new point(0, 0), new point(0, 90), new point(90, 0), new point(90, 90));
            GameObject g1 = new GameObject(gameobj, new point(10, 5), "left", b);
            GameObject g2 = new GameObject(gameobj1, new point(80, 10), "right", b);
            GameObject g3 = new GameObject(gameobj3, new point(80, 20), "right", b);
            GameObject g4 = new GameObject(gameobj3, new point(85, 85), "diagonal", b);
            GameObject g5 = new GameObject(gameobj3, new point(40, 15), "projectile", b);
            List<GameObject> obj = new List<GameObject>();
            //obj.Add(g1);
            //obj.Add(g2);
            //obj.Add(g3);
            //obj.Add(g4);
            obj.Add(g5);
            while (true)
            {
                Thread.Sleep(1000);
                foreach(GameObject g in obj)
                {
                    g.erase();
                   //g.move();
                    //g.move1();
                   // g.move2();
                 //  g.move3();
                   g.move4();
                    g.shapeprint();
                }
               
            }            
        }
    }
}