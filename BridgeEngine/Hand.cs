using System.Collections.Generic;
using System.Linq;

namespace BridgeEngine
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }

        public int NumberOfCards => Cards.Count;
        public List<Card> Cards { get; }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public IList<Card> GetSuit(CardSuit suit)
        {
            return Cards.Where(x => x.Suit == suit).ToList();
        }
    }
}