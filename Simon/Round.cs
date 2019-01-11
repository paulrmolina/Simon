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
        private Sequence roundSequence = null;

        public Round()
        {
            roundSequence = new Sequence();
        }
        public Round(int sequenceLength)
        {
            roundSequence = new Sequence(sequenceLength);
        }

        public GameStatus CheckUserInput(GameColor chosenColor)
        {
            return roundSequence.CheckUserInput(chosenColor);
        }

        public Queue<GameColor> GetCurrentSequence()
        {
            return this.roundSequence.GetCurrentSequence();
        }
    }
}
