using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BridgeEngine
{
    public class Deal
    {
        public Deal()
        {
            Tricks = new List<Trick>();
        }

        public PlayerDirection TurnToPlay { get; set; }
        public IList<Trick> Tricks { get; private set; }
        public CardSuit Trumps { get; set; }

        public void PlayCard(Card card)
        {
            if (Tricks.Count == 0)
            {
                Tricks.Add(new Trick(Trumps));
            }
            Trick lastTrick = Tricks[Tricks.Count - 1];
            if (lastTrick.IsComplete)
            {
                Tricks.Add(new Trick(Trumps));
                lastTrick = Tricks[Tricks.Count - 1];
            }
            lastTrick.AddCard(card, TurnToPlay);
            //Turn to play should rotate in a clockwise direction, which the enum is setup for
            //Except when the trick is complete, in which case the leader is the person who won
            TurnToPlay = lastTrick.IsComplete ? lastTrick.Winner() : (PlayerDirection) (((int) TurnToPlay + 1) % 4);
        }

        public int TricksWon(PlayerDirection player)
        {
            if (player == PlayerDirection.North || player == PlayerDirection.South)
            {
                return Tricks.Count(x => x.Winner() == PlayerDirection.North || x.Winner() == PlayerDirection.South);
            }
            return Tricks.Count(x => x.Winner() == PlayerDirection.East || x.Winner() == PlayerDirection.West);

        }
    }
}