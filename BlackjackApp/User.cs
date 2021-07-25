using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
   public class User
    {
       // public Bet CurrentBet { get; set; }
       // public List<Bet> AllBets { get; set; }
        public List<Card> MyHand { get; set; }
        public double AmountUserPutDown { get; set; }
        public int CardHandTotal { get; set; }

        public double AmountUserWonOrLost { get; set; }
        public User()
        {
           // CurrentBet = new Bet();
            //AllBets = new List<Bet>();
            MyHand = new List<Card>();
        }
        public void Hit(Card card)
        { 
            MyHand.Add(card);
        }


        public int GetTotalCardAmount()
        {
            var total = 0;

            foreach (var curCard in MyHand)
            {
                //everything but aces
                if (curCard.ID < 44) {
                    total += GetCardAmountNotIncludingAces(curCard);
                }
                else
                {
                    if (total <= 11)
                    {
                        total += 10;
                    }
                    else
                    {
                        total += 1;
                    }
                }

            }
            CardHandTotal = total;
            return total;

        }

        public int UpdateTotalCardAmount(Card curCard)
        {
            Hit(curCard);
            var total = CardHandTotal;
                //everything but aces
                if (curCard.ID < 44) {
                    total += GetCardAmountNotIncludingAces(curCard);
                }
                else
                {
                    if (total <= 11) {
                        total += 10;
                    }
                    else  {
                        total += 1;
                    }
                }

            
            CardHandTotal = total;
            return total;

        }

        public static int GetCardAmountNotIncludingAces(Card card)
        {
            Type t = card.GetType();
            if (t.Equals(typeof(RegularCard)))
            {
                return (int)((RegularCard)card).Regular;
            }
            else
            {
                return 10;
            }
        }

    }
}
