using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    class Game
    {
        private int currentRoundCount = 0;
        private Round currentRound = null;

        public Game ()
        {
            currentRoundCount = 0;
            CreateNewRound();
        }

        public GameStatus CheckUserInput(GameColor colorChosen)
        {
            return currentRound.CheckUserInput(colorChosen);
        }

        public void CreateNewRound()
        {
            currentRound = new Round(++currentRoundCount);
        }

        public Queue<GameColor> GetCurrentSequence()
        {
            return this.currentRound.GetCurrentSequence();
        }
    }
}
