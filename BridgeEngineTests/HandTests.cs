using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeEngine;
using NUnit.Framework;

namespace BridgeEngineTests
{
    [TestFixture]
    public class HandTests
    {
        [Test]
        public void EmptyHand_AddCard_CorrectCardExists()
        {
            var hand = new Hand();
            var card = new Card(CardRank.Three, CardSuit.Hearts);

            hand.AddCard(card);


            Assert.That(hand.NumberOfCards, Is.EqualTo(1));
            Assert.That(hand.Cards[0].Suit, Is.EqualTo(card.Suit));
            Assert.That(hand.Cards[0].Rank, Is.EqualTo(card.Rank));
        }

        [Test]
        public void MultipleSuits_GetCardsInSuit_ReturnsCorrect()
        {
            var hand = new Hand();
            var firstClub = new Card(CardRank.Two, CardSuit.Clubs);
            var firstHeart = new Card(CardRank.Three, CardSuit.Hearts);
            var secondClub = new Card(CardRank.Four, CardSuit.Clubs);
            hand.AddCard(firstClub);
            hand.AddCard(firstHeart);
            hand.AddCard(secondClub);

            IList<Card> clubs = hand.GetSuit(CardSuit.Clubs);

            Assert.That(clubs.Count, Is.EqualTo(2));
            Assert.That(clubs, Contains.Item(firstClub));
            Assert.That(clubs, Contains.Item(secondClub));
        }

    }
}
