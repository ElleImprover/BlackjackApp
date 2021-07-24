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
            CurrentUser = new User();
            Dealer = new User();
            Users = new List<User>();
            DealerCards = new List<Card>();

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
                    Console.Out.WriteLine(@$"{((RegularCard)card).Regular} of {((RegularCard)card).Suit}");
                }
                else
                {
                    Console.Out.WriteLine(@$"{((FaceCard)card).Face} of {((FaceCard)card).Suit}");
                }
            }
        }
        public void ShowDealerFirstHand(User dealer)
        {
            int i = 0;
            foreach (var card in dealer.MyHand)
            {
                    Type t = card.GetType();
                if (i < 1)
                {
                    if (t.Equals(typeof(RegularCard)))
                    {
                        Console.Out.WriteLine(@$"{((RegularCard)card).Regular} of {((RegularCard)card).Suit}");
                    }
                    else
                    {
                        Console.Out.WriteLine(@$"{((FaceCard)card).Face} of {((FaceCard)card).Suit}");
                    }
                }
                else
                {
                    Console.Out.WriteLine(@$"? of ?");

                }

                i++;
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
                            this.CurrentUser.CurrentBet.AmountUserPutDown = betAmount;
                            this.CurrentUser.CurrentBet.ShuffleDeck();

                            for (int x = 0; x < 2; x++)
                            {
                                CurrentUser.Hit(Hit());
                                Dealer.Hit(Hit());
                            }
                            userCurTotal   = CurrentUser.GetTotalCardAmount();
                            dealerCurTotal = Dealer.GetTotalCardAmount();

                            while (!win) 
                            {
                                Console.Out.WriteLine("Here are your cards");
                                ShowHand(CurrentUser);
                                Console.Out.WriteLine(@$"Your current total is: {userCurTotal}.\nWould you like another hit? Enter 'yes' for a hit, 'stay' or 'x' to exit.\n");
                                 
                                input = Console.ReadLine();
                                if (String.Equals(input, "yes", StringComparison.CurrentCultureIgnoreCase)) {

                                    userCurTotal = CurrentUser.UpdateTotalCardAmount(Hit());
                                }
                                else if (String.Equals(input, "stay", StringComparison.CurrentCultureIgnoreCase)) {

                                    dealerCurTotal = Dealer.UpdateTotalCardAmount(Hit());
                                    Console.Out.WriteLine("Here are the dealer's cards:\n");
                                    ShowHand(Dealer);
                                    Console.Out.WriteLine(@$"The Dealer total is: {dealerCurTotal}.\n");
                               

                                }
                                else if (String.Equals(input, "x", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    win = true; 
                                    done = true;
                                    break;
                                }
                                if (dealerCurTotal > 21&& userCurTotal <= 21)
                                {
                                    Console.Out.WriteLine(@$"You won!\n");
                                    userWin = true;
                                    win = true;
                                    done = true;
                                    break;
                                }
                                else if (userCurTotal > 21&& dealerCurTotal <= 21)
                                {
                                    Console.Out.WriteLine(@$"You lost.\n");
                                    userWin = false;
                                    win = true;
                                    done = true;
                                    break;
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
