using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    class Sequence
    {
        private Queue<GameColor> sequence;
        private int sequenceLength;


        public Sequence(int aSequenceLength)
        {
            this.sequenceLength = aSequenceLength;
            sequence = new Queue<GameColor>();
        }

        /// <summary>
        /// Generates a sequence based on the number of possible colors for the game.
        /// </summary>
        public void GenerateSequence()
        {
            int possibleColors = Enum.GetValues(typeof(GameColor)).Cast<int>().Max();

            Random rand = new Random();

            for(int x = 0; x < this.sequenceLength; x++)
            {
                sequence.Enqueue((GameColor)rand.Next(possibleColors));
            }
        }
    }
}
