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

        public Hand[] DealHandsFromPBN(string dealText)
        {
            string relevantText = dealText.Split('"')[1];
            relevantText = relevantText.Substring(2);
            string[] handText = relevantText.Split(' ');

            Hand[] hands = new Hand[4];
            for (int i = 0; i < 4; i++)
            {
                hands[i] = GetHandFromPBN(handText[i]);
            }
            
            return hands;
        }

        private Hand GetHandFromPBN(string handText)
        {
            var output = new Hand();
            string[] suitCards = handText.Split('.');
            var suits = new[] {CardSuit.Spades, CardSuit.Hearts, CardSuit.Diamonds, CardSuit.Clubs};
            for (int i = 0; i < 4; i++)
            {
                AddPBNSuitToHand(output, suits[i], suitCards[i]);
            }
            return output;
        }

        private void AddPBNSuitToHand(Hand hand, CardSuit cardSuit, string cards)
        {
            int i = 0;
            while(i<cards.Length)
            {
                if (cards[i] == '1')
                {
                    hand.AddCard(new Card(CardRank.Ten, cardSuit));
                    i++;
                    i++;
                    continue;
                }
                CardRank rank = GetRankFromChar(cards[i]);
                hand.AddCard(new Card(rank, cardSuit));
                i++;
            }
        }

        private CardRank GetRankFromChar(char cardName)
        {
            if (cardName == 'A' || cardName == 'a')
            {
                return CardRank.Ace;
            }
            if (cardName == 'K' || cardName == 'k')
            {
                return CardRank.King;
            }
            if (cardName == 'Q' || cardName == 'q')
            {
                return CardRank.Queen;
            }
            if (cardName == 'J' || cardName == 'j')
            {
                return CardRank.Jack;
            }
            if (cardName == 'T' || cardName == 't')
            {
                return CardRank.Ten;
            }
            return (CardRank) ((int) char.GetNumericValue(cardName) - 2);
        }
    }
}