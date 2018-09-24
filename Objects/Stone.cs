using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VangDeVolger.Objects
{
    class Stone : DynamicObject
    {
        //with this function the stone is capable of movement.
        public void move(@enum.Direction dir)
        {
            //if my dictionary contains the direction i have been given continue
            if (myPosition.direction.ContainsKey(dir))
            {
                //add neighboring direction to a variable
                Space value = myPosition.direction[dir];

                //if the inhabitant of nieghbor is a stone
                if (value.inhabitant is Stone)
                {
                    Stone stone = value.inhabitant as Stone;
                    stone.move(dir);
                    
                }
                if (value.inhabitant is Pillar)
                {
                    Pillar pillar = value.inhabitant as Pillar;
                    if (pillar.passable)
                    {
                        CheckIfOnPillar(value);
                        onPillar = true;
                    }
                }

                //if nothing is in space
                if (value.inhabitant == null)
                {
                    CheckIfOnPillar(value);
                }
            }
            //return incase the stone can not move.
            
        }

        public Stone()
        {
            image = Image.FromFile(@"..\..\..\vangdevolger\Resources\block.png");
        }
    }
}
