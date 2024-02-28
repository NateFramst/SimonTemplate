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
using System.Windows.Media.Animation;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //guess counter
        int guess;

        //sound toggle
        bool sound = true;

        //button check
        bool clicks = false;

        //working varrible
        int x = 0;

        //list for button postions
        Point slot1 = new Point(40, 37);
        Point slot2 = new Point(152, 37);
        Point slot3 = new Point(152, 149);
        Point slot4 = new Point(40, 149);

        List<Point> slotsL = new List<Point>();

        //temp list

        List<Point> temp = new List<Point>();

        //list to store buttons

        List<Button> buttons = new List<Button>();

        //randomizer

        Random random = new Random();

        //delay times

        int inBetweenTime = 700;
        int waitTime = 300;

        //sounds
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
            //fill lists
            slotsL.Add(slot1);
            slotsL.Add(slot2);
            slotsL.Add(slot3);
            slotsL.Add(slot4);
            buttons.Add(greenButton);
            buttons.Add(redButton);
            buttons.Add(blueButton);
            buttons.Add(yellowButton);

            //check difficulty
            if (Form1.difficulty == 0)
            {
                gamemodeLabel.Text = "Normal Mode";
            }
            if(Form1.difficulty == 1)
            {
                gamemodeLabel.Text = "Reverse Mode";
            }
            if (Form1.difficulty == 2)
            {
                gamemodeLabel.Text = "Sound Mode";
            }
            if (Form1.difficulty == 3)
            {
                gamemodeLabel.Text = "Moving Mode";
            }
            if (Form1.difficulty == 5)
            {
                gamemodeLabel.Text = "PinWheel Mode";
            }
            if (Form1.difficulty == 4)
            {
                gamemodeLabel.Text = "Impossible Mode (Sound, Moving, and Reverse)";
            }

            //reset pattern
            if (Form1.pattern != null)
            {
                Form1.pattern.Clear();
            }
            
            Refresh();
            //pause for a bit
            Thread.Sleep(500);
            
            //initalize sequence 
            ColourStuff(sound, Color.LightGreen, Color.ForestGreen, greenButton, greenSound);

            ColourStuff(sound, Color.Red, Color.DarkRed, redButton, redSound);

            ColourStuff(sound, Color.LightGoldenrodYellow, Color.Goldenrod, yellowButton, yellowSound);

            ColourStuff(sound, Color.Blue, Color.DarkBlue, blueButton, blueSound);

            Thread.Sleep(100);

            Loud();

            Thread.Sleep(1000);

            gamemodeLabel.Text = "Computer Turn";

            ComputerTurn();
        }


        //when button is pressed
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

        //muliti audio
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

            gamemodeLabel.Text = "Computer Turn";

            waitTime = 300;

            //reverse mode check
            if (Form1.pattern.Count >= 1 && Form1.difficulty == 1 || Form1.pattern.Count >= 1 &&  Form1.difficulty == 4)
            {
                Form1.pattern.Reverse();
            }

            //create pattern 
            Random radNum = new Random();
            Form1.pattern.Add(radNum.Next(0, 4));


            // loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.pattern.Count; i++)
            {
                if (Form1.difficulty == 0 || Form1.difficulty == 1 || Form1.difficulty == 3 || Form1.difficulty == 5)
                {
                    sound = true;
                    if (Form1.pattern[i] == 0)
                    {
                        ColourStuff(sound, Color.LightGreen, Color.ForestGreen, greenButton, greenSound);
                    }
                    else if (Form1.pattern[i] == 2)
                    {
                        ColourStuff(sound, Color.Blue, Color.DarkBlue, blueButton, blueSound);
                    }
                    else if (Form1.pattern[i] == 1)
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
            //reverse mode check
            if (Form1.difficulty == 1 || Form1.difficulty == 4)
            {
                Form1.pattern.Reverse();
            }

            //pinwheel mode check
            if (Form1.difficulty == 5)
            {
                timer1.Enabled = true;
            }
            //random mode check
            if (Form1.difficulty == 3 || Form1.difficulty == 4)
            {
                MovingButtons();
            }


            //TODO: set guess value back to 0
            guess = 0;

            clicks = true;

            gamemodeLabel.Text = "Player Turn";
        }

       //button clicks
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
              ButtonStuff(1);
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
                ButtonStuff(2);
            }
        }

        public void ButtonStuff(int button)
        {

            waitTime = 50;

            //check patterns
            if (Form1.difficulty == 0 || Form1.difficulty == 1 ||Form1.difficulty == 3 || Form1.difficulty == 5)
            {
                sound = true;
                if (Form1.pattern[guess] == button)
                {
                    if (button == 2)
                    {
                        ColourStuff(sound, Color.Blue, Color.DarkBlue, blueButton, blueSound);
                    }
                    else if (button == 1)
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

        //end game
        public void GameOver()
        {
            //TODO: Play a game over sound
            // blow up
            mistakeSound.Play();

            //TODO: close this screen and open the GameOverScreen

            Form1.ChangeScreen(this, new GameOverScreen());
        }

        //move buttons randomly 
        public void MovingButtons()
        {

            Thread.Sleep(500);

            //reorder list 
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

            //move buttons
            for (int i = 0; i < 4; i++)
            {
                buttons[i].Location = new Point(slotsL[i].X, slotsL[i].Y);
            }
            Refresh();
        }

        //spin buttons for pinwheel
        private void timer1_Tick(object sender, EventArgs e)
        {
            //move buttons
            for (int i = 0; i < 4;i++)
            {
                
                if (x == 3)
                {
                    x = -1;
                }
                buttons[i].Location = new Point(slotsL[x + 1].X, slotsL[x+1].Y);
                x++;

            }
            Refresh();

            //reorder list 
            temp.Add(slotsL[1]);
            temp.Add(slotsL[2]);
            temp.Add(slotsL[3]);
            temp.Add(slotsL[0]);

            slotsL.Clear();

            for (int j = 0; j < 4; j++)
            {
                slotsL.Add(temp[j]);
            }

            temp.Clear();
            //spin faster
            if (timer1.Interval > 50)
            {
                timer1.Interval -= 5;
            }
        }
    }
}