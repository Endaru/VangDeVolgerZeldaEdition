using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger.Objects
{
    class DynamicObject : GameObject
    {
        //checks if a dynamic object is on a pillar.
        protected bool onPillar { get; set; }

        protected void CheckIfOnPillar(Space value)
        {
            if (onPillar)
            {
                //move player into the space.
                value.inhabitant = myPosition.inhabitant;
                myPosition.inhabitant = new Pillar(true);
                Pillar pillar = myPosition.inhabitant as Pillar;

                pillar.passable = true;
                onPillar = false;
                myPosition = value;
            }
            else
            {
                value.inhabitant = myPosition.inhabitant;
                myPosition.inhabitant = null;
                myPosition = value;
            }
        }
        public void ChangeSprite(@enum.Direction dir)
        {
            if (dir == @enum.Direction.North)
            {
                if(this is Player)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\north.png");
                }
                if (this is Enemy)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\enorth.png");
                }
            }
            if (dir == @enum.Direction.East)
            {
                if (this is Player)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\east.png");
                }
                if (this is Enemy)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\eeast.png");
                }
            }
            if (dir == @enum.Direction.South)
            {
                if (this is Player)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\player.png");
                }
                if (this is Enemy)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\esouth.png");
                }
            }
            if (dir == @enum.Direction.West)
            {
                if (this is Player)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\east.png");
                    image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
                if (this is Enemy)
                {
                    image = Image.FromFile(@"..\..\..\vangdevolger\Resources\eeast.png");
                    image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
            }
        }

        public DynamicObject()
        {
            //standard on false.
            onPillar = false;
        }
    }
}
