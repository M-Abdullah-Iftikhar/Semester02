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
    class EragonDL
    {
        static EragonBL eragon = new EragonBL();


        public static void callEragon()
        {
            eragon.eragonX = 10;
            eragon.eragonY = 7;
            eragon.eragonHealth = 20;
            eragon.eragonActive = true;
            eragon.eragonScore = 0;
        }
        public static void setEragonState(bool state)
        {
            eragon.eragonActive = state;
        }
        public static bool getEragonState()
        {
            return eragon.eragonActive;
        }

        public static void setEragonHealth(int health)
        {
            eragon.eragonHealth = health;
        }

        public static int getEragonHealth()
        {
            return eragon.eragonHealth;
        }

        public static void decreaseEragonHealth(int x)
        {
            eragon.eragonHealth = eragon.eragonHealth - x;
        }
        public static void setEragonScore(int score)
        {
            eragon.eragonScore = score;
        }
        public static int getEragonScore()
        {
            return eragon.eragonScore;
        }

        public static void increaseEragonScore(int x)
        {
            eragon.eragonScore = eragon.eragonScore + x;
        }

        public static void setEragonX(int X)
        {
            eragon.eragonX = X;
        }
        public static int getEragonX()
        {
            return eragon.eragonX;
        }
        public static void setEragonY(int Y)
        {
            eragon.eragonY = Y;
        }
        public static int getEragonY()
        {
            return eragon.eragonY;
        }
        public static void setEragonShotSpeed(int shotSpeed)
        {
            eragon.eragonShotSpeed = shotSpeed;
        }
        public static int getEragonShotSpeed()
        {
            return eragon.eragonShotSpeed;
        }
        public static void setEragonShotSpeedLimit(int shotSpeedLimit)
        {
            eragon.eragonShotSpeedLimit = shotSpeedLimit;
        }
        public static int getEragonShotSpeedLimit()
        {
            return eragon.eragonShotSpeedLimit;
        }
        public static void setLevel(int x)
        {
            eragon.level = x;
        }

        public static int getLevel()
        {
            return eragon.level;
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
        public static void storeEragonData()
        {
            string path = "D:\\Study\\OOP\\Week05\\Game(3_Tier_Classes)\\eragonVariables.txt";
            StreamWriter file = new StreamWriter(path);

            file.WriteLine(eragon.eragonX + ","
                 + eragon.eragonY + ","
                 + eragon.eragonHealth + ","
                 + eragon.eragonScore + ","
                 + eragon.level + ","
                 + eragon.eragonShotSpeed + ","
                 + eragon.eragonActive);
            file.Flush();
            file.Close();
        }
        public static void loadEragonData()
        {
            

            string path = "D:\\Study\\OOP\\Week05\\Game(3_Tier_Classes)\\eragonVariables.txt";


            if (File.Exists(path))
            {
                string eragonActive_;
                string record;
                StreamReader myFile = new StreamReader(path);
                record = myFile.ReadLine();

                eragon.eragonX = int.Parse(getField(record, 1));
                eragon.eragonY = int.Parse(getField(record, 2));
                eragon.eragonHealth = int.Parse(getField(record, 3));
                eragon.eragonScore = int.Parse(getField(record, 4));
               
                eragon.level = int.Parse(getField(record, 5));
                eragon.eragonShotSpeed = int.Parse(getField(record, 6));
                eragonActive_ = getField(record, 7);

                loadEragonHelper(eragonActive_);

                myFile.Close();
            }
        }
        public static void loadEragonHelper(string eragonActive_)
        {
            if (eragonActive_ == "True")
            {
                eragon.eragonActive = true;
            }
            else if (eragonActive_ == "False")
            {
                eragon.eragonActive = false;
            }

        }

    }
}
