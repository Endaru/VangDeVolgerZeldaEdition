using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VangDeVolger.Objects
{
    class Enemy : DynamicObject
    {
        //used to check if the enemy has lost.
        public bool lose { get; set; }
        public bool win { get; set; }

        //function to decide which direction to move.
        // this function returns the string with the direction.
        public @enum.Direction MoveStrategy()
        {
            PathFinding path = new PathFinding();
            List<Space> queue = path.CreateQueue(this.myPosition);

            if(queue[(queue.Count - 1)].inhabitant is Player)
            {
                @enum.Direction foundpath = path.FindPath(queue);
                @enum.Direction reversedPath = path.switchDirection(foundpath);
                return reversedPath;
            }
            else
            {
                //add random movement if there is no path
                List<@enum.Direction> possibledirect = new List<@enum.Direction>();

                //go through every possible direction 
                foreach (var item in this.myPosition.direction)
                {
                    if (item.Value.inhabitant == null || item.Value.inhabitant is Pillar || item.Value.inhabitant is Shield || item.Value.inhabitant is Hammer)
                    {
                        if (item.Value.inhabitant is Pillar)
                        {
                            Pillar pillar1 = item.Value.inhabitant as Pillar;
                            if (pillar1.passable)
                            {
                                //if you can move there add to list
                                possibledirect.Add(item.Key);
                            }
                        }
                        else
                        {
                            possibledirect.Add(item.Key);
                        }
                    }
                }
                //if list is zero you lose
                if (possibledirect.Count == 0)
                {
                    lose = true;
                    return @enum.Direction.None;
                }
                //create random number 
                Random rnd = new Random();
                int randomnumber = rnd.Next(0, possibledirect.Count);
                //go to removepathfindingnumbers
                path.removePathfindingNumbers(queue);
                //return the randomly chosen direction
                return possibledirect[randomnumber];
            }
        }

        //moves the player.
        public Enemy move(@enum.Direction dir)
        {
            //if the direction is not null then stay put.
            if (!(dir == @enum.Direction.None))
            {
                //get the neighboring space out of the dictionary.
                Space value = myPosition.direction[dir];

                //check if the direction exists in the dictionary.
                if (myPosition.direction.ContainsKey(dir))
                {
                    //if it is the player do this.
                    if (value.inhabitant is Player)
                    {
                        Player player = value.inhabitant as Player;
                        if (!(player.shieldActive))
                        {
                            //add the inhabitant to neighboring inhabitant.
                            value.inhabitant = myPosition.inhabitant;
                            //set inhabitant of this position empty.
                            myPosition.inhabitant = null;
                            //change my direction to the one we want to move to.
                            myPosition = value;
                            win = true;
                            //return position of this.
                            return (Enemy)myPosition.inhabitant;
                        }
                    }
                    if (value.inhabitant is Hammer || value.inhabitant is Shield)
                    {
                        //add the inhabitant to neighboring inhabitant.
                        value.inhabitant = myPosition.inhabitant;
                        //set inhabitant of this position empty.
                        myPosition.inhabitant = null;
                        //change my direction to the one we want to move to.
                        myPosition = value;
                        //return position of this.
                        return (Enemy)myPosition.inhabitant;
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
                    //move to empty space.
                    if (value.inhabitant == null)
                    {
                        //if you are on the pillar.
                        CheckIfOnPillar(value);
                        return (Enemy)myPosition.inhabitant;
                    }
                }
            }
            //return incase the player can not move.
            return (Enemy)myPosition.inhabitant;
        }
        public Enemy()
        {
            lose = false;
            win = false;
            image = Image.FromFile(@"..\..\..\vangdevolger\Resources\esouth.png");
        }
    }
}
