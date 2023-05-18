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
    class DracoDL
    {
       static DracoBL draco = new DracoBL();

        public static void callDraco()
        {
            draco.dracoX = 80;
            draco.dracoY = 7;

            draco.dracoShotSpeed = 12;

            draco.dracoHealth = 20;

            draco.dracoActive = true;
        }
        public static void deleteDraco()
        {
            int dracoHealth = getDracoHealth();
            if (dracoHealth <= 0)
            {
                draco.dracoHealth = 0;
                DracoUI.eraseDraco();
                draco.dracoX = 0;
                draco.dracoY = 35;
                draco.dracoActive = false;
            }
        }
        public static void setDracoState(bool state)
        {
            draco.dracoActive = state;
        }
        public static bool getDracoState()
        {
            return draco.dracoActive;
        }

        public static void setDracoHealth(int health)
        {
            draco.dracoHealth = health;
        }

        public static int getDracoHealth()
        {
            return draco.dracoHealth;
        }

        public static void decreaseDracoHealth(int x)
        {
            draco.dracoHealth = draco.dracoHealth - x;
        }


        public static void setDracoX(int X)
        {
            draco.dracoX = X;
        }
        public static int getDracoX()
        {
            return draco.dracoX;
        }
        public static void setDracoY(int Y)
        {
            draco.dracoY = Y;
        }
        public static int getDracoY()
        {
            return draco.dracoY;
        }
        public static void setDracoShotSpeed(int shotSpeed)
        {
            draco.dracoShotSpeed = shotSpeed;
        }
        public static int getDracoShotSpeed()
        {
            return draco.dracoShotSpeed;
        }
        public static void setDracoSpeed(int dracoSpeed)
        {
            draco.dracoSpeed = dracoSpeed;
        }

        public static int getDracoSpeed()
        {
            return draco.dracoSpeed;
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
        public static void storeDracoData()
        {
            string path = "D:\\Study\\OOP\\Week05\\Game(3_Tier_Classes)\\dracoVariables.txt";
            StreamWriter file = new StreamWriter(path);

            file.WriteLine(draco.dracoX + ","
                 + draco.dracoY + ","
                 + draco.dracoHealth + ","
                 + draco.dracoShotSpeed + ","
                 + draco.dracoSpeed + ","
                 + draco.dracoActive);
            file.Flush();
            file.Close();
        }
        public static void loadDracoData()
        {


            string path = "D:\\Study\\OOP\\Week05\\Game(3_Tier_Classes)\\dracoVariables.txt";


            if (File.Exists(path))
            {
                
                string dracoActive_;
                string record;
                StreamReader myFile = new StreamReader(path);
                record = myFile.ReadLine();

                draco.dracoX = int.Parse(getField(record, 1));
                draco.dracoY = int.Parse(getField(record, 2));
                draco.dracoHealth = int.Parse(getField(record, 3));
                draco.dracoShotSpeed = int.Parse(getField(record, 4));

                draco.dracoSpeed = int.Parse(getField(record, 5));
                dracoActive_ = getField(record, 6);

                loadDracoHelper(dracoActive_);

                myFile.Close();
            }
        }
        public static void loadDracoHelper(string dracoActive_)
        {
            if (dracoActive_ == "True")
            {
                draco.dracoActive = true;
            }
            else if (dracoActive_ == "False")
            {
                draco.dracoActive = false;
            }

        }
      
    }
}
