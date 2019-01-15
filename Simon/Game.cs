using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    class Game
    {
        int CurrentRoundCount = 0;
        Round CurrentRound = null;

        public Game ()
        {
            CurrentRoundCount = 0;
            CreateNewRound();
        }

        public GameStatus CheckUserInput(GameColor colorChosen)
        {
            return CurrentRound.CheckUserInput(colorChosen);
        }

        public void CreateNewRound()
        {
            CurrentRound = new Round(++CurrentRoundCount);
        }

        public Queue<GameColor> GetCurrentSequence()
        {
            return this.CurrentRound.GetCurrentSequence();
        }
    }
}
