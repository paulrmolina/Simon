﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    class Sequence
    {
        Queue<GameColor> CurrentSequence = null;    // Holds the current sequence of colors for the round
        int SequenceLength = 0;                     // Determines how many colors will be chosen

        /// <summary>
        /// Creates a sequence of a certain length.
        /// </summary>
        /// <param name="aSequenceLength">how long the sequence should be</param>
        public Sequence(int aSequenceLength)
        {
            SequenceLength = aSequenceLength;
            CurrentSequence = new Queue<GameColor>();
            GenerateSequence();
        }

        /// <summary>
        /// Generates a sequence based on the number of possible colors for the game.
        /// </summary>
        public void GenerateSequence()
        {
            int possibleColors = Enum.GetValues(typeof(GameColor)).Cast<int>().Max() + 1;

            Random rand = new Random();

            for(int x = 0; x < this.SequenceLength; x++)
            {
                CurrentSequence.Enqueue((GameColor)rand.Next(possibleColors));
            }
        }

        /// <summary>
        /// Checks if the user's input matches this sequence's input. 
        /// </summary>
        /// <param name="chosenColor"></param>
        /// <returns></returns>
        public GameStatus CheckUserInput(GameColor chosenColor)
        {
            try
            {
                GameColor colorToTestAgainst = CurrentSequence.Dequeue();

                // If the user chooses the wrong color the game will be over.
                if (chosenColor != colorToTestAgainst)
                {
                    return GameStatus.GAME_OVER;
                }
                // If the user has not lost the game and the count of the colors is 0, they have won the round
                if(CurrentSequence.Count == 0)
                {
                    return GameStatus.WON_ROUND;
                }
                // Otherwise, the user is still winning
                else
                {
                    return GameStatus.WINNING;
                }
            } catch(NullReferenceException e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                Console.WriteLine("Error. Sequence Generation may be broken!");
                return GameStatus.GAME_OVER;

            }
        }

        /// <summary>
        /// Returns a copy of this current sequence.
        /// </summary>
        /// <returns>A copy of the current sequence.</returns>
        public Queue<GameColor> GetCurrentSequence()
        {
            return new Queue<GameColor>(CurrentSequence);
        }
    }
}
