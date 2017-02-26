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
            for (int i = 2; i < 15; i++)
            {
                Cards.Add(new Card((CardRank)i, suit));
            }
        }

        public List<Card> Cards { get; }
        
          
    }
}