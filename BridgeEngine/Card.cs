using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeEngine
{
    public struct Card
    {
        public CardSuit Suit { get; }
        public CardRank Rank { get; }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
