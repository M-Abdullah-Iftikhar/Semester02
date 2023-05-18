using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.DL;

namespace Game_3_Tier_Classes_.UI
{
    class DracoLeftBulletUI
    {
        public static void eraseDracoBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            GameDL.setCharOnMaze(x, y, ' ');
            Console.WriteLine(" ");
        }
        public static void printDracoBullet(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            GameDL.setCharOnMaze(x, y, '.');
            Console.WriteLine(".");
        }
        public static void dracoMoveBullet()
        {
            int size = DracoLeftBulletDL.getDracoLeftBulletListSize();
            for (int x = 0; x < size; x++)
            {
                
                DracoLeftBulletBL dracoLeftBullet = DracoLeftBulletDL.getDracoLeftBulletObject(x);
                if (dracoLeftBullet.dracoLeftBulletActive == true)
                {
                    char next = GameDL.getCharFromMaze(dracoLeftBullet.dracoBulletX - 1, dracoLeftBullet.dracoBulletY);


                    if (next != ' ')
                    {

                        eraseDracoBullet(dracoLeftBullet.dracoBulletX, dracoLeftBullet.dracoBulletY);
                        dracoLeftBullet.dracoLeftBulletActive = false;
                        DracoLeftBulletDL.deleteDracoLeftBullet(x);
                        size = DracoLeftBulletDL.getDracoLeftBulletListSize();

                    }
                    else if (next == ' ')
                    {
                        eraseDracoBullet(dracoLeftBullet.dracoBulletX, dracoLeftBullet.dracoBulletY);
                        DracoLeftBulletDL.setDracoLeftBulletX(x, dracoLeftBullet.dracoBulletX - 1);
                        printDracoBullet(dracoLeftBullet.dracoBulletX, dracoLeftBullet.dracoBulletY);
                    }
                }
            }
        }
    }
}
