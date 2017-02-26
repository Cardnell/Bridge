using BridgeEngine;
using NUnit.Framework;

namespace BridgeEngineTests
{
    [TestFixture]
    public class TrickTests
    {
        [Test]
        public void Trick_SameSuit_HighestCardWins()
        {
            var trick = new Trick(CardSuit.Clubs);

            var firstCard = new Card(CardRank.Five, CardSuit.Clubs);
            var secondCard = new Card(CardRank.Eight, CardSuit.Clubs);
            var thirdCard = new Card(CardRank.Nine, CardSuit.Clubs);
            var fourCard = new Card(CardRank.Two, CardSuit.Clubs);

            trick.AddCard(firstCard, PlayerDirection.North);
            trick.AddCard(secondCard, PlayerDirection.East);
            trick.AddCard(thirdCard, PlayerDirection.South);
            trick.AddCard(fourCard, PlayerDirection.West);

            Assert.That(trick.Winner(), Is.EqualTo(PlayerDirection.South));
        }

        [Test]
        public void Trick_PlayerDiscards_DiscardLoses()
        {
            var trick = new Trick(CardSuit.Clubs);

            var firstCard = new Card(CardRank.Five, CardSuit.Clubs);
            var secondCard = new Card(CardRank.Eight, CardSuit.Clubs);
            var thirdCard = new Card(CardRank.Nine, CardSuit.Spades);
            var fourCard = new Card(CardRank.Two, CardSuit.Clubs);

            trick.AddCard(firstCard, PlayerDirection.North);
            trick.AddCard(secondCard, PlayerDirection.East);
            trick.AddCard(thirdCard, PlayerDirection.South);
            trick.AddCard(fourCard, PlayerDirection.West);

            Assert.That(trick.Winner(), Is.EqualTo(PlayerDirection.East));
        }

        [Test]
        public void Trick_PlayerTrumps_TrumpWins()
        {
            var trick = new Trick(CardSuit.Spades);

            var firstCard = new Card(CardRank.Five, CardSuit.Clubs);
            var secondCard = new Card(CardRank.Eight, CardSuit.Clubs);
            var thirdCard = new Card(CardRank.Nine, CardSuit.Clubs);
            var fourCard = new Card(CardRank.Two, CardSuit.Spades);

            trick.AddCard(firstCard, PlayerDirection.North);
            trick.AddCard(secondCard, PlayerDirection.East);
            trick.AddCard(thirdCard, PlayerDirection.South);
            trick.AddCard(fourCard, PlayerDirection.West);

            Assert.That(trick.Winner(), Is.EqualTo(PlayerDirection.West));
        }

    }
}