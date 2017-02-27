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

        [Test]
        public void Deal_TrickWon_WinnerLeadsToNextTrick()
        {
            Deal deal = SetupDeal();
            List<Card> cards = GetCards();
            deal.PlayCard(cards[0]);
            //This is east who will win the trick
            deal.PlayCard(cards[1]);
            deal.PlayCard(cards[2]);
            deal.PlayCard(cards[3]);

            Assert.That(deal.TurnToPlay, Is.EqualTo(PlayerDirection.East));
        }

        [Test]
        public void Deal_TrumpsSet_PassedOntoTrick()
        {
            Deal deal = SetupDeal();
            deal.Trumps = CardSuit.Hearts;
            deal.PlayCard(GetCard());

            Assert.That(deal.Tricks[0].Trumps, Is.EqualTo(CardSuit.Hearts));
        }

        [TestCase(PlayerDirection.North, 2)]
        [TestCase(PlayerDirection.South, 2)]
        [TestCase(PlayerDirection.East, 1)]
        [TestCase(PlayerDirection.West, 1)]
        public void Deal_TricksWonByPartner_AreAddedTogether(PlayerDirection player, int tricksWon)
        {
            Deal deal = SetupDeal();
            deal.Trumps = CardSuit.Hearts;
            List<Card> cards = GetCards();

            //Three tricks, 
            //N - Qh, Kh, Qc, Kc - Winner east
            //E - Qs, Ks, Qd, Kd - Winner south
            //S - 2d, 3d, 10d, 4d - Winner west
            foreach (Card card in cards)
            {
                deal.PlayCard(card);
            }

            Assert.That(deal.TricksWon(player), Is.EqualTo(tricksWon));
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
                new Card(CardRank.Three, CardSuit.Diamonds),
                new Card(CardRank.Ten, CardSuit.Diamonds),
                new Card(CardRank.Four, CardSuit.Diamonds)
            };
        }

        private Deal SetupDeal()
        {
            return new Deal {TurnToPlay = PlayerDirection.North};
        }
    }
}