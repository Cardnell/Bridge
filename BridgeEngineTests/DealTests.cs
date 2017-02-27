using System.Collections.Generic;
using BridgeEngine;
using NUnit.Framework;

namespace BridgeEngineTests
{
    [TestFixture]
    public class DealTests
    {
        [TestCase(PlayerDirection.North, PlayerDirection.East)]
        [TestCase(PlayerDirection.East, PlayerDirection.South)]
        [TestCase(PlayerDirection.South, PlayerDirection.West)]
        [TestCase(PlayerDirection.West, PlayerDirection.North)]
        public void Deal_WhenPlaying_OrderIsClockwise(PlayerDirection original, PlayerDirection expected)
        {
            Deal deal = SetupDeal();
            Card card = GetCard();

            deal.TurnToPlay = original;
            deal.PlayCard(card);

            Assert.That(deal.TurnToPlay, Is.EqualTo(expected));
        }

        [Test]
        public void Deal_NoCardsPlayed_NoTricks()
        {
            Deal deal = SetupDeal();

            Assert.That(deal.Tricks.Count, Is.EqualTo(0));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 2)]
        [TestCase(9, 3)]
        public void Deal_CardsPlayed_CurrectTricksCreated(int cardsToPLay, int tricksPlayed)
        {
            Deal deal = SetupDeal();
            IList<Card> cards = GetCards();
            for (int i = 0; i < cardsToPLay; i++)
            {
                deal.PlayCard(cards[i]);
            }

            Assert.That(deal.Tricks.Count, Is.EqualTo(tricksPlayed));
        }


        [Test]
        public void Deal_CardPlayed_CardInTrick()
        {
            Deal deal = SetupDeal();
            Card card = GetCard();
            PlayerDirection player = deal.TurnToPlay;
            deal.PlayCard(card);

            Assert.That(deal.Tricks[0].GetCard(player), Is.EqualTo(card));
        }

        private Card GetCard()
        {
            return new Card(CardRank.Queen, CardSuit.Hearts);
        }

        private List<Card> GetCards()
        {
            return new List<Card>()
            {
                new Card(CardRank.Queen, CardSuit.Hearts),
                new Card(CardRank.King, CardSuit.Hearts),
                new Card(CardRank.Queen, CardSuit.Clubs),
                new Card(CardRank.King, CardSuit.Clubs),
                new Card(CardRank.Queen, CardSuit.Spades),
                new Card(CardRank.King, CardSuit.Spades),
                new Card(CardRank.Queen, CardSuit.Diamonds),
                new Card(CardRank.King, CardSuit.Diamonds),
                new Card(CardRank.Two, CardSuit.Diamonds),
                new Card(CardRank.Ten, CardSuit.Diamonds)
            };
        }

        private Deal SetupDeal()
        {
            return new Deal {TurnToPlay = PlayerDirection.North};
        }
    }
}