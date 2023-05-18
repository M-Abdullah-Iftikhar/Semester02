using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.DL;
using Game_3_Tier_Classes_.UI;

namespace Game_3_Tier_Classes_.BL
{
    class DracoLeftBulletBL
    {
        public DracoLeftBulletBL(int dracoBulletX,int dracoBulletY,bool dracoLeftBulletActive)
        {
            this.dracoBulletX = dracoBulletX;
            this.dracoBulletY = dracoBulletY;
            this.dracoLeftBulletActive = dracoLeftBulletActive;
        }
        public int dracoBulletX;
        public int dracoBulletY;
        public bool dracoLeftBulletActive;
    }
}
