using System.Linq;
using BridgeEngine;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace BridgeEngineTests
{
    [TestFixture]
    public class DealerTests
    {
        [Test]
        public void NormalDealer_DealsHands_ProducesFour()
        {
            var dealer = new Dealer();

            Hand[] hands = dealer.DealHands();

            Assert.That(hands.Length, Is.EqualTo(4));
        }

        [Test]
        public void Dealer_DealsHands_HandsHaveThirteenCards()
        {
            var dealer = new Dealer();

            Hand[] hands = dealer.DealHands();

            foreach (Hand hand in hands)
            {
                Assert.That(hand.NumberOfCards, Is.EqualTo(13));

            }
        }

        [Test]
        public void Dealer_DealsHands_CorrectCards()
        {
            var dealer = new Dealer();
            var deck = new Deck();
            var cardsInDeck = deck.Cards;

            Hand[] hands = dealer.DealHands();
            var totalCardsInHands =
                hands[0].Cards.Union(hands[1].Cards)
                    .Union(hands[2].Cards)
                    .Union(hands[3].Cards).ToList();

            foreach (Card card in cardsInDeck)
            {
                Assert.That(totalCardsInHands, Contains.Item(card));
            }
        }

        [Test]
        public void Dealer_DealsHandsTwice_ShouldBeDifferent()
        {
            var dealerOne = new Dealer();
            var dealerTwo = new Dealer();

            Hand[] hands = dealerOne.DealHands();
            Hand[] otherHands = dealerTwo.DealHands();

            Assert.That(hands[0].Cards, Is.Not.EquivalentTo(otherHands[0].Cards));
        }

        [Test]
        public void Dealer_TakesPBNDealTag_GeneratesCorrectHands()
        {
            var dealText = @"[Deal ""N:.63.AKQ987.A9732 A8654.KQ5.T.QJT6 J973.J98742.3.K4 KQT2.AT.J6542.85""]";
            var dealer = new Dealer();

            Hand[] hands = dealer.DealHandsFromPBN(dealText);

            Hand[] expectedHands = GetPBNHands();

            //north
            Assert.That(hands[0].Cards, Is.EquivalentTo(expectedHands[0].Cards));
            //east
            Assert.That(hands[1].Cards, Is.EquivalentTo(expectedHands[1].Cards));
            //south
            Assert.That(hands[2].Cards, Is.EquivalentTo(expectedHands[2].Cards));
            //west
            Assert.That(hands[3].Cards, Is.EquivalentTo(expectedHands[3].Cards));
        }

        private Hand[] GetPBNHands()
        {
            //.63.AKQ987.A9732
            Hand north = new Hand();
            north.AddCard(new Card(CardRank.Six, CardSuit.Hearts));
            north.AddCard(new Card(CardRank.Three, CardSuit.Hearts));
            north.AddCard(new Card(CardRank.Ace, CardSuit.Diamonds));
            north.AddCard(new Card(CardRank.King, CardSuit.Diamonds));
            north.AddCard(new Card(CardRank.Queen, CardSuit.Diamonds));
            north.AddCard(new Card(CardRank.Nine, CardSuit.Diamonds));
            north.AddCard(new Card(CardRank.Eight, CardSuit.Diamonds));
            north.AddCard(new Card(CardRank.Seven, CardSuit.Diamonds));
            north.AddCard(new Card(CardRank.Ace, CardSuit.Clubs));
            north.AddCard(new Card(CardRank.Nine, CardSuit.Clubs));
            north.AddCard(new Card(CardRank.Seven, CardSuit.Clubs));
            north.AddCard(new Card(CardRank.Three, CardSuit.Clubs));
            north.AddCard(new Card(CardRank.Two, CardSuit.Clubs));

            //A8654.KQ5.T.QJT6
            Hand east = new Hand();
            east.AddCard(new Card(CardRank.Ace, CardSuit.Spades));
            east.AddCard(new Card(CardRank.Eight, CardSuit.Spades));
            east.AddCard(new Card(CardRank.Six, CardSuit.Spades));
            east.AddCard(new Card(CardRank.Five, CardSuit.Spades));
            east.AddCard(new Card(CardRank.Four, CardSuit.Spades));
            east.AddCard(new Card(CardRank.King, CardSuit.Hearts));
            east.AddCard(new Card(CardRank.Queen, CardSuit.Hearts));
            east.AddCard(new Card(CardRank.Five, CardSuit.Hearts));
            east.AddCard(new Card(CardRank.Ten, CardSuit.Diamonds));
            east.AddCard(new Card(CardRank.Queen, CardSuit.Clubs));
            east.AddCard(new Card(CardRank.Jack, CardSuit.Clubs));
            east.AddCard(new Card(CardRank.Ten, CardSuit.Clubs));
            east.AddCard(new Card(CardRank.Six, CardSuit.Clubs));

            //J973.J98742.3.K4
            Hand south = new Hand();
            south.AddCard(new Card(CardRank.Jack, CardSuit.Spades));
            south.AddCard(new Card(CardRank.Nine, CardSuit.Spades));
            south.AddCard(new Card(CardRank.Seven, CardSuit.Spades));
            south.AddCard(new Card(CardRank.Three, CardSuit.Spades));
            south.AddCard(new Card(CardRank.Jack, CardSuit.Hearts));
            south.AddCard(new Card(CardRank.Nine, CardSuit.Hearts));
            south.AddCard(new Card(CardRank.Eight, CardSuit.Hearts));
            south.AddCard(new Card(CardRank.Seven, CardSuit.Hearts));
            south.AddCard(new Card(CardRank.Four, CardSuit.Hearts));
            south.AddCard(new Card(CardRank.Two, CardSuit.Hearts));
            south.AddCard(new Card(CardRank.Three, CardSuit.Diamonds));
            south.AddCard(new Card(CardRank.King, CardSuit.Clubs));
            south.AddCard(new Card(CardRank.Four, CardSuit.Clubs));

            //KQT2.AT.J6542.85
            Hand west = new Hand();
            west.AddCard(new Card(CardRank.King, CardSuit.Spades));
            west.AddCard(new Card(CardRank.Queen, CardSuit.Spades));
            west.AddCard(new Card(CardRank.Ten, CardSuit.Spades));
            west.AddCard(new Card(CardRank.Two, CardSuit.Spades));
            west.AddCard(new Card(CardRank.Ace, CardSuit.Hearts));
            west.AddCard(new Card(CardRank.Ten, CardSuit.Hearts));
            west.AddCard(new Card(CardRank.Jack, CardSuit.Diamonds));
            west.AddCard(new Card(CardRank.Six, CardSuit.Diamonds));
            west.AddCard(new Card(CardRank.Five, CardSuit.Diamonds));
            west.AddCard(new Card(CardRank.Four, CardSuit.Diamonds));
            west.AddCard(new Card(CardRank.Two, CardSuit.Diamonds));
            west.AddCard(new Card(CardRank.Eight, CardSuit.Clubs));
            west.AddCard(new Card(CardRank.Five, CardSuit.Clubs));

            var hands = new Hand[4];
            hands[0] = north;
            hands[1] = east;
            hands[2] = south;
            hands[3] = west;

            return hands;
        }
    }
}