using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.DL;

namespace Game_3_Tier_Classes_.UI
{
    class DracoUI
    {

       
        public static void dracoMove()
        {
            int dracoX = DracoDL.getDracoX();
            int dracoY = DracoDL.getDracoY();
            int dracoSpeed = DracoDL.getDracoSpeed();
            int eragonX = EragonDL.getEragonX();
            int eragonY = EragonDL.getEragonY();

            if (dracoSpeed % 3 == 0)
            {
                if (dracoX > eragonX)
                {

                    char next1 = GameDL.getCharFromMaze(dracoX - 1, dracoY);
                    char next2 = GameDL.getCharFromMaze(dracoX - 1, dracoY + 1);
                    char next3 = GameDL.getCharFromMaze(dracoX - 1, dracoY + 2);
                   

                    if (next1 == ' ' && next2 == ' ' && next3 == ' ')
                    {
                        moveLeftDraco(dracoX, dracoY);
                    }
                }
                if (dracoX < eragonX)
                {
                    char next1 = GameDL.getCharFromMaze(dracoX + 2, dracoY);
                    char next2 = GameDL.getCharFromMaze(dracoX + 2, dracoY + 1);
                    char next3 = GameDL.getCharFromMaze(dracoX + 2, dracoY + 2);
                    

                    if (next1 == ' ' && next2 == ' ' && next3 == ' ')
                    {
                        moveRightDraco(dracoX, dracoY);
                    }
                }
                if (dracoY < eragonY)
                {
                    char next1 = GameDL.getCharFromMaze(dracoX , dracoY + 3);
                    char next2 = GameDL.getCharFromMaze(dracoX + 1, dracoY + 3);
                    
                    if (next1 == ' ' && next2 == ' ')
                    {
                        moveDownDraco(dracoX,dracoY);
                    }
                }
                if (dracoY > eragonY)
                {
                    char next1 = GameDL.getCharFromMaze(dracoX, dracoY - 1);
                    char next2 = GameDL.getCharFromMaze(dracoX + 1, dracoY - 1);

                    if (next1 == ' ' && next2 == ' ')
                    {
                        moveUpDraco(dracoX, dracoY);
                    }
                }
            }
            DracoDL.setDracoSpeed(dracoSpeed + 1);
        }
        public static void moveLeftDraco(int dracoX,int dracoY)
        {
            eraseDraco();
            DracoDL.setDracoX(dracoX - 1);
            printDraco();
        }
        public static void moveRightDraco(int dracoX, int dracoY)
        {
            eraseDraco();
            DracoDL.setDracoX(dracoX + 1);
            printDraco();
        }
        public static void moveUpDraco(int dracoX, int dracoY)
        {
            eraseDraco();
            DracoDL.setDracoY(dracoY - 1);
            printDraco();
        }
        public static void moveDownDraco(int dracoX, int dracoY)
        {
            eraseDraco();
            DracoDL.setDracoY(dracoY + 1);
            printDraco();
        }

        public static void eraseDraco()
        {
            int dracoX = DracoDL.getDracoX();
            int dracoY = DracoDL.getDracoY();

            for (int x = 0; x < 3; x++)
            {

                for (int y = 0; y < 2; y++)
                {
                    Console.SetCursorPosition(dracoX + y, dracoY + x);
                    GameDL.setCharOnMaze(dracoX + y, dracoY + x, ' ');
                    Console.WriteLine(" ");
                }
            }
        }
        public static void printDraco()
        {
            int dracoX = DracoDL.getDracoX();
            int dracoY = DracoDL.getDracoY();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            char top = (char)246;
            char middle1 = (char)166, middle2 = (char)45;
            char bottom = (char)127;

            char[,] draco = {
                { ' ', top},
                        { middle2, middle1},
                        { ' ', bottom}
            };

            for (int x = 0; x < 3; x++)
            {

                for (int y = 0; y < 2; y++)
                {
                    Console.SetCursorPosition(dracoX + y, dracoY + x);
                    GameDL.setCharOnMaze(dracoX + y, dracoY + x, draco[x, y]);
                    Console.WriteLine(draco[x, y]);
                }
            }
        }

        public static void dracoGenerateBullet()
        {
            int dracoX = DracoDL.getDracoX();
            int dracoY = DracoDL.getDracoY();
            int dracoShotSpeed = DracoDL.getDracoShotSpeed();

            Console.ForegroundColor = ConsoleColor.Yellow;
            
            char next = GameDL.getCharFromMaze(dracoX - 1, dracoY + 1);

            if (next == ' ')
            {
                if (dracoShotSpeed % 6 == 0)
                {
                    int dracoBulletX = dracoX - 1;
                    int dracoBulletY = dracoY + 1;
                    bool dracoLeftBulletActive = true;

                    DracoLeftBulletBL dracoLeftBullet = new DracoLeftBulletBL(dracoBulletX, dracoBulletY, dracoLeftBulletActive);
                    
                    DracoLeftBulletDL.addDracoLeftBulletToList(dracoLeftBullet);

                    Console.SetCursorPosition(dracoBulletX, dracoBulletY );
                    GameDL.setCharOnMaze(dracoBulletX, dracoBulletY, '.');

                    Console.WriteLine(".");

                }
                DracoDL.setDracoShotSpeed(dracoShotSpeed + 1);
                
            }
        }
        

        public static void dracoCollision()
        {
            int size = EragonRightBulletDL.getEragonRightBulletListSize();
            for (int x = 0; x < size; x++)
            {
                int dracoX = DracoDL.getDracoX();
                int dracoY = DracoDL.getDracoY();

                EragonRightBulletBL eragonRightBullet = EragonRightBulletDL.getEragonRightBulletObject(x);

                if (eragonRightBullet.eragonRightBulletActive == true)
                {
                    if (eragonRightBullet.eragonBulletX + 1 == dracoX && (eragonRightBullet.eragonBulletY == dracoY || eragonRightBullet.eragonBulletY == dracoY + 1 || eragonRightBullet.eragonBulletY == dracoY + 2))
                    {
                        EragonDL.increaseEragonScore(1);
                        DracoDL.decreaseDracoHealth(1);
                        
                    }
                }
            }

        }
        public static void printDracoHealth()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int dracoHealth = DracoDL.getDracoHealth();
            Console.SetCursorPosition(113, 11);
            Console.WriteLine("Draco Health is: " + dracoHealth);


        }
       

    }
}
