using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.DL;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.UI;
using EZInput;
using System.Threading;
using System.IO;


namespace Game_3_Tier_Classes_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GameUI.loadingScreen();
            while (true)
            {
                string choice;

                choice = GameUI.mainMenuOptionSelect();

                if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for using this App");
                    GameUI.press();
                }
                else if (choice == "1")
                {


                    Console.Clear();
                    Console.WriteLine();
                    EragonDL.setLevel(1);

                    GameUI.startGame();
                    GameUI.loadingScreen();
                }
                else if (choice == "2")
                {
                    EragonDL.setEragonState(true);
                    EragonDL.loadEragonData();
                    DracoDL.loadDracoData();
                    GameDL.loadMaze();
                    
                    Console.Clear();
                    Console.WriteLine();
                    EragonDL.setLevel(-1);
                    GameUI.startGame();
                    GameUI.loadingScreen();
                }
                else if (choice == "3")
                {
                    GameUI.instructions();
                }
            }

        }

        
       

    }
}
