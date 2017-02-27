using System.Collections;
using System.Collections.Generic;

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

        public void PlayCard(Card card)
        {
            if (Tricks.Count == 0)
            {
                Tricks.Add(new Trick(CardSuit.Clubs));
            }
            Trick lastTrick = Tricks[Tricks.Count - 1];
            if (lastTrick.IsComplete)
            {
                Tricks.Add(new Trick(CardSuit.Clubs));
                lastTrick = Tricks[Tricks.Count - 1];
            }
            lastTrick.AddCard(card, TurnToPlay);

            //Turn to play should rotate in a clockwise direction, which the enum is setup for
            TurnToPlay = (PlayerDirection)(((int)TurnToPlay + 1) % 4);
        }
    }
}