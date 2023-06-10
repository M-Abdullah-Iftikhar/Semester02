using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.BL
{
    class Deck
    {
        private int count;

        private Card[] deck = new Card[52];

        public Deck()
        {
            count = 0;
            for(int x = 1;x<=4;x++)
            {
                for(int y = 1; y<= 13; y++)
                {
                    deck[count] = new Card(y, x);
                    count++;
                }
            }
        }
    }
}
