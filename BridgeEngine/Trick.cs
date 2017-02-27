using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgeEngine
{
    public class Trick
    {
        private readonly List<Tuple<Card, PlayerDirection>> _cards = new List<Tuple<Card, PlayerDirection>>();
        public CardSuit Trumps { get; }

        public bool IsComplete => _cards.Count == 4;

        public Trick(CardSuit trumps)
        {
            Trumps = trumps;
        }

        public PlayerDirection Winner()
        {
            Tuple<Card, PlayerDirection> max = _cards[0];
            CardSuit suit = max.Item1.Suit;
            foreach (Tuple<Card, PlayerDirection> cardPlayed in _cards)
            {
                if (max.Item1.Suit == Trumps)
                {
                    if (cardPlayed.Item1.Suit == Trumps && cardPlayed.Item1.Rank > max.Item1.Rank)
                    {
                        max = cardPlayed;
                    }
                }
                else if (cardPlayed.Item1.Rank > max.Item1.Rank && cardPlayed.Item1.Suit == suit)
                {
                    max = cardPlayed;
                }
                else if (cardPlayed.Item1.Suit == Trumps)
                {
                    max = cardPlayed;
                }
            }
            return max.Item2;
        }

        public void AddCard(Card card, PlayerDirection direction)
        {
            _cards.Add(new Tuple<Card, PlayerDirection>(card, direction));
        }

        public Card GetCard(PlayerDirection player)
        {
            return _cards.Where(x => x.Item2 == player).Select(x=>x.Item1).First();
        }

    }
}