using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.DL;
using System.Threading;
using EZInput;


namespace Game_3_Tier_Classes_.UI
{
    class GameUI
    {

        public static string mainMenuOptionSelect()
        {
            string choice;

            while (true)
            {

                Console.Clear();
                header();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine();

                Console.WriteLine("Press 1 to Start the game ");
                Console.WriteLine("Press 2 to continue Previous Game");
                Console.WriteLine("Press 3 to enter the Option menu");
                Console.WriteLine("Press 4 to exit ");

                choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                    press();
                }
            }

            return choice;
        }
        public static void header()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("oooooo   oooooo     oooo ooooo  oooooooooooo       .o.       ooooooooo.   oooooooooo.   ooooo ooooo      ooo   .oooooo.         ");
            Console.WriteLine(" `888.    `888.     .8'  `888'  d''''''d888'      .888.      `888   `Y88. `888'   `Y8b  `888' `888b.     `8'  d8P'  `Y8b        ");
            Console.WriteLine("  `888.   .8888.   .8'    888        .888P       .8'888.      888   .d88'  888      888  888   8 `88b.    8  888                ");
            Console.WriteLine("   `888  .8'`888. .8'     888       d888'       .8' `888.     888ooo88P'   888      888  888   8   `88b.  8  888                ");
            Console.WriteLine("    `888.8'  `888.8'      888     .888P        .88ooo8888.    888`88b.     888      888  888   8     `88b.8  888     ooooo      ");
            Console.WriteLine("     `888'    `888'       888    d888'    P   .8'     `888.   888  `88b.   888     d88'  888   8       `888  `88.    .88'       ");
            Console.WriteLine("      `8'      `8'       o888o .8888888888P  o88o     o8888o o888o  o888o o888bood8P'   o888o o8o        `8   `Y8bood8P'        ");
            Console.WriteLine("                                                                                                                                ");
            Console.WriteLine("                                                                                                                                ");
            Console.WriteLine("                                                                                                                                ");
            Console.WriteLine("          oooooo   oooooo     oooo   .oooooo.   ooooooooo.   ooooo        oooooooooo.                                           ");
            Console.WriteLine("           `888.    `888.     .8'   d8P'  `Y8b  `888   `Y88. `888'        `888'   `Y8b                                          ");
            Console.WriteLine("            `888.   .8888.   .8'   888      888  888   .d88'  888          888      888                                         ");
            Console.WriteLine("             `888  .8'`888. .8'    888      888  888ooo88P'   888          888      888                                         ");
            Console.WriteLine("              `888.8'  `888.8'     888      888  888`88b.     888          888      888                                         ");
            Console.WriteLine("               `888'    `888'      `88b    d88'  888  `88b.   888       o  888     d88'                                         ");
            Console.WriteLine("                `8'      `8'        `Y8bood8P'  o888o  o888o o888ooooood8 o888bood8P'     ");
            Console.WriteLine("");
        }
        public static void loadingScreen()
        {
            Console.Clear();
            header();
            loading();
        }
        public static void loading()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            char a = Convert.ToChar(166);
            Console.WriteLine();
            Console.Write("Loading " + a);
            Thread.Sleep(300);
            Console.Write(a);
            Thread.Sleep(100);
            Console.Write(a + "" + "" + a);
            Thread.Sleep(400);
            Console.Write(a);
            Thread.Sleep(500);
            Console.Write(a + "" + a + "" + a);
            Thread.Sleep(100);
            Console.Write(a);
            Thread.Sleep(100);
            Console.Write(a);
            Thread.Sleep(200);
            Console.Write(a);
            Thread.Sleep(800);
            Console.Write(a);
        }
        public static void instructions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Use arrow keys to move left,right,up and down:");
            Console.WriteLine("Hold space to fire left and Hold Ctrl to fire right: ");
            Console.WriteLine("game will stop for 3 second after clearing a level(for Now): ");
            Console.WriteLine("there are 4 stages for now: ");
            press();
        }
        public static void printGameover()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine();
            Console.WriteLine("     /\\\\\\\\\\\\\\\\\\\\\\\\     /\\\\\\\\\\\\\\\\\\     /\\\\\\\\            /\\\\\\\\  /\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\                    ");
            Console.WriteLine("    /\\\\\\//////////    /\\\\\\\\\\\\\\\\\\\\\\\\\\  \\/\\\\\\\\\\\\        /\\\\\\\\\\\\ \\/\\\\\\///////////                    ");
            Console.WriteLine("    /\\\\\\              /\\\\\\/////////\\\\\\ \\/\\\\\\//\\\\\\    /\\\\\\//\\\\\\ \\/\\\\\\                              ");
            Console.WriteLine("    \\/\\\\\\    /\\\\\\\\\\\\\\ \\/\\\\\\       \\/\\\\\\ \\/\\\\\\\\///\\\\\\/\\\\\\/ \\/\\\\\\ \\/\\\\\\\\\\\\\\\\\\\\\\                     ");
            Console.WriteLine("     \\/\\\\\\   \\/////\\\\\\ \\/\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\/\\\\\\  \\///\\\\\\/   \\/\\\\\\ \\/\\\\\\///////                     ");
            Console.WriteLine("      \\/\\\\\\       \\/\\\\\\ \\/\\\\\\/////////\\\\\\ \\/\\\\\\    \\///     \\/\\\\\\ \\/\\\\\\                           ");
            Console.WriteLine("       \\/\\\\\\       \\/\\\\\\ \\/\\\\\\       \\/\\\\\\ \\/\\\\\\             \\/\\\\\\ \\/\\\\\\                          ");
            Console.WriteLine("        \\//\\\\\\\\\\\\\\\\\\\\\\\\/  \\/\\\\\\       \\/\\\\\\ \\/\\\\\\             \\/\\\\\\ \\/\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\             ");
            Console.WriteLine("          \\////////////    \\///        \\///  \\///              \\///  \\///////////////             ");
            Console.WriteLine("       /\\\\\\\\\\       /\\\\\\        /\\\\\\  /\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\    /\\\\\\\\\\\\\\\\\\                              ");
            Console.WriteLine("      /\\\\\\///\\\\\\    \\/\\\\\\       \\/\\\\\\ \\/\\\\\\///////////   /\\\\\\///////\\\\\\                           ");
            Console.WriteLine("     /\\\\\\/  \\///\\\\\\  \\//\\\\\\      /\\\\\\  \\/\\\\\\             \\/\\\\\\     \\/\\\\\\                          ");
            Console.WriteLine("     /\\\\\\      \\//\\\\\\  \\//\\\\\\    /\\\\\\   \\/\\\\\\\\\\\\\\\\\\\\\\     \\/\\\\\\\\\\\\\\\\\\\\\\/                          ");
            Console.WriteLine("     \\/\\\\\\       \\/\\\\\\   \\//\\\\\\  /\\\\\\    \\/\\\\\\///////      \\/\\\\\\//////\\\\\\                         ");
            Console.WriteLine("      \\//\\\\\\      /\\\\\\     \\//\\\\\\/\\\\\\     \\/\\\\\\             \\/\\\\\\    \\//\\\\\\                       ");
            Console.WriteLine("        \\///\\\\\\  /\\\\\\        \\//\\\\\\\\\\      \\/\\\\\\             \\/\\\\\\     \\//\\\\\\                     ");
            Console.WriteLine("           \\///\\\\\\\\\\/          \\//\\\\\\       \\/\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ \\/\\\\\\      \\//\\\\\\                   ");
            Console.WriteLine("              \\/////             \\///        \\///////////////  \\///        \\///    ");
            Console.WriteLine();
        }

        public static void printMaze()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int y = 0; y < 34; y++)
            {
                for (int x = 0; x < 110; x++)
                {
                    char mazeChar = GameDL.getCharFromMaze(x, y);
                    Console.Write(mazeChar);
                }
                Console.WriteLine();
            }
        }
        public static void printMaze1()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            char[,] maze = new char[34, 110];
            char wall = (char)166;
            for (int y = 0; y < 34; y++)
            {
                for (int x = 0; x < 110; x++)
                {
                    if (x == 0 || x == 109 )
                    {
                        maze[y, x] = wall;
                    }
                    else if(y == 1 || y == 33)
                    {
                        maze[y, x] = wall;
                    }
                    else
                    {
                        maze[y, x] = ' ';
                    }

                    Console.SetCursorPosition(x, y);
                    Console.Write(maze[y, x]);
                    GameDL.setCharOnMaze(x,y,maze[y, x]);

                }
                
            }
        }


        public static void gameEndMsg()
        {
            Console.Clear();
            Console.WriteLine("For Now Game Ends Here");
            press();
        }
        public static void press()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void startGame()
        {
            int nextLevel;
            bool goBack = false;
            while (true)
            {


                goBack = false;
                nextLevel = EragonDL.getLevel();


                if (nextLevel > 1)
                {
                    gameEndMsg();
                    break;
                }
                if (nextLevel == 1)
                {

                    // Eragon
                    
                    EragonDL.callEragon();
                    printMaze1();
                    int eragonX = EragonDL.getEragonX();
                    int eragonY = EragonDL.getEragonY();
                    
                    EragonUI.printEragon();

                    // Draco

                    DracoDL.callDraco();

                    /*
                    eragonVariables.eragonActive = true;
                    loadCharacterData(gameVariables, eragonVariables, dracoVariables);

                    loadMaze(gameVariables);
                    printMaze(gameVariables);
                    */
                }
                else if (nextLevel == -1)
                {
                    printMaze();

                }

                while (true)
                {

                    if (Keyboard.IsKeyPressed(Key.Escape))
                    {
                        //storeCharacterData();
                        goBack = true;
                        break;
                    }
                    if (EragonDL.getEragonState() == false)
                    {
                        goBack = true;
                        break;
                    }




                    // Eragon

                    EragonUI.eragonMove();
                   
                    EragonUI.eragonDracoCollision();



                    // Draco

                    DracoDL.deleteDraco();
                    bool dracoActive = DracoDL.getDracoState();
                    if (dracoActive == true)
                    {
                        DracoUI.dracoGenerateBullet();
                        DracoUI.dracoMove();
                        DracoUI.dracoCollision();
                    }

                    DracoUI.printDracoHealth();
                    DracoLeftBulletUI.dracoMoveBullet();

                    EragonRightBulletUI.eragonMoveBullet();
                    Thread.Sleep(50);

                    GameDL.storeMaze();
                    DracoDL.storeDracoData();
                    EragonDL.storeEragonData();

                    int eragonHealth = EragonDL.getEragonHealth();
                    int dracoHealth = DracoDL.getDracoHealth();
                    
                    if (eragonHealth <= 0 || dracoHealth <= 0)
                    {
                        Console.Clear();
                        GameUI.printGameover();
                        if (eragonHealth <= 0)
                        {
                            Console.WriteLine("You Lose");
                        }
                        else if (dracoHealth <= 0)
                        {
                            Console.WriteLine("You Win");
                        }

                        Console.ReadKey();
                        EragonDL.setEragonState(false);
                    }
                    EragonUI.printEragonScore();

                }
                if (goBack == true)
                {
                    break;
                }
            }

        }


    }
}
