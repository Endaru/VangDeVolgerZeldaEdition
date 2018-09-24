using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace VangDeVolger.Objects
{
    
    class Player : DynamicObject
    {
        private Hammer hammer { get; set; }
        public bool lose { get; set; }
        public bool shieldActive { get; set; }
        private Timer shieldDuration = new Timer();

        //with this function the player is capable of movement.
        public void AddMovement(object sender, KeyEventArgs e)
        {
            //if any of these are true then go to move in player.
            if (e.KeyCode == Keys.W)
            {
                move(@enum.Direction.North);
                ChangeSprite(@enum.Direction.North);
            }
            if (e.KeyCode == Keys.D)
            {
                move(@enum.Direction.East);
                ChangeSprite(@enum.Direction.East);
            }
            if (e.KeyCode == Keys.S)
            {
                move(@enum.Direction.South);
                ChangeSprite(@enum.Direction.South);
            }
            if (e.KeyCode == Keys.A)
            {
                move(@enum.Direction.West);
                ChangeSprite(@enum.Direction.West);
            }
        }
        private void move(@enum.Direction dir)
        {
            //if my dictionary contains the direction i have been given continue.
            if (myPosition.direction.ContainsKey(dir))
            {
                //add neighboring direction to a variable.
                Space value = myPosition.direction[dir];
                if(value.inhabitant is Enemy && !(this.shieldActive))
                {
                    lose = true;
                }
                //if the inhabitant of nieghbor is a stone.
                if (value.inhabitant is Stone)
                {
                    //save stone.
                    Stone stone = value.inhabitant as Stone;
                    //move the stone in players direction
                    stone.move(dir);
                }
                if (value.inhabitant is Hammer || value.inhabitant is Shield)
                {
                    SoundPlayer.Effect(@"..\..\..\vangdevolger\Resources\Item.wav");
                    if (value.inhabitant is Hammer)
                    {
                        hammer = value.inhabitant as Hammer;
                    }
                    else
                    {
                        UseShield(value);
                    }
                    //move player into the space
                    value.inhabitant = myPosition.inhabitant;
                    myPosition.inhabitant = null;
                    myPosition = value;
                }
                if(value.inhabitant is Pillar)
                {
                    Pillar pillar = value.inhabitant as Pillar;
                    if (pillar.passable)
                    {
                        CheckIfOnPillar(value);
                        onPillar = true;
                    }
                    if (hammer != null && !(pillar.passable))
                    {
                        SoundPlayer.Effect(@"..\..\..\vangdevolger\Resources\hammer.wav");
                        //check if the hammer is broken.
                        bool checkbroken = hammer.hammerTime();
                        if (checkbroken)
                        {
                            hammer = null;
                        }
                        CheckIfOnPillar(value);
                        onPillar = true;
                    }
                }

                //if nothing is in space.
                if (value.inhabitant == null)
                {
                    CheckIfOnPillar(value);
                }
            }
        }

        //use the shield and activate timer with function when timer ends.
        private void UseShield(Space value)
        {
            if (shieldActive)
            {
                shieldDuration.Stop();
                shieldDuration.Start();
            }
            shieldActive = true;
            shieldDuration.Interval = 10000;
            shieldDuration.Start();
            shieldDuration.Tick += (object sender, EventArgs e) => shieldDuration_Tick(sender, e, shieldDuration);
        }

        //dispose of shield. when timer has ended.
        private void shieldDuration_Tick(object sender, EventArgs e, Timer shieldDuration)
        {
            shieldDuration.Dispose();
            shieldActive = false;
        }

        public Player()
        {
            lose = false;
            shieldActive = false;
            image = Image.FromFile(@"..\..\..\vangdevolger\Resources\player.png");
        }
    }
}