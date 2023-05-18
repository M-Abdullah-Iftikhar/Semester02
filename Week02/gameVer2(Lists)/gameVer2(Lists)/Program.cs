using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EZInput;
using System.Threading;
using gameVer2_Lists_.BL;

namespace gameVer2_Lists_
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////
            ///game variables
            ///////////////////////////////////////////
            
            Game gameVariables = new Game();

            //
            ///////////////////////////////////////////////////////////////
            // Eragon variables
            //////////////////////////////////////////////////////////////
            //
            
            Eragon eragonVariables = new Eragon();
            List<Eragon> eragonArrays = new List<Eragon>();

            //
            ////////////////////////////////////////////////////////////
            // Draco variables
            /////////////////////////////////////////////////////////////
            //
            

            Draco dracoVariables = new Draco();
            List<Draco> dracoArrays = new List<Draco>();

            ///////////////////////////////////////////////////////////////////////////////////
            ///

            loadingScreen();
            while (true)
            {
                string choice;

                choice = optionSelect();

                if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for using this App");
                    press();
                }
                else if (choice == "1")
                {

                    
                    Console.Clear();
                    Console.WriteLine();
                    gameVariables.level =  1;
                    
                    startGame(gameVariables, eragonVariables, eragonArrays, dracoVariables, dracoArrays);
                    loadingScreen();
                }
                else if (choice == "2")
                {
                    eragonVariables.eragonActive = true;
                    loadCharacterData(gameVariables, eragonVariables, dracoVariables);
                    loadMaze(gameVariables);
                    Console.Clear();
                    Console.WriteLine();
                    gameVariables.level = -1;
                    startGame(gameVariables, eragonVariables, eragonArrays, dracoVariables, dracoArrays);
                    loadingScreen();
                }
                else if (choice == "3")
                {
                    instructions();
                }
            }

        }

        /// 
        /// //////////////////////////////
        /// game functions
        /// 
        /// 

        public static string optionSelect()
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

        public static void startGame(Game gameVariables,Eragon eragonVariables,List<Eragon> eragonArrays,Draco dracoVariables,List<Draco> dracoArrays)
        {
            int nextLevel;
            bool goBack = false;
            while (true)
            {


                goBack = false;
                nextLevel = gameVariables.level;
                

                if (nextLevel > 1)
                {
                    Console.Clear();
                    Console.WriteLine("For Now Game Ends Here");
                    break;
                }
                if (nextLevel == 1)
                {

                    // Eragon

                     callEragon(eragonVariables);
                     printMaze1(gameVariables);
                    printEragon(gameVariables, eragonVariables);

                    // Draco

                    callDraco(dracoVariables);

                    /*
                    eragonVariables.eragonActive = true;
                    loadCharacterData(gameVariables, eragonVariables, dracoVariables);

                    loadMaze(gameVariables);
                    printMaze(gameVariables);
                    */
                }
                else if (nextLevel == -1)
                {
                    printMaze(gameVariables);

                }

                while (true)
                {

                    if (Keyboard.IsKeyPressed(Key.Escape))
                    {
                        //storeCharacterData();
                        goBack = true;
                        break;
                    }
                    if (eragonVariables.eragonActive == false)
                    {
                        goBack = true;
                        break;
                    }

                    


                    // Eragon

                    eragonMove(gameVariables,eragonVariables,eragonArrays);
                    printEragonScore(eragonVariables);
                    eragonDracoCollision(eragonVariables,dracoArrays);



                    // Draco

                    deleteDraco(gameVariables,dracoVariables);
                    if (dracoVariables.dracoActive == true)
                    {
                        dracoGenerateBullet(gameVariables, dracoVariables,dracoArrays);
                        dracoMove(gameVariables,eragonVariables, dracoVariables);
                        dracoCollision(eragonVariables,eragonArrays, dracoVariables);
                    }

                    printDracoHealth(dracoVariables);
                    dracoMoveBullet(gameVariables,dracoArrays);

                    eragonMoveBullet(gameVariables,eragonArrays);
                    Thread.Sleep(50);

                    storeMaze(gameVariables);
                    storeCharacterData(gameVariables, eragonVariables,dracoVariables);
                    if (eragonVariables.eragonHealth <= 0 || dracoVariables.dracoHealth <=0)
                    {
                        Console.Clear();
                        printGameover();
                        if (eragonVariables.eragonHealth <= 0)
                        {
                            Console.WriteLine("You Lose");
                        }
                        else if (dracoVariables.dracoHealth <= 0)
                        {
                            Console.WriteLine("You Win");
                        }

                        Console.ReadKey();
                        eragonVariables.eragonActive = false;
                    }

                }
                if (goBack == true)
                {
                    break;
                }
            }

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

        public static void printMaze1(Game gameVariables)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            char[,] maze = new char[34, 110];
            char wall = (char)166;
            Console.WriteLine();
            for (int y = 0; y < 34; y++)
            {
                for (int x = 0; x < 110; x++)
                {
                    if (x == 0 || x == 109 || y == 1 || y == 33)
                    {
                        maze[y, x] = wall;
                    }
                    else
                    {
                        maze[y, x] = ' ';
                    }

                    Console.Write(maze[y, x]);
                    gameVariables.maze2d[y, x] = maze[y, x];

                }
                Console.WriteLine();
            }
        }

        public static void printMaze(Game gameVariables)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int y = 0; y < 34; y++)
            {
                for (int x = 0; x < 110; x++)
                {
                    Console.Write(gameVariables.maze2d[y, x]);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////////////
        /// </summary>
        /// 

        public static void callEragon(Eragon eragonVariables)
        {
            eragonVariables.eragonX = 10;
            eragonVariables.eragonY = 7;
            eragonVariables.eragonHealth = 20;
            eragonVariables.eragonActive = true;
            eragonVariables.eragonScore = 0;
        }
        public static void eragonMove(Game gameVariables,Eragon eragonVariables,List<Eragon> eragonArrays)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeft(gameVariables,eragonVariables);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {

                moveRight(gameVariables, eragonVariables);
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp(gameVariables, eragonVariables);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {

                moveDown(gameVariables, eragonVariables);
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                eragonGenerateBullet(gameVariables, eragonVariables,eragonArrays);
            }

        }
        public static void moveLeft(Game gameVariables, Eragon eragonVariables)
        {
            char next1 = gameVariables.maze2d[eragonVariables.eragonY, eragonVariables.eragonX - 1];
            char next2 = gameVariables.maze2d[eragonVariables.eragonY+1, eragonVariables.eragonX - 1];
            char next3 = gameVariables.maze2d[eragonVariables.eragonY+2, eragonVariables.eragonX - 1];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon(gameVariables,eragonVariables);
                eragonVariables.eragonX = eragonVariables.eragonX - 1;
                printEragon(gameVariables, eragonVariables);
            }

        }
        public static void moveRight(Game gameVariables, Eragon eragonVariables)
        {
            char next1 = gameVariables.maze2d[eragonVariables.eragonY, eragonVariables.eragonX + 3];
            char next2 = gameVariables.maze2d[eragonVariables.eragonY + 1, eragonVariables.eragonX + 3];
            char next3 = gameVariables.maze2d[eragonVariables.eragonY + 2, eragonVariables.eragonX + 3];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon(gameVariables, eragonVariables);
                eragonVariables.eragonX = eragonVariables.eragonX + 1;
                printEragon(gameVariables, eragonVariables);
            }

        }
        public static void moveUp(Game gameVariables, Eragon eragonVariables)
        {
            char next1 = gameVariables.maze2d[eragonVariables.eragonY - 1, eragonVariables.eragonX ];
            char next2 = gameVariables.maze2d[eragonVariables.eragonY - 1, eragonVariables.eragonX + 1];
            char next3 = gameVariables.maze2d[eragonVariables.eragonY - 1, eragonVariables.eragonX + 2];
            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon(gameVariables, eragonVariables);
                eragonVariables.eragonY = eragonVariables.eragonY - 1;
                printEragon(gameVariables, eragonVariables);
            }

        }
        public static void moveDown(Game gameVariables, Eragon eragonVariables)
        {
            char next1 = gameVariables.maze2d[eragonVariables.eragonY + 3, eragonVariables.eragonX];
            char next2 = gameVariables.maze2d[eragonVariables.eragonY + 3, eragonVariables.eragonX + 1];
            char next3 = gameVariables.maze2d[eragonVariables.eragonY + 3, eragonVariables.eragonX + 2];

            if (next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseEragon(gameVariables, eragonVariables);
                eragonVariables.eragonY = eragonVariables.eragonY + 1;
                printEragon(gameVariables, eragonVariables);
            }
        }

        public static void eraseEragon(Game gameVariables,Eragon eragonVariables)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Console.SetCursorPosition(eragonVariables.eragonX + y, eragonVariables.eragonY + x);
                    gameVariables.maze2d[eragonVariables.eragonY + x, eragonVariables.eragonX + y] = ' ';
                    Console.WriteLine(" ");
                }
            }
        }
        public static void printEragon(Game gameVariables,Eragon eragonVariables)
        {
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
                    Console.SetCursorPosition(eragonVariables.eragonX + y, eragonVariables.eragonY + x);
                    gameVariables.maze2d[eragonVariables.eragonY + x, eragonVariables.eragonX + y] = eragon[x, y];
                    Console.WriteLine(eragon[x, y]);
                }
            }
        }

        public static void eragonGenerateBullet(Game gameVariables,Eragon eragonVariables,List<Eragon> eragonArrays)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            
            char next = gameVariables.maze2d[eragonVariables.eragonY + 1, eragonVariables.eragonX + 3];

            if (next == ' ')
            {
                if (eragonVariables.eragonShotSpeed % 5 == 0)
                {
                    Eragon temp = new Eragon();

                    temp.eragonBulletX = eragonVariables.eragonX + 3;
                    temp.eragonBulletY = eragonVariables.eragonY + 1;
                    temp.isActiveEragon = true;
                    eragonArrays.Add(temp);

                    Console.SetCursorPosition(eragonVariables.eragonX + 3, eragonVariables.eragonY + 1);
                    gameVariables.maze2d[eragonVariables.eragonY + 1, eragonVariables.eragonX + 3] = '.';
                    Console.WriteLine(".");
                }
            }
            eragonVariables.eragonShotSpeed++;
        }
        public static void eraseEragonBullet(ref int x, ref int y, Game gameVariables)
        {
            Console.SetCursorPosition(x, y);
            gameVariables.maze2d[y, x] = ' ';
            Console.WriteLine(" ");
        }
        public static void printEragonBullet(ref int x, ref int y, Game gameVariables)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            gameVariables.maze2d[y, x] = '.';
            Console.WriteLine(".");
        }
        public static void eragonMoveBullet(Game gameVariables,List<Eragon> eragonArrays)
        {
            for (int x = 0; x < eragonArrays.Count; x++)
            {
                if (eragonArrays[x].isActiveEragon == true)
                {
                    char next = gameVariables.maze2d[eragonArrays[x].eragonBulletY, eragonArrays[x].eragonBulletX + 1];

                    if (next != ' ')
                    {
                        eraseEragonBullet(ref eragonArrays[x].eragonBulletX, ref eragonArrays[x].eragonBulletY, gameVariables);
                        eragonArrays[x].isActiveEragon = false;
                        eragonArrays.RemoveAt(x);
                    }
                    else if (next == ' ')
                    {
                        eraseEragonBullet(ref eragonArrays[x].eragonBulletX, ref eragonArrays[x].eragonBulletY, gameVariables);
                        eragonArrays[x].eragonBulletX = eragonArrays[x].eragonBulletX + 1;
                        printEragonBullet(ref eragonArrays[x].eragonBulletX, ref eragonArrays[x].eragonBulletY, gameVariables);
                    }
                }
            }
        }

        public static void eragonDracoCollision(Eragon eragonVariables,List<Draco> dracoArrays)
        {
            for (int x = 0; x < dracoArrays.Count; x++)
            {
                if (dracoArrays[x].isActiveDraco == true)
                {
                    if (dracoArrays[x].dracoBulletX - 3 == eragonVariables.eragonX && (dracoArrays[x].dracoBulletY == eragonVariables.eragonY || dracoArrays[x].dracoBulletY == eragonVariables.eragonY + 1 || dracoArrays[x].dracoBulletY == eragonVariables.eragonY + 2))
                    {

                        eragonVariables.eragonHealth--;
                    }
                }
            }
        }

        public static void printEragonScore(Eragon eragonVariables)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (eragonVariables.eragonScore <= 0)
            {
                eragonVariables.eragonScore = 0;
            }
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("Score is: " + eragonVariables.eragonScore + " ");
            Console.SetCursorPosition(120, 10);
            Console.WriteLine("Eragon Health is: " + eragonVariables.eragonHealth + " ");
        }


        ///////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// 
        /// </summary>
        public static void callDraco(Draco dracoVariables)
        {
            dracoVariables.dracoX = 80;
            dracoVariables.dracoY = 7;
            
            dracoVariables.dracoShotSpeed = 12;

            dracoVariables.dracoHealth = 20;

            dracoVariables.dracoActive = true;
        }
        public static void dracoMove(Game gameVariables,Eragon eragonVariables,Draco dracoVariables)
        {
            if (dracoVariables.dracoSpeed % 3 == 0)
            {
                if (dracoVariables.dracoX > eragonVariables.eragonX)
                {
                    char next1 = gameVariables.maze2d[dracoVariables.dracoY, dracoVariables.dracoX - 1];
                    char next2 = gameVariables.maze2d[dracoVariables.dracoY + 1, dracoVariables.dracoX - 1];
                    char next3 = gameVariables.maze2d[dracoVariables.dracoY + 2, dracoVariables.dracoX - 1];

                    if (next1 == ' ' && next2 == ' ' && next3 == ' ')
                    {
                        moveLeftDraco(gameVariables,dracoVariables);
                    }
                }
                if (dracoVariables.dracoX < eragonVariables.eragonX)
                {
                    char next1 = gameVariables.maze2d[dracoVariables.dracoY, dracoVariables.dracoX + 2];
                    char next2 = gameVariables.maze2d[dracoVariables.dracoY + 1, dracoVariables.dracoX + 2];
                    char next3 = gameVariables.maze2d[dracoVariables.dracoY + 2, dracoVariables.dracoX + 2];


                    if (next1 == ' ' && next2 == ' ' && next3 == ' ')
                    {
                        moveRightDraco(gameVariables, dracoVariables);
                    }
                }
                if (dracoVariables.dracoY < eragonVariables.eragonY)
                {
                    char next1 = gameVariables.maze2d[dracoVariables.dracoY + 3, dracoVariables.dracoX];
                    char next2 = gameVariables.maze2d[dracoVariables.dracoY + 3, dracoVariables.dracoX + 1];
                    
                    if (next1 == ' ' && next2 == ' ')
                    {
                        moveDownDraco(gameVariables, dracoVariables);
                    }
                }
                if (dracoVariables.dracoY > eragonVariables.eragonY)
                {
                    char next1 = gameVariables.maze2d[dracoVariables.dracoY - 1, dracoVariables.dracoX];
                    char next2 = gameVariables.maze2d[dracoVariables.dracoY - 1, dracoVariables.dracoX + 1];


                    if (next1 == ' ' && next2 == ' ')
                    {
                        moveUpDraco(gameVariables, dracoVariables);
                    }
                }
            }
            dracoVariables.dracoSpeed++;
        }
        public static void moveLeftDraco(Game gameVariables,Draco dracoVariables)
        {
            eraseDraco(gameVariables,dracoVariables);
            dracoVariables.dracoX = dracoVariables.dracoX - 1;
            printDraco(gameVariables, dracoVariables);
        }
        public static void moveRightDraco(Game gameVariables, Draco dracoVariables)
        {
            eraseDraco(gameVariables, dracoVariables);
            dracoVariables.dracoX = dracoVariables.dracoX + 1;
            printDraco(gameVariables, dracoVariables);
        }
        public static void moveUpDraco(Game gameVariables, Draco dracoVariables)
        {
            eraseDraco(gameVariables, dracoVariables);
            dracoVariables.dracoY = dracoVariables.dracoY - 1;
            printDraco(gameVariables, dracoVariables);
        }
        public static void moveDownDraco(Game gameVariables, Draco dracoVariables)
        {
            eraseDraco(gameVariables, dracoVariables);
            dracoVariables.dracoY = dracoVariables.dracoY + 1;
            printDraco(gameVariables, dracoVariables);
        }

        public static void eraseDraco(Game gameVariables, Draco dracoVariables)
        {

            for (int x = 0; x < 3; x++)
            {

                for (int y = 0; y < 2; y++)
                {
                    Console.SetCursorPosition(dracoVariables.dracoX + y, dracoVariables.dracoY + x);
                    gameVariables.maze2d[dracoVariables.dracoY + x, dracoVariables.dracoX + y] = ' ';
                    Console.WriteLine(" ");
                }
            }
        }
        public static void printDraco(Game gameVariables, Draco dracoVariables)
        {
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
                    Console.SetCursorPosition(dracoVariables.dracoX + y, dracoVariables.dracoY + x);
                    gameVariables.maze2d[dracoVariables.dracoY + x, dracoVariables.dracoX + y] = draco[x, y];
                    Console.WriteLine(draco[x, y]);
                }
            }
        }

        public static void dracoGenerateBullet(Game gameVariables,Draco dracoVariables,List<Draco> dracoArrays)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            char next = gameVariables.maze2d[dracoVariables.dracoY + 1, dracoVariables.dracoX - 1];

            if (next == ' ')
            {
                if (dracoVariables.dracoShotSpeed % 6 == 0)
                {
                    Draco temp = new Draco();
                    temp.dracoBulletX = dracoVariables.dracoX - 1;
                    temp.dracoBulletY = dracoVariables.dracoY + 1;
                    temp.isActiveDraco = true;
                    dracoArrays.Add(temp);

                    Console.SetCursorPosition(dracoVariables.dracoX - 1, dracoVariables.dracoY + 1);
                    gameVariables.maze2d[dracoVariables.dracoY + 1, dracoVariables.dracoX - 1] = '.';
                    Console.WriteLine(".");
                }
                dracoVariables.dracoShotSpeed++;
            }
        }
        public static void eraseDracoBullet(ref int x, ref int y, Game gameVariables)
        {
            Console.SetCursorPosition(x, y);
            gameVariables.maze2d[y, x] = ' ';
            Console.WriteLine(" ");
        }
        public static void printDracoBullet(ref int x, ref int y, Game gameVariables)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            gameVariables.maze2d[y, x] = '.';
            Console.WriteLine(".");
        }
        public static void dracoMoveBullet(Game gameVariables,List<Draco> dracoArrays)
        {
            for (int x = 0; x < dracoArrays.Count; x++)
            {
                if (dracoArrays[x].isActiveDraco == true)
                {
                    char next = gameVariables.maze2d[dracoArrays[x].dracoBulletY, dracoArrays[x].dracoBulletX - 1];

                    if (next != ' ')
                    {
                        eraseDracoBullet(ref dracoArrays[x].dracoBulletX, ref dracoArrays[x].dracoBulletY, gameVariables);
                        dracoArrays[x].isActiveDraco = false;
                        dracoArrays.RemoveAt(x);
                    }
                    else if (next == ' ')
                    {
                        eraseDracoBullet(ref dracoArrays[x].dracoBulletX, ref dracoArrays[x].dracoBulletY, gameVariables);
                        dracoArrays[x].dracoBulletX = dracoArrays[x].dracoBulletX - 1;
                        printDracoBullet(ref dracoArrays[x].dracoBulletX, ref dracoArrays[x].dracoBulletY, gameVariables);
                    }
                }
            }
        }

        public static void dracoCollision(Eragon eragonVariables,List<Eragon> eragonArrays,Draco dracoVariables)
        {
            for (int x = 0; x < eragonArrays.Count; x++)
            {

                if (eragonArrays[x].isActiveEragon == true)
                {
                    if (eragonArrays[x].eragonBulletX + 1 == dracoVariables.dracoX && (eragonArrays[x].eragonBulletY == dracoVariables.dracoY || eragonArrays[x].eragonBulletY == dracoVariables.dracoY + 1 || eragonArrays[x].eragonBulletY == dracoVariables.dracoY + 2))
                    {

                        eragonVariables.eragonScore++;
                        dracoVariables.dracoHealth--;
                    }
                }
            }

        }
        public static void printDracoHealth(Draco dracoVariables)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(113, 11);
            Console.WriteLine("Draco Health is: " + dracoVariables.dracoHealth);


        }
        public static void deleteDraco(Game gameVariables, Draco dracoVariables)
        {
            if (dracoVariables.dracoHealth <= 0)
            {
                dracoVariables.dracoHealth = 0;
                eraseDraco(gameVariables,dracoVariables);
                dracoVariables.dracoX = 0;
                dracoVariables.dracoY = 35;
                dracoVariables.dracoActive = false;
            }
        }


        ////////////////////////////
        ///
        public static void press()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void storeMaze(Game gameVariables)
        {
            string path = "D:\\Study\\OOP\\Week01\\GameVer1.txt";
            StreamWriter file = new StreamWriter(path);

            for (int x = 0; x < 34; x++)
            {
                for (int y = 0; y < 110; y++)
                {
                    file.Write(gameVariables.maze2d[x, y]);
                }
                file.WriteLine();
            }
            file.Flush();
            file.Close();
        }

        public static char getField1(string record, int field)
        {
            int commaCount = 0;
            char item = 'a';
            for (int x = 0; x < record.Length; x++)
            {



                if (commaCount == field)
                {
                    item = record[x];
                    break;
                }
                commaCount = commaCount + 1;
            }
            return item;
        }
        public static void loadMaze(Game gameVariables)
        {

            string path = "D:\\Study\\OOP\\Week02\\gameVer2(Lists)\\gameVer2.txt";

            if (File.Exists(path))
            {
                string record;
                StreamReader myFile = new StreamReader(path);




                for (int x = 0; x < (gameVariables.maze2d).GetLength(0); x++)
                {
                    record = myFile.ReadLine();
                    for (int y = 0; y < (gameVariables.maze2d).GetLength(1); y++)
                    {
                        gameVariables.maze2d[x, y] = record[y];
                    }
                }



                myFile.Close();
            }
        }


        public static string getField(string record, int field)
        {
            int commaCount = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount = commaCount + 1;
                }
                else if (commaCount == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void storeCharacterData(Game gameVariables ,Eragon eragonVariables,Draco dracoVariables)
        {
            string path = "D:\\Study\\OOP\\Week01\\GameVariables.txt";
            StreamWriter file = new StreamWriter(path);

            file.WriteLine(eragonVariables.eragonX + ","
                 + eragonVariables.eragonY + ","
                 + eragonVariables.eragonHealth + ","
                 + eragonVariables.eragonScore + ","
                 + dracoVariables.dracoX + ","
                 + dracoVariables.dracoY + ","
                 + dracoVariables.dracoHealth + ","
                 + dracoVariables.dracoActive + ","
                 + gameVariables.level);
            file.Flush();
            file.Close();
        }
        public static void loadCharacterData(Game gameVariables,Eragon  eragonVariables,Draco dracoVariables)
        {
            string dracoActive_;

            string path = "D:\\Study\\OOP\\Week02\\gameVer2(Lists)\\GameVariables.txt";


            if (File.Exists(path))
            {
                string record;
                StreamReader myFile = new StreamReader(path);
                record = myFile.ReadLine();

                eragonVariables.eragonX = int.Parse(getField(record, 1));
                eragonVariables.eragonY = int.Parse(getField(record, 2));
                eragonVariables.eragonHealth = int.Parse(getField(record, 3));
                eragonVariables.eragonScore = int.Parse(getField(record, 4));
                dracoVariables.dracoX = int.Parse(getField(record, 5));
                dracoVariables.dracoY = int.Parse(getField(record, 6));
                dracoVariables.dracoHealth = int.Parse(getField(record, 7));
                dracoActive_ = getField(record, 8);
                gameVariables.level = int.Parse(getField(record, 9));

                loadCharacterHelper(dracoActive_, dracoVariables);

                myFile.Close();
            }
        }
        public static void loadCharacterHelper(string dracoActive_, Draco dracoVariables)
        {
            if (dracoActive_ == "True")
            {
                dracoVariables.dracoActive = true;
            }
            else if (dracoActive_ == "False")
            {
                dracoVariables.dracoActive = false;
            }

        }

    }
}
