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

        public Card Hit()
        {
            return bet.DeckOfCards.Pop();
        }
        public bool PlayBlackJack()
        {
            bool win = false;
            while (!win)
            {
                Console.Out.WriteLine("Please type 'start' to play or 'x' to exit.");
                var play = Console.ReadLine();
                if (String.Equals(play, "start", StringComparison.CurrentCultureIgnoreCase))
                {

                }
                else if (String.Equals(play, "x", StringComparison.CurrentCultureIgnoreCase))
                {

                }


            }
            return win;

        }
    }
}
