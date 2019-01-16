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
        Game CurrentGame = null;            // Holds the current playing game.
        bool GameIsPlaying = false;         // Determines whether a game is currently being played
        bool SequenceIsDisplaying = false;  // Determines if sequence is being displayed to avoid erroneous inputs
        int CurrentRound = 0;               // Holds the current round the user is playing
        int HighestRound = 0;               // Holds high score
        int TimeBetweenLights = 500;        // Determines the default time between light on/off in milliseconds
        int TimeBetweenRounds = 2000;       // Determines default time between rounds in milliseconds

        // For Sounds
        SoundPlayer SoundPlayer = null;
        Stream GreenSound = null;
        Stream RedSound = null;
        Stream YellowSound = null;
        Stream BlueSound = null;

        private Button[] ButtonArray = null;

        public Simon()
        {
            InitializeComponent();

            // Add all buttons to common array for easier handling
            ButtonArray = new Button[4];
            ButtonArray[(int)GameColor.Green] = greenButton;
            ButtonArray[(int)GameColor.Red] = redButton;
            ButtonArray[(int)GameColor.Yellow] = yellowButton;
            ButtonArray[(int)GameColor.Blue] = blueButton;

            // Set up sounds
            SoundPlayer = new SoundPlayer();
            GreenSound = Properties.Resources.piano_d;
            RedSound = Properties.Resources.piano_e;
            YellowSound = Properties.Resources.piano_f;
            BlueSound = Properties.Resources.piano_g;

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
                    //Wait(TimeBetweenRounds);
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
            foreach (Button btn in ButtonArray)
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
            SequenceIsDisplaying = true;
            GameColor temp;
            while (sequence.Count != 0)
            {
                temp = sequence.Dequeue();


                switch (temp)
                {
                    case GameColor.Green:
                        TurnGreenLightOn();
                        Wait(TimeBetweenLights);
                        TurnGreenLightOff();
                        Wait(TimeBetweenLights);
                        break;
                    case GameColor.Red:
                        TurnRedLightOn();
                        Wait(TimeBetweenLights);
                        TurnRedLightOff();
                        Wait(TimeBetweenLights);
                        break;
                    case GameColor.Yellow:
                        TurnYellowLightOn();
                        Wait(TimeBetweenLights); ;
                        TurnYellowLightOff();
                        Wait(TimeBetweenLights);
                        break;
                    case GameColor.Blue:
                        TurnBlueLightOn();
                        Wait(TimeBetweenLights);
                        TurnBlueLightOff();
                        Wait(TimeBetweenLights);
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
            SequenceIsDisplaying = false;
        }

        /// <summary>
        /// Enables all of the lights in the game.
        /// </summary>
        private void EnableAllLights()
        {
            foreach (Button btn in ButtonArray)
            {
                btn.Enabled = true;
            }
        }

        /// <summary>
        /// Handles what happens at the UI level when the game is over.
        /// </summary>
        private void HandleGameOver()
        {
            MessageBox.Show(String.Format("Game over! Your highest level was: {0}", CurrentRound));

            // Update the high score
            if (HighestRound <= CurrentRound)
            {
                HighestRound = CurrentRound;
            }
            highScore.Text = HighestRound.ToString("00");

            // Cleanup after game over
            CurrentRound = 0;
            GameIsPlaying = false;
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
            CurrentGame.CreateNewRound();

            // Graphics Update
            TurnAllLightsOff();
            this.Refresh();

            // TODO: ADD THAT YOU WON THE ROUND AND WAIT A SECOND BEFORE DISPLAYING THE NEXT ONE. FOR NOW JUST WAIT
            ///var TIMEOUT = 1;
            //var timeBetweenOnOff = DateTime.Now;
            ///while ((DateTime.Now - timeBetweenOnOff) < TimeSpan.FromSeconds(TIMEOUT)) ;
            Wait(TimeBetweenRounds);

            // Making the display sequence method run on its own thread avoids the issue of
            // enqueuing mouseUp commands on the lights causing the game to erroneously end if
            // the user clicks a button while displaying.
            Thread displayThread = new Thread(() => DisplaySequence(CurrentGame.GetCurrentSequence()));
            displayThread.Start();

            // Re-Enable all lights
            EnableAllLights();
        }

        /// <summary>
        /// Refreshes UI to ensure user knows which round they are on
        /// </summary>
        private void RefreshCurrentRoundCount()
        {
            CurrentRound += 1;
            currentScore.Text = CurrentRound.ToString("00");
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

        /// <summary>
        /// Turns all the lights on. Almost never used.
        /// </summary>
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
            BlueSound.Position = 0;    // rewind from previous position
            SoundPlayer.Stream = null; // clear out previous sound
            SoundPlayer.Stream = BlueSound;
            SoundPlayer.Play();

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
            GreenSound.Position = 0;
            SoundPlayer.Stream = null; // clear out previous sound
            SoundPlayer.Stream = GreenSound;
            SoundPlayer.Play();
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
            RedSound.Position = 0;
            SoundPlayer.Stream = null; // clear out previous sound
            SoundPlayer.Stream = RedSound;
            SoundPlayer.Play();

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
            YellowSound.Position = 0;
            SoundPlayer.Stream = null; // clear out previous sound
            SoundPlayer.Stream = YellowSound;
            SoundPlayer.Play();

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
            if (SequenceIsDisplaying)
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

            if (!SequenceIsDisplaying)
            {
                TurnGreenLightOff();

                // If the game is playing, green input will be tested against current sequence
                if (GameIsPlaying)
                {
                    CheckGameStatus(CurrentGame.CheckUserInput(GameColor.Green));
                }
            }
            else
            {
                // do nothing
            }


        }

        private void redButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (SequenceIsDisplaying)
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
            if (!SequenceIsDisplaying)
            {
                TurnRedLightOff();

                // If the game is playing, red input will be tested against current sequence
                if (GameIsPlaying)
                {
                    CheckGameStatus(CurrentGame.CheckUserInput(GameColor.Red));
                }
            }
            else
            {
                // do nothing
            }

        }

        private void yellowButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (SequenceIsDisplaying)
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
            if (!SequenceIsDisplaying)
            {
                TurnYellowLightOff();

                // If the game is playing, yellow input will be tested against current sequence
                if (GameIsPlaying)
                {
                    CheckGameStatus(CurrentGame.CheckUserInput(GameColor.Yellow));
                }
            }

        }

        private void blueButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (SequenceIsDisplaying)
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
            if (!SequenceIsDisplaying)
            {
                TurnBlueLightOff();

                // If the game is playing, blue input will be tested against current sequence
                if (GameIsPlaying)
                {
                    CheckGameStatus(CurrentGame.CheckUserInput(GameColor.Blue));
                }
            }

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Start button will be disabled until the user loses the game
            startButton.Enabled = false;

            // TODO: Add Starting Sound


            // Create new game object to begin the game
            CurrentGame = new Game();
            GameIsPlaying = true;
            HandleNewRound();
            //CurrentGame.CreateNewRound();
            //DisplaySequence(CurrentGame.GetCurrentSequence());

        }
        #endregion
    }
}
