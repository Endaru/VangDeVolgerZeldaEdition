using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
            //put the bitmap on an image.
            Image myimage = new Bitmap(@"..\..\..\vangdevolger\Resources\VDVstartscreen.png");
            //add the image to the background of the startscreen.
            this.BackgroundImage = myimage;
            //play a tune.
            SoundPlayer.Player(@"..\..\..\vangdevolger\Resources\startscreen.wav", false);
        }

        //what happens if the play button is clicked.
        private void playButton_Click(object sender, EventArgs e)
        {
            //make a main form.
            MainForm mainform = new MainForm();
            //hide the startscreen.
            this.Hide();
            //show the game.
            mainform.ShowDialog();
            //close the startscreen.
            this.Close();
        }
            
        //what happens if exit is pressed.
        private void exitButton_Click(object sender, EventArgs e)
        {
            //end application.
            this.Dispose();
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //end application.
            this.Close();
        }
    }
}
