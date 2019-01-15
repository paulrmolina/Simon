using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    class Round
    {
        //private int sequenceLength = 0;
        Sequence RoundSequence = null;

        public Round()
        {
            RoundSequence = new Sequence();
        }
        public Round(int sequenceLength)
        {
            RoundSequence = new Sequence(sequenceLength);
        }

        public GameStatus CheckUserInput(GameColor chosenColor)
        {
            return RoundSequence.CheckUserInput(chosenColor);
        }

        public Queue<GameColor> GetCurrentSequence()
        {
            return this.RoundSequence.GetCurrentSequence();
        }
    }
}
