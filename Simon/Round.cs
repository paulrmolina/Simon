using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    public class Round
    {
        //private int sequenceLength = 0;
        Sequence RoundSequence = null;

        /// <summary>
        /// Creates a new round with a new sequence of the length specified.
        /// </summary>
        /// <param name="sequenceLength">the length of the sequence to be created</param>
        public Round(int sequenceLength)
        {
            RoundSequence = new Sequence(sequenceLength);
        }

        /// <summary>
        /// Returns whether or not the color chosen by the user is the correct one in the sequence.
        /// </summary>
        /// <param name="chosenColor">color chosen by the user</param>
        /// <returns>game status which determines if the user has (in)correctly chosen the color</returns>
        public GameStatus CheckUserInput(GameColor chosenColor)
        {
            return RoundSequence.CheckUserInput(chosenColor);
        }

        /// <summary>
        /// Returns this round's current sequence to the caller.
        /// </summary>
        /// <returns></returns>
        public Queue<GameColor> GetCurrentSequence()
        {
            return RoundSequence.GetCurrentSequence();
        }
    }
}
