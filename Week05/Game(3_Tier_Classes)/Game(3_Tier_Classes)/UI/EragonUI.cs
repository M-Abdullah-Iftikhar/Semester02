 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.DL;
using EZInput;

namespace Game_3_Tier_Classes_.UI
{
    class EragonUI
    {


        public static void eragonMove()
        {
            int eragonX = EragonDL.getEragonX();
            int eragonY = EragonDL.getEragonY();
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeft(eragonX,eragonY);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {

                moveRight(eragonX, eragonY);
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp(eragonX, eragonY);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {

                moveDown(eragonX, eragonY);
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                eragonGenerateBullet();
            }

        }
        public static void moveLeft(int eragonX,int eragonY)
        {
           
            char next1 = GameDL.getCharFromMaze(eragonX - 1,eragonY );
            char next2 = GameDL.getCharFromMaze(eragonX - 1,eragonY +1);
            char next3 = GameDL.getCharFromMaze(eragonX - 1,eragonY +2 );

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon();
                EragonDL.setEragonX(eragonX - 1);
                printEragon();
            }

        }
        public static void moveRight(int eragonX, int eragonY)
        {
            char next1 = GameDL.getCharFromMaze(eragonX + 3,eragonY );
            char next2 = GameDL.getCharFromMaze(eragonX + 3,eragonY + 1 );
            char next3 = GameDL.getCharFromMaze(eragonX + 3,eragonY + 2 );

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon();
                EragonDL.setEragonX(eragonX + 1);
                printEragon();
            }

        }
        public static void moveUp(int eragonX, int eragonY)
        {
            char next1 = GameDL.getCharFromMaze(eragonX, eragonY - 1 );
            char next2 = GameDL.getCharFromMaze(eragonX + 1, eragonY - 1 );
            char next3 = GameDL.getCharFromMaze(eragonX + 2, eragonY - 1 );
           
            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon();
                EragonDL.setEragonY(eragonY - 1);
                printEragon();
               
            }

        }
        public static void moveDown(int eragonX, int eragonY)
        {
            char next1 = GameDL.getCharFromMaze(eragonX, eragonY + 3);
            char next2 = GameDL.getCharFromMaze(eragonX + 1, eragonY + 3);
            char next3 = GameDL.getCharFromMaze(eragonX + 2, eragonY + 3);

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon();
                EragonDL.setEragonY(eragonY + 1);
                printEragon();

            }

            
        }

        public static void eraseEragon()
        {
            int eragonX = EragonDL.getEragonX();
            int eragonY = EragonDL.getEragonY();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.SetCursorPosition(eragonX + y, eragonY + x);
                    GameDL.setCharOnMaze(eragonX + y, eragonY + x, ' ');
                    Console.Write(" ");
                }
            }
        }
        public static void printEragon()
        {

            int eragonX = EragonDL.getEragonX();
            int eragonY = EragonDL.getEragonY();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            char top = (char)244;
            char middle1 = (char)166, middle2 = (char)22;
            char bottom = (char)127;

            char[,] eragon = {
                             { ' ', top, ' '},
                             { middle2, middle1, middle2},
                             { ' ', bottom, ' '}
                             };

            for (int x = 0; x < 3; x++)
            {

                for (int y = 0; y < 3; y++)
                {
                    Console.SetCursorPosition(eragonX + y, eragonY + x);
                    GameDL.setCharOnMaze(eragonX + y, eragonY + x, eragon[x, y]);
                    Console.Write(eragon[x, y]);
                }
            }
        }

        public static void eragonGenerateBullet()
        {
            int eragonX = EragonDL.getEragonX();
            int eragonY = EragonDL.getEragonY();
            int eragonShotSpeed = EragonDL.getEragonShotSpeed();

            Console.ForegroundColor = ConsoleColor.Green;

            char next = GameDL.getCharFromMaze(eragonX + 3, eragonY + 1);
            
            if (next == ' ')
            {
                
                if (eragonShotSpeed % 5 == 0)
                {
                   

                    int eragonBulletX = eragonX + 3;
                    int eragonBulletY = eragonY + 1;
                    bool eragonRightBulletActive = true;

                    EragonRightBulletBL eragonRightBullet = new EragonRightBulletBL(eragonBulletX, eragonBulletY, eragonRightBulletActive);

                    EragonRightBulletDL.addEragonRightBulletToList(eragonRightBullet);
                    Console.SetCursorPosition(eragonBulletX, eragonBulletY);
                    GameDL.setCharOnMaze(eragonBulletX, eragonBulletY, '.');
                    
                    Console.WriteLine(".");
                }
            }
            EragonDL.setEragonShotSpeed(eragonShotSpeed + 1);
            
        }
        
        public static void eragonDracoCollision()
        {
            int size = DracoLeftBulletDL.getDracoLeftBulletListSize();

            for (int x = 0; x < size; x++)
            {
                DracoLeftBulletBL dracoLeftBullet = DracoLeftBulletDL.getDracoLeftBulletObject(x);

                int eragonX = EragonDL.getEragonX();
                int eragonY = EragonDL.getEragonY();

                if (dracoLeftBullet.dracoLeftBulletActive == true)
                {
                    if (dracoLeftBullet.dracoBulletX - 3 == eragonX && (dracoLeftBullet.dracoBulletY == eragonY || dracoLeftBullet.dracoBulletY == eragonY + 1 || dracoLeftBullet.dracoBulletY == eragonY + 2))
                    {

                        EragonDL.decreaseEragonHealth(1);
                    }
                }
            }
        }

        public static void printEragonScore()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int eragonScore = EragonDL.getEragonScore();
            int eragonHealth = EragonDL.getEragonHealth();
            if (eragonScore <= 0)
            {
                EragonDL.setEragonScore(0);
            }
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("Score is: " + eragonScore + " ");
            Console.SetCursorPosition(120, 10);
            Console.WriteLine("Eragon Health is: " + eragonHealth + " ");
        }

    }
}
