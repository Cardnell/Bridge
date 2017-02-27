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
    }
}