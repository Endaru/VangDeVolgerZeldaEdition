using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VangDeVolger.Objects
{
    class Box : DynamicObject
    {
        //with this function the box is capable of movement.
        public Box move(@enum.Direction dir)
        {
            //if my dictionary contains the direction i have been given continue
            if (myposition.direction.ContainsKey(dir))
            {
                //add neighboring direction to a variable
                Space value = myposition.direction[dir];

                //if the inhabitant of nieghbor is a box
                if (value.inhabitant is Box)
                {
                    Box box = value.inhabitant as Box;
                    box = box.move(dir);
                }

                //if nothing is in space
                if (value.inhabitant == null)
                {
                    value.inhabitant = myposition.inhabitant;
                    myposition.inhabitant = null;
                    myposition = value;
                    return (Box)myposition.inhabitant;
                }
            }
            //return incase the box can not move.
            return (Box)myposition.inhabitant;
        }

        public Box()
        {
            image = Image.FromFile(@"..\..\..\vangdevolger\Resources\block.png");
        }
    }
}
