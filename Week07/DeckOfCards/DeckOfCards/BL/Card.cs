using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.BL
{
    class Card
    {
        private int value;
        private int suit;

        public Card(int value,int suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public int getValue()
        {
            return value;
        }
        public void setValue(int value)
        {
            this.value = value;
        }
        public int getSuit()
        {
            return suit;
        }
        public void setSuit(int suit)
        {
            this.suit = suit;
        }

        public string getValueAsString()
        {
            if (value == 1)
            {
                return "Ace";
            }
            if (value == 11)
            {
                return "Jack";
            }
            if (value == 12)
            {
                return "Queen";
            }
            if (value == 13)
            {
                return "King";
            }
            else
            {
                return value.ToString();
            }
        }

        public string getSuitAsString()
        {
            if (suit == 1)
            {
                return "Clubs";
            }
            if (suit == 2)
            {
                return "Diamonds";
            }
            if (suit == 3)
            {
                return "Spades";
            }
            else
            {
                return "Hearts";
            }
        }

        public string toString()
        {
            return getValueAsString() + "of" + getSuitAsString();
        }
    }
}
