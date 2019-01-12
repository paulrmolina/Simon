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
        private Sequence _roundSequence = null;

        public Round()
        {
            _roundSequence = new Sequence();
        }
        public Round(int sequenceLength)
        {
            _roundSequence = new Sequence(sequenceLength);
        }

        public GameStatus CheckUserInput(GameColor chosenColor)
        {
            return _roundSequence.CheckUserInput(chosenColor);
        }

        public Queue<GameColor> GetCurrentSequence()
        {
            return this._roundSequence.GetCurrentSequence();
        }
    }
}
