using System.Collections.Generic;

namespace BridgeEngine
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
            AddFullSuit(CardSuit.Clubs);
            AddFullSuit(CardSuit.Diamonds);
            AddFullSuit(CardSuit.Hearts);
            AddFullSuit(CardSuit.Spades);
        }

        private void AddFullSuit(CardSuit suit)
        {
            for (int i = 0; i < 13; i++)
            {
                Cards.Add(new Card((CardRank)i, suit));
            }
        }

        public List<Card> Cards { get; }
        
          
    }
}