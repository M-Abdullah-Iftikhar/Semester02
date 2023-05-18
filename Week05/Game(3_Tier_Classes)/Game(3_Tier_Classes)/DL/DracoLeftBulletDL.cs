using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.BL;
using Game_3_Tier_Classes_.UI;

namespace Game_3_Tier_Classes_.DL
{
    class DracoLeftBulletDL
    {
        static List<DracoLeftBulletBL> dracoLeftBulletList = new List<DracoLeftBulletBL>();

        public static void addDracoLeftBulletToList(DracoLeftBulletBL dracoLeftBullet)
        {
            dracoLeftBulletList.Add(dracoLeftBullet);
        }

        public static int getDracoLeftBulletListSize()
        {
            return dracoLeftBulletList.Count;
        }

        public static DracoLeftBulletBL getDracoLeftBulletObject(int x)
        {
            return dracoLeftBulletList[x];
        }

        public static void deleteDracoLeftBullet(int x)
        {
            dracoLeftBulletList.RemoveAt(x);
        }

        public static void setDracoLeftBulletX(int x, int X)
        {
            dracoLeftBulletList[x].dracoBulletX = X;
        }
        public static int getDracoLeftBulletX(int x)
        {
            return dracoLeftBulletList[x].dracoBulletX;
        }
        public static void setDracoLeftBulletY(int y, int Y)
        {
            dracoLeftBulletList[y].dracoBulletX = Y;
        }
        public static int getDracoLeftBulletY(int y)
        {
            return dracoLeftBulletList[y].dracoBulletY;
        }

    }
}
