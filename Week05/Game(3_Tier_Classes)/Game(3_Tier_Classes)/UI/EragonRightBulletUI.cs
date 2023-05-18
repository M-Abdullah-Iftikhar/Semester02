using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.DL;

namespace Game_3_Tier_Classes_.UI
{
    class EragonRightBulletUI
    {
        public static void eraseEragonBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            GameDL.setCharOnMaze(x, y, ' ');
            Console.WriteLine(" ");
        }
        public static void printEragonBullet(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            GameDL.setCharOnMaze(x, y, '.');
            Console.WriteLine(".");
        }
        public static void eragonMoveBullet()
        {
            int size = EragonRightBulletDL.getEragonRightBulletListSize();
            for (int x = 0; x < size; x++)
            {
                EragonRightBulletBL eragonRightBullet = EragonRightBulletDL.getEragonRightBulletObject(x);
                if (eragonRightBullet.eragonRightBulletActive == true)
                {
                    char next = GameDL.getCharFromMaze(eragonRightBullet.eragonBulletX + 1, eragonRightBullet.eragonBulletY);

                    if (next != ' ')
                    {
                        eraseEragonBullet(eragonRightBullet.eragonBulletX, eragonRightBullet.eragonBulletY);
                        eragonRightBullet.eragonRightBulletActive = false;
                        EragonRightBulletDL.deleteEragonRightBullet(x);
                        size = EragonRightBulletDL.getEragonRightBulletListSize();
                    }
                    else if (next == ' ')
                    {
                        eraseEragonBullet(eragonRightBullet.eragonBulletX, eragonRightBullet.eragonBulletY);
                        EragonRightBulletDL.setEragonRightBulletX(x, (eragonRightBullet.eragonBulletX + 1));
                        printEragonBullet(eragonRightBullet.eragonBulletX, eragonRightBullet.eragonBulletY);
                    }
                }
            }
        }

    }
}
