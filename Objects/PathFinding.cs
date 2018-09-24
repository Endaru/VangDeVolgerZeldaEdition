using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger.Objects
{
    class PathFinding
    {
        public List<Space> CreateQueue(Space enemyPosition)
        {
            //make a list with all moveable spaces
            List<Space> queue = new List<Space>();

            //add my space to the queue
            queue.Add(enemyPosition);
            //give met the number one
            enemyPosition.pathfindingposition = 1;

            //loop through the queue
            for (int i = 0; i < queue.Count; i++)
            {
                //with every space in the queue look at all possible directions
                foreach (var item in queue[i].direction)
                {
                    //get the key and value
                    @enum.Direction key = item.Key;
                    Space value = queue[i].direction[key];
                    //set pillar to zero. we might need it later
                    Pillar pillar = null;

                    //if the pathfindingposition has not been set yet. then try to.
                    if (value.pathfindingposition == 0)
                    {
                        //if it is anything the enemy can move over.
                        if ((value != null && value.inhabitant == null) || (value.inhabitant is Player) || (value.inhabitant is Shield) || (value.inhabitant is Hammer) || (value.inhabitant is Pillar))
                        {
                            //if it is a pillar
                            if (value.inhabitant is Pillar)
                            {
                                //check if the pillar is passable
                                pillar = value.inhabitant as Pillar;
                                if (pillar.passable)
                                {
                                    //add to the queue
                                    queue.Add(value);
                                    //set number by taking the last number and adding one
                                    value.pathfindingposition = queue[i].pathfindingposition + 1;
                                }
                            }
                            else
                            {
                                queue.Add(value);
                                value.pathfindingposition = queue[i].pathfindingposition + 1;
                            }
                            //if it is a player then add to path and break out of the foreach.
                            if (value.inhabitant is Player)
                            {
                                return queue;
                            }
                        }
                    }
                }
            }
            return queue;
        }
        public @enum.Direction FindPath(List<Space> queue)
        {
            //list for the path the enemy has to take
            List<Space> path = new List<Space>();
            //the space with the lowest number on it
            Space lowestspace = new Space();
            //lowest number we have at the moment.
            int lowestnumber = 999;
            Space playerPlacement = queue[queue.Count - 1];
            path.Add(playerPlacement);

            //calculate the quickest path that can be taken.
            for (int i = 0; i < path.Count; i++)
            {
                //go through every direction of the selected space in path.
                foreach (var item in path[i].direction)
                {
                    //add key and value to variable.
                    @enum.Direction key = item.Key;
                    Space value = path[i].direction[key];

                    //if the inhabitant is an enemy then add to path 
                    if (value.inhabitant is Enemy)
                    {
                        path.Add(value);
                        removePathfindingNumbers(queue);
                        return key;
                    }
                    //check if the pathfindingposition is not null and if it is the lowest number we have
                    if (value.pathfindingposition != 0 && value.pathfindingposition < lowestnumber)
                    {
                        //add to lowest number
                        lowestnumber = value.pathfindingposition;
                        lowestspace = value;
                    }
                }
                //add to path afhter all directions have been checked
                path.Add(lowestspace);
            }
            return @enum.Direction.None;
        }
        //removes all pathfindingnumbers in every in the list.
        public void removePathfindingNumbers(List<Space> queue)
        {
            foreach (var item in queue)
            {
                item.pathfindingposition = 0;
            }
        }

        public @enum.Direction switchDirection(@enum.Direction key)
        {
            //direction is given in opposite order so change it around
            switch (key)
            {
                case @enum.Direction.North:
                    return @enum.Direction.South;

                case @enum.Direction.East:
                    return @enum.Direction.West;

                case @enum.Direction.South:
                    return @enum.Direction.North;

                case @enum.Direction.West:
                    return @enum.Direction.East;

                default:
                    return @enum.Direction.None;
            }
        }
    }
}
