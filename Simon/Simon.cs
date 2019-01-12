using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Simon
{
    public partial class Simon : Form
    {
        Game currentGame = null;                    // Holds the current playing game.
        private bool gameIsPlaying = false;         // Determines whether a game is currently being played
        private bool sequenceIsDisplaying = false;  // Determines if sequence is being displayed to avoid erroneous inputs
        private int currentRound = 0;               // Holds the current round the user is playing
        private int highestRound = 0;               // Holds high score
        private int timeBetweenLights = 500;       // Determines the default time between light on/off in milliseconds
        private int timeBetweenRounds = 2000;       // Determines default time between rounds in milliseconds

        // For Sounds
        SoundPlayer soundPlayer = null;
        Stream greenSound = null;
        Stream redSound = null;
        Stream yellowSound = null;
        Stream blueSound = null;

        private Button[] buttonArray = null;

        public Simon()
        {
            InitializeComponent();

            // Add all buttons to common array for easier handling
            buttonArray = new Button[4];
            buttonArray[(int)GameColor.Green] = greenButton;
            buttonArray[(int)GameColor.Red] = redButton;
            buttonArray[(int)GameColor.Yellow] = yellowButton;
            buttonArray[(int)GameColor.Blue] = blueButton;

            // Set up sounds
            soundPlayer = new SoundPlayer();
            greenSound = Properties.Resources.piano_d;
            redSound = Properties.Resources.piano_e;
            yellowSound = Properties.Resources.piano_f;
            blueSound = Properties.Resources.piano_g;

            ShowIntroduction();
        }

        /// <summary>
        /// Handles what to do after a user has placed an input during a running game.
        /// </summary>
        /// <param name="gameStatus"></param>
        private void CheckGameStatus(GameStatus gameStatus)
        {
            switch (gameStatus)
            {
                case GameStatus.GAME_OVER:
                    HandleGameOver();
                    break;
                case GameStatus.WON_ROUND:
                    //TurnAllLightsOff();
                    //this.Refresh();
                    RefreshCurrentRoundCount();
                    //Wait(timeBetweenRounds);
                    HandleNewRound();
                    break;
                case GameStatus.WINNING:
                    // Do nothing for now
                    break;
            }
        }

        /// <summary>
        /// Disables all of the lights in the game from being able to be clicked.
        /// </summary>
        private void DisableAllLights()
        {
            foreach(Button btn in buttonArray)
            {
                btn.Enabled = false;
            }
        }

        /// <summary>
        /// Displays a sequence of colors in order.
        /// </summary>
        /// <param name="sequence">the sequence to display</param>
        private void DisplaySequence(Queue<GameColor> sequence)
        {
            this.sequenceIsDisplaying = true;
            GameColor temp;
            while (sequence.Count != 0)
            {
                temp = sequence.Dequeue();
                

                switch (temp)
                {
                    case GameColor.Green:
                        TurnGreenLightOn();
                        Wait(timeBetweenLights);
                        TurnGreenLightOff();
                        Wait(timeBetweenLights);
                        break;
                    case GameColor.Red:
                        TurnRedLightOn();
                        Wait(timeBetweenLights);
                        TurnRedLightOff();
                        Wait(timeBetweenLights);
                        break;
                    case GameColor.Yellow:
                        TurnYellowLightOn();
                        Wait(timeBetweenLights);;
                        TurnYellowLightOff();
                        Wait(timeBetweenLights);
                        break;
                    case GameColor.Blue:
                        TurnBlueLightOn();
                        Wait(timeBetweenLights);
                        TurnBlueLightOff();
                        Wait(timeBetweenLights);
                        break;
                    default:
                        TurnGreenLightOff();
                        TurnRedLightOff();
                        TurnYellowLightOff();
                        TurnBlueLightOff();
                        break;
                }

                TurnAllLightsOff();
                //this.Refresh();
            }
            // Wait a second to avoid erroneous input between thread execution
            Wait(1);
            this.sequenceIsDisplaying = false;
        }

        /// <summary>
        /// Enables all of the lights in the game.
        /// </summary>
        private void EnableAllLights()
        {
            foreach(Button btn in buttonArray)
            {
                btn.Enabled = true;
            }
        }

        /// <summary>
        /// Handles what happens at the UI level when the game is over.
        /// </summary>
        private void HandleGameOver()
        {
            MessageBox.Show(String.Format("Game over! Your highest level was: {0}", currentRound));

            // Update the high score
            if(highestRound <= currentRound)
            {
                highestRound = currentRound;
            }
            highScore.Text = highestRound.ToString();
            
            // Cleanup after game over
            currentRound = 0;
            gameIsPlaying = false;
            startButton.Enabled = true;
        }

        /// <summary>
        /// Handles what happens when the user proceeds to the next round.
        /// </summary>
        private void HandleNewRound()
        {
            // Disables All Lights
            DisableAllLights();

            // Create new round
            this.currentGame.CreateNewRound();

            // Graphics Update
            TurnAllLightsOff();
            this.Refresh();

            // TODO: ADD THAT YOU WON THE ROUND AND WAIT A SECOND BEFORE DISPLAYING THE NEXT ONE. FOR NOW JUST WAIT
            ///var TIMEOUT = 1;
            //var timeBetweenOnOff = DateTime.Now;
            ///while ((DateTime.Now - timeBetweenOnOff) < TimeSpan.FromSeconds(TIMEOUT)) ;
            Wait(timeBetweenRounds);
            
            // Making the display sequence method run on its own thread avoids the issue of
            // enqueuing mouseUp commands on the lights causing the game to erroneously end if
            // the user clicks a button while displaying.
            Thread displayThread = new Thread(() => DisplaySequence(currentGame.GetCurrentSequence()));
            displayThread.Start();

            // Re-Enable all lights
            EnableAllLights();
        }

        private void RefreshCurrentRoundCount()
        {
            currentRound += 1;
            currentScore.Text = currentRound.ToString();
        }

        /// <summary>
        /// Pretty introduction for the game. TODO: Finish this
        /// </summary>
        private void ShowIntroduction()
        {

            TurnAllLightsOff();
        }

        #region Light Manipulation
        /// <summary>
        /// Turns off all of the lights in the game.
        /// </summary>
        private void TurnAllLightsOff()
        {
            TurnGreenLightOff();
            TurnRedLightOff();
            TurnYellowLightOff();
            TurnBlueLightOff();
        }

        private void TurnAllLightsOn()
        {
            TurnGreenLightOn();
            TurnRedLightOff();
            TurnYellowLightOn();
            TurnBlueLightOn();
        }

        /// <summary>
        /// Turns blue light element off.
        /// </summary>
        private void TurnBlueLightOff()
        {
            blueButton.BackColor = Color.Navy;

        }

        /// <summary>
        /// Turns blue light element on.
        /// </summary>
        private void TurnBlueLightOn()
        {
            // Sound
            blueSound.Position = 0;    // rewind from previous position
            soundPlayer.Stream = null; // clear out previous sound
            soundPlayer.Stream = blueSound;
            soundPlayer.Play();

            // Lights
            blueButton.BackColor = Color.Blue;
        }

        /// <summary>
        /// Turns green light element off.
        /// </summary>
        private void TurnGreenLightOff()
        {
            greenButton.BackColor = Color.DarkGreen;
        }

        /// <summary>
        /// Turns green light element on.
        /// </summary>
        private void TurnGreenLightOn()
        {
            // Sounds
            greenSound.Position = 0;
            soundPlayer.Stream = null; // clear out previous sound
            soundPlayer.Stream = greenSound;
            soundPlayer.Play();
            // Lights
            greenButton.BackColor = Color.Lime;
        }

        /// <summary>
        /// Turns red light element off.
        /// </summary>
        private void TurnRedLightOff()
        {
            redButton.BackColor = Color.DarkRed;


        }

        /// <summary>
        /// Turns red light element on.
        /// </summary>
        private void TurnRedLightOn()
        {
            // Sound
            redSound.Position = 0;
            soundPlayer.Stream = null; // clear out previous sound
            soundPlayer.Stream = redSound;
            soundPlayer.Play();

            // Lights
            redButton.BackColor = Color.Red;
        }

        /// <summary>
        /// Turns yellow light element off.
        /// </summary>
        private void TurnYellowLightOff()
        {
            yellowButton.BackColor = Color.Olive;
        }

        /// <summary>
        /// Turns yellow light element on.
        /// </summary>
        private void TurnYellowLightOn()
        {
            // Sound
            yellowSound.Position = 0;
            soundPlayer.Stream = null; // clear out previous sound
            soundPlayer.Stream = yellowSound;
            soundPlayer.Play();

            // Lights
            yellowButton.BackColor = Color.Yellow;
        }
        #endregion

        /// <summary>
        /// Causes game to wait before doing something else. Used to control UI element refreshing.
        /// </summary>
        /// <param name="timeToWait">amount of time to wait</param>
        private void Wait(int timeToWaitInMilliseconds)
        {
            var startingTime = DateTime.Now;

            //while((DateTime.Now - startingTime) < TimeSpan.FromSeconds(timeToWaitInMilliseconds));

            while ((DateTime.Now - startingTime) < TimeSpan.FromMilliseconds(timeToWaitInMilliseconds)) ;
        }

        #region Control Events
        private void greenButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sequenceIsDisplaying)
            {
                // do nothing
            }
            else
            {
                TurnGreenLightOn();
            }

        }

        private void greenButton_MouseUp(object sender, MouseEventArgs e)
        {

            if(!sequenceIsDisplaying)
            {
                TurnGreenLightOff();

                // If the game is playing, green input will be tested against current sequence
                if (gameIsPlaying)
                {
                    CheckGameStatus(currentGame.CheckUserInput(GameColor.Green));
                }
            }
            else
            {
                // do nothing
            }


        }

        private void redButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sequenceIsDisplaying)
            {
                // do nothing
            }
            else
            {
                TurnRedLightOn();
            }

        }

        private void redButton_MouseUp(object sender, MouseEventArgs e)
        {
            if(!sequenceIsDisplaying)
            {
                TurnRedLightOff();

                // If the game is playing, red input will be tested against current sequence
                if (gameIsPlaying)
                {
                    CheckGameStatus(currentGame.CheckUserInput(GameColor.Red));
                }
            }
            else
            {
                // do nothing
            }

        }

        private void yellowButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sequenceIsDisplaying)
            {
                // do nothing
            }
            else
            {
                TurnYellowLightOn();
            }

        }

        private void yellowButton_MouseUp(object sender, MouseEventArgs e)
        {
            if(!sequenceIsDisplaying)
            {
                TurnYellowLightOff();

                // If the game is playing, red input will be tested against current sequence
                if (gameIsPlaying)
                {
                    CheckGameStatus(currentGame.CheckUserInput(GameColor.Yellow));
                }
            }

        }

        private void blueButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sequenceIsDisplaying)
            {
                // do nothing
            }
            else
            {
                TurnBlueLightOn();
            }
        }

        private void blueButton_MouseUp(object sender, MouseEventArgs e)
        {
            if(!sequenceIsDisplaying)
            {
                TurnBlueLightOff();

                // If the game is playing, blue input will be tested against current sequence
                if (gameIsPlaying)
                {
                    CheckGameStatus(currentGame.CheckUserInput(GameColor.Blue));
                }
            }

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Start button will be disabled until the user loses the game
            startButton.Enabled = false;

            // TODO: Add Starting Sound


            // Create new game object to begin the game
            currentGame = new Game();
            gameIsPlaying = true;
            HandleNewRound();
            //currentGame.CreateNewRound();
            //DisplaySequence(currentGame.GetCurrentSequence());

        }
        #endregion
    }
}
