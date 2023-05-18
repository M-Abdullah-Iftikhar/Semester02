using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_3_Tier_Classes_.DL;
using Game_3_Tier_Classes_.UI;

namespace Game_3_Tier_Classes_.BL
{
    class EragonRightBulletBL
    {
        public EragonRightBulletBL(int eragonBulletX, int eragonBulletY, bool eragonRightBulletActive)
        {
            this.eragonBulletX = eragonBulletX;
            this.eragonBulletY = eragonBulletY;
            this.eragonRightBulletActive = eragonRightBulletActive;
        }
        public int eragonBulletX;
        public int eragonBulletY;
        public bool eragonRightBulletActive;
    }
}
