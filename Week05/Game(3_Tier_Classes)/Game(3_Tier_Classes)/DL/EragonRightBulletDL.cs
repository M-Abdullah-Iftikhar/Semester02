using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.UI;
using Game_3_Tier_Classes_.BL;

namespace Game_3_Tier_Classes_.DL
{
    class EragonRightBulletDL
    {
       static  List<EragonRightBulletBL> eragonRightBulletList = new List<EragonRightBulletBL>();
        public static void addEragonRightBulletToList(EragonRightBulletBL eragonRightBullet)
        {
            eragonRightBulletList.Add(eragonRightBullet);
        }

        public static int getEragonRightBulletListSize()
        {
            return eragonRightBulletList.Count;
        }

        public static EragonRightBulletBL getEragonRightBulletObject(int x)
        {
            return eragonRightBulletList[x];
        }

        public static void deleteEragonRightBullet(int x)
        {
            eragonRightBulletList.RemoveAt(x);
        }

        public static void setEragonRightBulletX(int x, int X)
        {
            eragonRightBulletList[x].eragonBulletX = X;
        }
        public static int getEragonRightBulletX(int x)
        {
            return eragonRightBulletList[x].eragonBulletX;
        }
        public static void setEragonRightBulletY(int y, int Y)
        {
            eragonRightBulletList[y].eragonBulletX = Y;
        }
        public static int getEragonRightBulletY(int y)
        {
            return eragonRightBulletList[y].eragonBulletY;
        }
    }
}
