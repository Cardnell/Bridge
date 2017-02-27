using System;

namespace BridgeEngine
{
    public class Dealer
    {
        readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        public Hand[] DealHands()
        {
            var hands =  new Hand[4];
            for (int i = 0; i < 4; i++)
            {
                hands[i] = new Hand();
            }
            var deck= new Deck();

            int handNumber = 0;
            while (deck.Cards.Count > 0)
            {
                Card card = GetCardFromDeck(deck);
                hands[handNumber].AddCard(card);
                handNumber = (handNumber + 1) % 4;
            }
            return hands;
        }

        private Card GetCardFromDeck(Deck deck)
        {
            int numberOfRenainingCards = deck.Cards.Count;
            int index = _random.Next(numberOfRenainingCards);
            Card output = deck.Cards[index];
            deck.Cards.RemoveAt(index);
            return output;
        }
    }
}