using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackApp
{
   public class Bet
    {
        public int BetOrderID { get; set; }
        public int AmountUserPutDown { get; set; }
        public int AmountUserGained { get; set; }
        public Stack<Card> DeckOfCards { get; set; }


        public Bet()
        {
          DeckOfCards = new();
          CreateDeck();
        }

        public void CreateDeck()
        {
            DeckOfCards = new();
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two,Suit = Suit.Clubs, ID = 1 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two, Suit = Suit.Diamond, ID = 2 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two, Suit = Suit.Heart, ID = 3 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two, Suit = Suit.Spades, ID = 4 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, Suit = Suit.Clubs, ID = 5 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, Suit = Suit.Diamond, ID = 6 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, Suit = Suit.Heart, ID = 7 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, Suit = Suit.Spades, ID = 8 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, Suit = Suit.Clubs, ID = 9 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, Suit = Suit.Diamond, ID = 10 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, Suit = Suit.Heart, ID = 11 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, Suit = Suit.Spades, ID = 12 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, Suit = Suit.Clubs, ID = 13 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, Suit = Suit.Diamond, ID = 14 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, Suit = Suit.Heart, ID = 15 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, Suit = Suit.Spades, ID = 16 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, Suit = Suit.Clubs, ID = 17 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, Suit = Suit.Diamond, ID = 18 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, Suit = Suit.Heart, ID = 19 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, Suit = Suit.Spades, ID = 20 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, Suit = Suit.Clubs, ID = 21 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, Suit = Suit.Diamond, ID = 22 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, Suit = Suit.Heart, ID = 23 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, Suit = Suit.Spades, ID = 24 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, Suit = Suit.Clubs, ID = 25 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, Suit = Suit.Diamond, ID = 26 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, Suit = Suit.Heart, ID = 27 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, Suit = Suit.Spades, ID = 28 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, Suit = Suit.Clubs, ID = 29 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, Suit = Suit.Diamond, ID = 30 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, Suit = Suit.Heart, ID = 31 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, Suit = Suit.Spades, ID = 32 });

            DeckOfCards.Push(new FaceCard { Face = Face.Queen, Suit = Suit.Clubs, ID = 33 });
            DeckOfCards.Push(new FaceCard { Face = Face.Queen, Suit = Suit.Diamond, ID = 34 });
            DeckOfCards.Push(new FaceCard { Face = Face.Queen, Suit = Suit.Heart, ID = 35 });
            DeckOfCards.Push(new FaceCard { Face = Face.Queen, Suit = Suit.Spades, ID = 36 });

            DeckOfCards.Push(new FaceCard { Face = Face.King, Suit = Suit.Clubs, ID = 37 });
            DeckOfCards.Push(new FaceCard { Face = Face.King, Suit = Suit.Diamond, ID = 38 });
            DeckOfCards.Push(new FaceCard { Face = Face.King, Suit = Suit.Heart, ID = 39 });
            DeckOfCards.Push(new FaceCard { Face = Face.King, Suit = Suit.Spades, ID = 40 });

            DeckOfCards.Push(new FaceCard { Face = Face.Jack, Suit = Suit.Clubs, ID = 41 });
            DeckOfCards.Push(new FaceCard { Face = Face.Jack, Suit = Suit.Diamond, ID = 42 });
            DeckOfCards.Push(new FaceCard { Face = Face.Jack, Suit = Suit.Heart, ID = 43 });
            DeckOfCards.Push(new FaceCard { Face = Face.Jack, Suit = Suit.Spades, ID = 44 });

            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Clubs, ID = 45 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Diamond, ID = 46 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Heart, ID = 47 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Spades, ID = 48 });

            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Clubs, ID = 49 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Diamond, ID = 50 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Heart, ID = 51 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, Suit = Suit.Spades, ID = 52 });
        }
        public void ShuffleDeck() {

            var deckList = DeckOfCards.ToList();
            var half = 0;
            if (DeckOfCards.Count % 2 == 0) {
                half = DeckOfCards.Count / 2;
            }
            else {
                half = DeckOfCards.Count +1 / 2;
            }
            for (int x = 0; x < half; x++) {
              Random random = new Random();
              var position = random.Next(1, DeckOfCards.Count-1);
              var card = deckList.ElementAt(position);
              deckList.Add(card);
              deckList.RemoveAt(position);
              deckList.Reverse(0, half);  
            }

            DeckOfCards = new Stack<Card>(deckList);

           // return new Stack<Card>(deckList);
        }
        public Card DrawCard()
        {
            ShuffleDeck();
            return DeckOfCards.Pop();
        }

        public Card Hit()
        {
            return DeckOfCards.Pop();
        }
    }
}
