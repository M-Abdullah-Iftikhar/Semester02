using Challenge02.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge02.UI
{
    class MuserCRUD
    {
        public static void draw(gameObject g)
        {
            for (int col = 0; col < 5 ; col++)
            {
                for (int row =0 ; row < 3; row++)
                {
                    Console.SetCursorPosition(g.startingP.x,g.startingP.y);
                    Console.Write(g.shape[col,row]);
                    
                }
                Console.SetCursorPosition(g.startingP.x, g.startingP.y+1);
            }
        }

    }
}
