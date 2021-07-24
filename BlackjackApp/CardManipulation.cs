using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
    public class CardManipulation
    {
        public List<User> Users { get; set; }
        public List<Card> DealerCards { get; set; }

        public User CurrentUser { get; set; }

        public User Dealer { get; set; }

        public CardManipulation()
        {
            Users = new();
        }
        Bet Bet { get; set; }
        public Card DrawCard()
        {
            Bet.ShuffleDeck();
            return Bet.DeckOfCards.Pop();
        }

        public Card Hit()
        {
            return Bet.DeckOfCards.Pop();
        }
        public static Card RevealCard(Card card)
        {

            if (card.GetType().Equals(typeof(RegularCard)))
            {
                return (RegularCard)card;
            }
            else
            {
                return (FaceCard)card;
            }
        }
        public void ShowHand(User user)
        {
            foreach (var card in user.MyHand)
            {
                Type t = card.GetType();
                if (t.Equals(typeof(RegularCard)))
                {
                    Console.Out.WriteLine(@$"{((RegularCard)card).Regular}");
                }
                else
                {
                    Console.Out.WriteLine(@$"{((FaceCard)card).Face}");
                }
            }
        }

        public bool PlayBlackJack()
        {
            bool done = false;

            bool win = false;
            bool userWin = false;
            int betAmount = 0;
            int userCurTotal = 0;
            int dealerCurTotal = 0;
            string input = "";

            while (!done)
            {
                Console.Out.WriteLine("Please type 'start' to play or 'x' to exit.");
                input = Console.ReadLine();
                if (String.Equals(input, "start", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.Out.WriteLine("Please enter your bet amount as whole dollars or 'x' to exit.");
                    input = Console.ReadLine();
                    bool success = Int32.TryParse(input, out betAmount);
                    if (success)
                    {
                        if (betAmount > 0)
                        {
                            CurrentUser.CurrentBet.AmountUserPutDown = betAmount;
                            CurrentUser.CurrentBet.ShuffleDeck();

                            for (int x = 0; x < 2; x++)
                            {
                                CurrentUser.Hit(Hit());
                                Dealer.Hit(Hit());
                            }
                            userCurTotal = CurrentUser.GetTotalCardAmount();
                            dealerCurTotal = Dealer.GetTotalCardAmount();

                            while (!win)  {
                                Console.Out.WriteLine("Here are your cards");
                                ShowHand(CurrentUser);
                                Console.Out.WriteLine(@$"Your current total is: {userCurTotal}.\nWould you like another hit? Enter 'yes' for a hit, 'stay' or 'x' to exit.\n");
                                 
                                input = Console.ReadLine();
                                if (String.Equals(input, "yes", StringComparison.CurrentCultureIgnoreCase)) {

                                    CurrentUser.Hit(Hit());



                                }
                                else if (String.Equals(input, "stay", StringComparison.CurrentCultureIgnoreCase)) {
                                    Dealer.Hit(Hit());
                                    dealerCurTotal = Dealer.GetTotalCardAmount();
                                    Console.Out.WriteLine("Here are the dealer's cards:\n");
                                    ShowHand(Dealer);
                                    Console.Out.WriteLine(@$"Your current total is: {userCurTotal}.\nThe Dealer total is: {dealerCurTotal}.\n");



                                }
                                else if (String.Equals(input, "x", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    win = true;
                                    done = true;
                                }
                            }
                        }
                        else
                        {
                            Console.Out.WriteLine("Bet amount must be greater than 0.");

                        }
                    }
                    else
                    {
                        Console.Out.WriteLine("Please enter a valid amount in whole numbers.");
                    }

                    Users.Add(CurrentUser);
                }
                else if (String.Equals(input, "x", StringComparison.CurrentCultureIgnoreCase))
                {
                    done = true;
                }

            }
            return userWin;

        }


    }
}
