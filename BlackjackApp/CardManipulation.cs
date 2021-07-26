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
        public static void ShowHand(User user)
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
        public static void ShowDealerFirstHand(User dealer)
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
            bool userWin = false;
            bool done = false;
            while (!done)
            {
                Bet = new Bet();
                CurrentUser = new User();
                Dealer = new User();
                // Users = new List<User>();
                DealerCards = new List<Card>();
                bool win = false;

                int betAmount = 0;
                int userCurTotal = 0;
                int dealerCurTotal = 0;
                double amtWonOrLost = 0;
                string input = "";


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
                            this.CurrentUser.AmountUserPutDown = betAmount;
                            Bet.ShuffleDeck();

                            for (int x = 0; x < 2; x++)
                            {
                                CurrentUser.Hit(Bet.Hit());
                                Dealer.Hit(Bet.Hit());
                            }
                            userCurTotal = CurrentUser.GetTotalCardAmount();
                            dealerCurTotal = Dealer.GetTotalCardAmount();
                            Console.Out.WriteLine("Here are your cards:");
                            ShowHand(CurrentUser);
                            Console.Out.WriteLine(@$"Your current total is: {userCurTotal}.");
                            Console.Out.WriteLine("Here are the dealer's cards:");
                            ShowDealerFirstHand(Dealer);
                            while (!win)
                            {
                                Console.Out.WriteLine(@$"Would you like another hit? Enter 'yes' for a hit, 'stay' or 'x' to exit.");

                                input = Console.ReadLine();
                                if (String.Equals(input, "yes", StringComparison.CurrentCultureIgnoreCase))
                                {

                                    userCurTotal = CurrentUser.UpdateTotalCardAmount(Hit());

                                    Console.Out.WriteLine("Here are all of your cards:\n");
                                    ShowHand(CurrentUser);
                                    Console.Out.WriteLine(@$"Your current total is: {userCurTotal}.");
                                    Console.Out.WriteLine("Here are the dealer's cards:");
                                    ShowHand(Dealer);
                                    Console.Out.WriteLine(@$"The dealer's total is: {dealerCurTotal}.");
                                }
                                else if (String.Equals(input, "stay", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if (dealerCurTotal < 17)
                                    {
                                        dealerCurTotal = Dealer.UpdateTotalCardAmount(Hit());
                                    }
                                    Console.Out.WriteLine("Here are the dealer's cards:");
                                    ShowHand(Dealer);
                                    Console.Out.WriteLine(@$"The dealer's total is: {dealerCurTotal}.");
                                }
                                else if (String.Equals(input, "x", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    done = true;
                                    break;
                                }
                                else
                                {
                                    Console.Out.WriteLine(@$"Your input was invalid.");

                                }
                                if (dealerCurTotal > 21 && userCurTotal <= 21)
                                {
                                    amtWonOrLost = 1.5 * CurrentUser.AmountUserPutDown;
                                    Dealer.AmountUserWonOrLost -= amtWonOrLost;
                                    CurrentUser.AmountUserWonOrLost += amtWonOrLost;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Out.WriteLine(@$"You won ${amtWonOrLost}!");
                                    Console.ResetColor();

                                    userWin = true;
                                    win = true;
                                    break;
                                }
                                else if (userCurTotal > 21 && dealerCurTotal <= 21)
                                {
                                    amtWonOrLost = CurrentUser.AmountUserPutDown;
                                    Dealer.AmountUserWonOrLost += amtWonOrLost;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    CurrentUser.AmountUserWonOrLost -= amtWonOrLost;
                                    Console.Out.WriteLine(@$"You lost ${amtWonOrLost}.");
                                    Console.ResetColor();

                                    userWin = false;
                                    win = true;
                                    break;
                                }
                                else if (userCurTotal > dealerCurTotal && userCurTotal <= 21 && dealerCurTotal >= 17 && (input.Equals("stay", StringComparison.CurrentCultureIgnoreCase)))//|| input.Equals("hit", StringComparison.CurrentCultureIgnoreCase)))
                                {
                                    amtWonOrLost = CurrentUser.AmountUserPutDown;
                                    Dealer.AmountUserWonOrLost -= amtWonOrLost;
                                    CurrentUser.AmountUserWonOrLost += amtWonOrLost;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Out.WriteLine(@$"You won ${amtWonOrLost}!");
                                    Console.ResetColor();
                                    userWin = true;
                                    win = true;
                                    break;
                                }
                                else if (userCurTotal == dealerCurTotal && userCurTotal <= 21 && dealerCurTotal >= 17 && (input.Equals("stay", StringComparison.CurrentCultureIgnoreCase)))//|| input.Equals("hit", StringComparison.CurrentCultureIgnoreCase)))
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Out.WriteLine("It's a tie!\nNo wins, but no losses.");
                                    Console.ResetColor();
                                    userWin = false;
                                    win = true;
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
