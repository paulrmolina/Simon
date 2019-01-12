using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon
{
    class Game
    {
        private int _currentRoundCount = 0;
        private Round _currentRound = null;

        public Game ()
        {
            _currentRoundCount = 0;
            CreateNewRound();
        }

        public GameStatus CheckUserInput(GameColor colorChosen)
        {
            return _currentRound.CheckUserInput(colorChosen);
        }

        public void CreateNewRound()
        {
            _currentRound = new Round(++_currentRoundCount);
        }

        public Queue<GameColor> GetCurrentSequence()
        {
            return this._currentRound.GetCurrentSequence();
        }
    }
}
