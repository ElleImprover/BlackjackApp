using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
  public class CardManipulation
    {
        Bet bet { get; set; }
        public Card DrawCard() 
        {
           bet.ShuffleDeck();
           return bet.DeckOfCards.Pop();
        }

        public bool PlayBlackJack()
        {
            bool win = false;


            return win;
        }

}
}
