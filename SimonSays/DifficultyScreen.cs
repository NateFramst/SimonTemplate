using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class DifficultyScreen: UserControl
    {
        public DifficultyScreen()
        {
            InitializeComponent();
        }

        //set difficulties // gamemodes
        private void normalButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 0;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void reverseButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 1;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void soundButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 2;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void movingButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 3;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void impossibleButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 4;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void pinWheelButton_Click(object sender, EventArgs e)
        {
            Form1.difficulty = 5;
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
