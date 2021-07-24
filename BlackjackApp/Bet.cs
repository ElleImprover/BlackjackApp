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
        public int AmountPutDown { get; set; }
        public int AmountGained { get; set; }
        public Stack<Card> DeckOfCards { get; set; }

        public Bet()
        {
            CreateDeck();
        }

        public void CreateDeck()
        {
            DeckOfCards = new();
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two, ID = 1 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two, ID = 2 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two, ID = 3 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Two, ID = 4 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, ID = 5 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, ID = 6 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, ID = 7 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Three, ID = 8 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, ID = 9 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, ID = 10 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, ID = 11 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Four, ID = 12 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, ID = 13 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, ID = 14 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, ID = 15 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Five, ID = 16 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, ID = 17 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, ID = 18 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, ID = 19 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Six, ID = 20 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, ID = 21 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, ID = 22 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, ID = 23 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Seven, ID = 24 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, ID = 25 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, ID = 26 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, ID = 27 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Eight, ID = 28 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, ID = 29 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, ID = 30 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, ID = 31 });
            DeckOfCards.Push(new RegularCard { Regular = Regular.Nine, ID = 32 });

            DeckOfCards.Push(new FaceCard { Face = Face.Queen, ID = 33 });
            DeckOfCards.Push(new FaceCard { Face = Face.Queen, ID = 34 });
            DeckOfCards.Push(new FaceCard { Face = Face.Queen, ID = 35 });
            DeckOfCards.Push(new FaceCard { Face = Face.Queen, ID = 36 });

            DeckOfCards.Push(new FaceCard { Face = Face.King, ID = 37 });
            DeckOfCards.Push(new FaceCard { Face = Face.King, ID = 38 });
            DeckOfCards.Push(new FaceCard { Face = Face.King, ID = 39 });
            DeckOfCards.Push(new FaceCard { Face = Face.King, ID = 40 });

            DeckOfCards.Push(new FaceCard { Face = Face.Jack, ID = 41 });
            DeckOfCards.Push(new FaceCard { Face = Face.Jack, ID = 42 });
            DeckOfCards.Push(new FaceCard { Face = Face.Jack, ID = 43 });
            DeckOfCards.Push(new FaceCard { Face = Face.Jack, ID = 44 });

            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 45 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 46 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 47 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 48 });

            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 49 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 50 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 51 });
            DeckOfCards.Push(new FaceCard { Face = Face.Ace1, ID = 52 });
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

    }
}
