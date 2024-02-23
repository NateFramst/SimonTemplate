using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.IO;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //funnySounds
        int guess;
        bool sound = true;

        bool clicks = false;

        int x = 0;

        List<bool> slots = new List<bool>();

        Point slot1 = new Point(40, 37);
        Point slot2 = new Point(152, 37);
        Point slot3 = new Point(40, 149);
        Point slot4 = new Point(152, 149);

        List<Point> slotsL = new List<Point>();

        List<Point> temp = new List<Point>();

        List<Button> buttons = new List<Button>();

        Random random = new Random();

        int inBetweenTime = 700;
        int waitTime = 300;

        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);


        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            slotsL.Add(slot1);
            slotsL.Add(slot2);
            slotsL.Add(slot3);
            slotsL.Add(slot4);
            buttons.Add(greenButton);
            buttons.Add(redButton);
            buttons.Add(blueButton);
            buttons.Add(yellowButton);

            
            if (Form1.pattern != null)
            {
                Form1.pattern.Clear();
            }
            
            Refresh();
            //pause for a bit
            Thread.Sleep(500);
            

            ColourStuff(sound, Color.LightGreen, Color.ForestGreen, greenButton, greenSound);

            ColourStuff(sound, Color.Red, Color.DarkRed, redButton, redSound);

            ColourStuff(sound, Color.LightGoldenrodYellow, Color.Goldenrod, yellowButton, yellowSound);

            ColourStuff(sound, Color.Blue, Color.DarkBlue, blueButton, blueSound);

            Thread.Sleep(100);

            Loud();

            Thread.Sleep(1000);

            ComputerTurn();
        }

        private void ColourStuff(bool sound, Color firstColour, Color secondColour, Button button, SoundPlayer sounds)
        {
            button.BackColor = firstColour;
            if (sound == true)
            {
                sounds.Play();
            }
            Refresh();
            Thread.Sleep(waitTime);
            button.BackColor = secondColour;
            Refresh();
            Thread.Sleep(waitTime);
        }

        private void Loud()
        {
            var RedSound = new System.Windows.Media.MediaPlayer();
            RedSound.Open(new Uri(Application.StartupPath + "/Resources/red.wav"));

            var BlueSound = new System.Windows.Media.MediaPlayer();
            BlueSound.Open(new Uri(Application.StartupPath + "/Resources/blue.wav"));

            var GreenSound = new System.Windows.Media.MediaPlayer();
            GreenSound.Open(new Uri(Application.StartupPath + "/Resources/green.wav"));

            var YellowSound = new System.Windows.Media.MediaPlayer();
            YellowSound.Open(new Uri(Application.StartupPath + "/Resources/yellow.wav"));

            RedSound.Play();
            GreenSound.Play();
            YellowSound.Play();
            BlueSound.Play();

            greenButton.BackColor = Color.LightPink;
            redButton.BackColor = Color.LightPink;
            yellowButton.BackColor = Color.LightPink;
            blueButton.BackColor = Color.LightPink;

            Refresh();
            Thread.Sleep(waitTime);

            greenButton.BackColor = Color.ForestGreen;
            redButton.BackColor = Color.DarkRed;
            yellowButton.BackColor = Color.Goldenrod;
            blueButton.BackColor = Color.DarkBlue;

            Refresh();
        }

        private void ComputerTurn()
        {
            clicks = false;

            if (Form1.pattern.Count >= 1 && Form1.difficulty == 1 || Form1.pattern.Count >= 1 &&  Form1.difficulty == 4)
            {
                Form1.pattern.Reverse();
            }

            Random radNum = new Random();
            Form1.pattern.Add(radNum.Next(0, 4));


            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.pattern.Count; i++)
            {
                if (Form1.difficulty == 0 || Form1.difficulty == 1 || Form1.difficulty == 3 || Form1.difficulty == 5)
                {
                    sound = true;
                    if (Form1.pattern[i] == 0)
                    {
                        ColourStuff(sound, Color.LightGreen, Color.ForestGreen, greenButton, greenSound);
                    }
                    else if (Form1.pattern[i] == 1)
                    {
                        ColourStuff(sound, Color.Blue, Color.DarkBlue, blueButton, blueSound);
                    }
                    else if (Form1.pattern[i] == 2)
                    {
                        ColourStuff(sound, Color.Red, Color.DarkRed, redButton, redSound);
                    }
                    else
                    {
                        ColourStuff(sound, Color.LightGoldenrodYellow, Color.Goldenrod, yellowButton, yellowSound);
                    }

                }
                else if (Form1.difficulty == 2 || Form1.difficulty == 4)
                {
                    if (Form1.pattern[i] == 0)
                    {
                        greenSound.Play();
                        Thread.Sleep(waitTime);
                    }
                    else if (Form1.pattern[i] == 1)
                    {
                        blueSound.Play();
                        Thread.Sleep(waitTime);
                    }
                    else if (Form1.pattern[i] == 2)
                    {
                        redSound.Play();
                        Thread.Sleep(waitTime);
                    }
                    else
                    {
                        yellowSound.Play();
                        Thread.Sleep(waitTime);
                    }

                    
                }
            }
            if (Form1.difficulty == 1 || Form1.difficulty == 4)
            {
                Form1.pattern.Reverse();
            }

            if (Form1.difficulty == 5)
            {
                timer1.Enabled = true;
            }

            if (Form1.difficulty == 3 || Form1.difficulty == 4)
            {
                MovingButtons();
            }


            //TODO: set guess value back to 0
            guess = 0;

            clicks = true;

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (clicks == true)
            {
                ButtonStuff(0);
            }
           
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (clicks == true)
            {
              ButtonStuff(2);
            } 
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (clicks == true)
            {
                ButtonStuff(3);
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (clicks == true)
            {
                ButtonStuff(1);
            }
        }

        public void ButtonStuff(int button)
        {
            if (Form1.difficulty == 0 || Form1.difficulty == 1 ||Form1.difficulty == 3 || Form1.difficulty == 5)
            {
                sound = true;
                if (Form1.pattern[guess] == button)
                {
                    if (button == 1)
                    {
                        ColourStuff(sound, Color.Blue, Color.DarkBlue, blueButton, blueSound);
                    }
                    else if (button == 2)
                    {
                        ColourStuff(sound, Color.Red, Color.DarkRed, redButton, redSound);
                    }
                    else if (button == 3)
                    {
                        ColourStuff(sound, Color.LightGoldenrodYellow, Color.Goldenrod, yellowButton, yellowSound);
                    }
                    else
                    {
                        ColourStuff(sound, Color.LightGreen, Color.ForestGreen, greenButton, greenSound);
                    }
                    guess++;

                    Refresh();
                }
                else
                {
                    GameOver();
                }

                if (guess == Form1.pattern.Count)
                {
                    Thread.Sleep(inBetweenTime);
                    ComputerTurn();
                }
            }
            else if (Form1.difficulty == 2 || Form1.difficulty == 4)
            {
                sound = false;
                if (Form1.pattern[guess] == button)
                {
                    if (button == 1)
                    {
                        ColourStuff(sound, Color.Blue, Color.DarkBlue, blueButton, blueSound);
                    }
                    else if (button == 2)
                    {
                        ColourStuff(sound, Color.Red, Color.DarkRed, redButton, redSound);
                    }
                    else if (button == 3)
                    {
                        ColourStuff(sound, Color.LightGoldenrodYellow, Color.Goldenrod, yellowButton, yellowSound);
                    }
                    else
                    {
                        ColourStuff(sound, Color.LightGreen, Color.ForestGreen, greenButton, greenSound);
                    }
                    guess++;
                    Refresh();
                }
                else
                {
                    GameOver();
                }

                if (guess == Form1.pattern.Count)
                {
                    Thread.Sleep(inBetweenTime);
                    ComputerTurn();
                }
            }
        }

        public void GameOver()
        {
            //TODO: Play a game over sound
            // blow up
            mistakeSound.Play();

            //TODO: close this screen and open the GameOverScreen

            Form1.ChangeScreen(this, new GameOverScreen());
        }

        public void MovingButtons()
        {

            Thread.Sleep(500);


            for (int i = 0; i < 4; i++)
            {
                int store = random.Next(0, (slotsL.Count - 1));
                temp.Add(slotsL[store]);
                slotsL.RemoveAt(store);
            }

            for (int i = 0; i < 4; i++)
            {
                slotsL.Add(temp[i]);
            }
           
            temp.Clear();

            for (int i = 0; i < 4; i++)
            {
                buttons[i].Location = new Point(slotsL[i].X, slotsL[i].Y);
            }
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4;i++)
            {
                
                if (x == 3)
                {
                    x = -1;
                }
                buttons[i].Location = new Point(slotsL[x + 1].X, slotsL[x+1].Y);
                x++;
            }
        }
    }
}