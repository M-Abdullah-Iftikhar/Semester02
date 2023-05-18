using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.UI;
using System.IO;

namespace Game_3_Tier_Classes_.DL
{
    class GameDL
    {
        static GameBL game = new GameBL();

        public static void setCharOnMaze(int x,int y,char mazeChar)
        {
            game.maze2d[y, x] = mazeChar;
        }

       

        public static char getCharFromMaze(int x,int y)
        {
            char mazeChar = game.maze2d[y, x];
            return mazeChar;
        }

        public static void storeMaze()
        {
            string path = "D:\\Study\\OOP\\Week05\\Game(3_Tier_Classes)\\gameMaze_3_Tier_Classes.txt";
            StreamWriter file = new StreamWriter(path);

            for (int x = 0; x < 34; x++)
            {
                for (int y = 0; y < 110; y++)
                {
                    file.Write(game.maze2d[x, y]);
                }
                file.WriteLine();
            }
            file.Flush();
            file.Close();
        }
        public static char getField1(string record, int field)
        {
            int commaCount = 0;
            char item = ' ';
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
        public static void loadMaze()
        {

            string path = "D:\\Study\\OOP\\Week05\\Game(3_Tier_Classes)\\gameMaze_3_Tier_Classes.txt";

            if (File.Exists(path))
            {
                string record;
                StreamReader myFile = new StreamReader(path);




                for (int x = 0; x < (game.maze2d).GetLength(0); x++)
                {
                    record = myFile.ReadLine();
                    for (int y = 0; y < (game.maze2d).GetLength(1); y++)
                    {
                        game.maze2d[x, y] = getField1(record, y);
                    }
                }



                myFile.Close();
            }
        }

    }
}
