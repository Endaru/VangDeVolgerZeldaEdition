using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VangDeVolger.Objects;

namespace VangDeVolger
{
    public partial class MainForm : Form
    {
        //variables we need to access on all the classes.
        private World world = new World();
        private Player player = null;
        private Enemy enemy = null;
        private Space[,] level = new Space[20, 20];
        private Timer enemyTimer = new Timer();

        //with these values we can check if the game loads for the first time.
        private bool firstTime = true;
        private bool firstRestart = true;
        private bool disable = false;
        private bool enemyStart = true;
        private bool resize = false;

        //starting values for first load.
        private int stonePercentage = 20;
        private int pillarPercentage = 5;
        private int numberHammers = 2;
        private int numberShields = 1;
        private float enemySpeed = 1;
        private int mapSize = 20;

        //Create the world.
        public MainForm()
        {
            InitializeComponent();
            //play the music of the game.
            SoundPlayer.Player(@"..\..\..\vangdevolger\Resources\gametheme.wav", false);
            //go to create world.
            CreateWorld(level);
        }

        //Go to enemyMove.
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            EnemyMove();
            if (enemy.win || enemy.lose)
                ShowResultScreen();
        }

        //here we call the functions from world and get them back here.
        private void CreateWorld(Space[,] level)
        {
            if (firstTime)
            {
                //makes the enemy move every half second.
                enemyTimer.Interval = (int)(500 / (float)enemySpeed);
                //start timer.
                enemyTimer.Start();
            }

            //if first time is true then create the level and make the neighbors know.
            if (firstTime && enemyStart)
            {
                //go to level and add the neighbors.
                level = world.BuildLevel(level, pillarPercentage, stonePercentage, numberHammers, numberShields, out player, out enemy);
                world.AddNeighbors(level);
            }

            //always use build to get the bitmap.
            Bitmap bmp = world.Build(level);

            //add the bitmap to the image of the picturebox.
            gamePicture.Image = bmp;

            //make the resize happen once per restart.
            if (firstTime && resize)
            {
                //remove height of picturebox.
                this.Height -= gamePicture.Height;
                //add height of bitmap.
                this.Height += bmp.Height;
                //make picturebox as big as bitmap.
                gamePicture.Height = bmp.Height;

                //remove width of picturebox.
                this.Width -= gamePicture.Width;
                //add width of bitmap.
                this.Width += bmp.Width;
                //make picturebox as wide as bitmap.
                gamePicture.Width = bmp.Width;
                //minus 26 to remove addes space from menu.
                this.Width -= 26;

                //make resize false so it wont happen again.
                resize = false;
            }

            //if it is the firsttime starting the game then add keyhandler.
            if (firstTime && firstRestart)
            {
                //at interval go to enemyTimer_Tick.
                enemyTimer.Tick += new EventHandler(enemyTimer_Tick);
                //addthe keyhandler so we can get those in the form first.
                KeyUp += new KeyEventHandler(MainForm_KeyUp);
                //set to false so this can not happen again.
                firstRestart = false;
            }
            firstTime = false;
        }

        //show the resulting screen for winning and losing
        public void ShowResultScreen()
        {
            if (enemy.win || player.lose)
            {
                //add to a bitmap
                Image loseScreen = Image.FromFile(@"..\..\..\VangDeVolger\Resources\losescreen.png");
                Bitmap loseBitmap = new Bitmap(loseScreen, new Size(gamePicture.Width, gamePicture.Height));

                //stop the sound
                if (!disable)
                {
                    SoundPlayer.Effect(@"..\..\..\VangDeVolger\Resources\Link_Dying.wav");
                    SoundPlayer.Player(@"..\..\..\vangdevolger\Resources\gametheme.wav", true);
                }

                //freeze the game
                Freeze();
                enemyTimer.Stop();
                gamePicture.Image = loseBitmap;
            }
            else if (enemy.lose)
            {
                //add to a bitmap
                Image winScreen = Image.FromFile(@"..\..\..\VangDeVolger\Resources\winscreen.png");
                Bitmap winBitmap = new Bitmap(winScreen, new Size(gamePicture.Width, gamePicture.Height));

                //stop the sound
                if (!disable)
                {
                    SoundPlayer.Player(@"..\..\..\vangdevolger\Resources\gametheme.wav", true);
                    SoundPlayer.Effect(@"..\..\..\VangDeVolger\Resources\ItemFanfare.wav");
                }
                //freeze the game
                Freeze();
                enemyTimer.Stop();
                gamePicture.Image = winBitmap;
            }
        }

        //change text on click and pause the game.
        private void Pauze_Click(object sender, EventArgs e)
        {
            //go to Freeze.
            Freeze();
        }

        //if clicked then this will make sure the player and enemy wil not move.
        private void Freeze()
        {
            //if text is this then change into that.
            if (Pauze.Text == "Pauze")
            {
                Pauze.Text = "Play";
            }
            else if (Pauze.Text == "Play")
            {
                Pauze.Text = "Pauze";
            }

            if (enemy != null) {
                if (!disable)
                {
                    //switch disable from false to true.
                    disable = true;
                    //turn timer off.
                    enemyTimer.Stop();
                }
                //if the enemy lost or won keep the game frozen.
                else if (disable && enemy.lose || enemy.win || player.lose )
                {
                    disable = true;
                    enemyTimer.Stop();
                }
                else
                {
                    disable = false;
                    enemyTimer.Start();
                }
            }
        }

        //the game will restart.
        private void Restart_Click(object sender, EventArgs e)
        {
            BuildNewGame();
        }

        private void BuildNewGame()
        {
            //start a new game.
            firstTime = true;
            disable = false;
            enemyStart = true;
            resize = true;
            enemy.lose = false;
            enemy.win = false;
            Pauze.Text = "Pauze";

            enemyTimer.Start();

            level = new Space[mapSize, mapSize];

            SoundPlayer.Player(@"..\..\..\vangdevolger\Resources\gametheme.wav", false);
            //create the world again.
            CreateWorld(level);
        }

        //will catch keyboard clicks and will then give them to player.
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            //if disable is true dont do anything.
            if (!disable)
            {
                player.AddMovement(sender, e);
                ShowResultScreen();
                //create the world again so the changes reflect the screen.
                CreateWorld(level);
            }
        }

        //starts enemy movement.
        private void EnemyMove()
        {
            if (enemyStart)
            {
                //set this to false so we dont come here again.
                enemyStart = false;
            }

            //get direction from moveStrategy.
            @enum.Direction dir = enemy.MoveStrategy();

            //move the enemy.
            enemy.move(dir);
            enemy.ChangeSprite(dir);
            //create the world again to reflect changes.
            CreateWorld(level);

        }

        //open optionsform and get back options.
        private void Options_Click(object sender, EventArgs e)
        {
            //call Freeze so game wont continue.
            Freeze();

            //using so we can get the variables out of the optionsmenu.
            using (var options = new OptionsForm())
            {
                //result is the options in options.
                var result = options.ShowDialog();
                //if we get back an OK.
                if (result == DialogResult.OK)
                {
                    //add the selected option to the form.
                    stonePercentage = options.stonePercentage;
                    pillarPercentage = options.pillarPercentage;
                    enemySpeed = options.enemySpeed;
                    mapSize = options.mapSize;
                    numberHammers = options.numberHammers;
                    numberShields = options.numberShields;
                    //restart the game.
                    BuildNewGame();
                }

                //if we get back a cancel.
                if (result == DialogResult.Cancel)
                {
                    //call Freeze so game wil continue.
                    Freeze();
                }
            }
        }
    }
}