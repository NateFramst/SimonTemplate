using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        //TODO: create a List to store the pattern. Must be accessable on other screens
        public static List<int> pattern = new List<int>();
        //track difficulty
        public static int difficulty = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Launch MenuScreen
            ChangeScreen(this, new MenuScreen());
        }
        //change screens
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form form;
            if (sender is Form)
            {
                form = sender as Form;
            }
            else
            {
                UserControl currenet = sender as UserControl;
                form = currenet.FindForm();
                form.Controls.Remove(currenet);
            }

            next.Location = new Point((form.Width - next.Width) / 2, (form.Height - next.Height) / 2);

            form.Controls.Add(next);
        }
    }
}
