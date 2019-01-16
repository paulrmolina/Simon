using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    class Game
    {
        int CurrentRoundCount = 0;  // Holds current round count needed to generate sequence length
        Round CurrentRound = null;  // Current round object

        public Game ()
        {
            CurrentRoundCount = 0;
            CreateNewRound();
        }

        /// <summary>
        /// Returns a game status object indicating the state of the game after the user's choice
        /// </summary>
        /// <param name="colorChosen"></param>
        /// <returns></returns>
        public GameStatus CheckUserInput(GameColor colorChosen)
        {
            return CurrentRound.CheckUserInput(colorChosen);
        }

        /// <summary>
        /// Creates a new round when called. This assumes the user has either started a new game or won
        /// the previous round
        /// </summary>
        public void CreateNewRound()
        {
            CurrentRound = new Round(++CurrentRoundCount);
        }

        /// <summary>
        /// Returns the current sequence for display on the main window
        /// </summary>
        /// <returns></returns>
        public Queue<GameColor> GetCurrentSequence()
        {
            return this.CurrentRound.GetCurrentSequence();
        }
    }
}
