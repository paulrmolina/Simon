using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon
{
    public partial class Simon : Form
    {

        public Simon()
        {
            InitializeComponent();
            ShowIntroduction();
        }

        private void ShowIntroduction()
        {

        }

        private void TurnBlueLightOff()
        {
            blueButton.BackColor = Color.Navy;
        }

        private void TurnBlueLightOn()
        {
            blueButton.BackColor = Color.Blue;
        }

        private void TurnGreenLightOff()
        {
            greenButton.BackColor = Color.DarkGreen;
        }

        private void TurnGreenLightOn()
        {
            greenButton.BackColor = Color.Lime;
        }

        private void TurnRedLightOff()
        {
            redButton.BackColor = Color.DarkRed;
        }
        private void TurnRedLightOn()
        {
            redButton.BackColor = Color.Red;
        }

        private void TurnYellowLightOff()
        {
            yellowButton.BackColor = Color.Olive;
        }

        private void TurnYellowLightOn()
        {
            yellowButton.BackColor = Color.Yellow;
        }

        private void greenButton_MouseDown(object sender, MouseEventArgs e)
        {
            TurnGreenLightOn();
        }

        private void greenButton_MouseUp(object sender, MouseEventArgs e)
        {
            TurnGreenLightOff();
        }

        private void redButton_MouseDown(object sender, MouseEventArgs e)
        {
            TurnRedLightOn();
        }

        private void redButton_MouseUp(object sender, MouseEventArgs e)
        {
            TurnRedLightOff();
        }

        private void yellowButton_MouseDown(object sender, MouseEventArgs e)
        {
            TurnYellowLightOn();
        }

        private void yellowButton_MouseUp(object sender, MouseEventArgs e)
        {
            TurnYellowLightOff();
        }

        private void blueButton_MouseDown(object sender, MouseEventArgs e)
        {
            TurnBlueLightOn();
        }

        private void blueButton_MouseUp(object sender, MouseEventArgs e)
        {
            TurnBlueLightOff();
        }
    }
}
