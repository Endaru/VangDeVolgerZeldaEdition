using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger.Objects
{
    class Space
    {
        public GameObject inhabitant { get; set; }
        public int pathfindingposition { get; set; }
        public Dictionary<@enum.Direction, Space> direction = new Dictionary<@enum.Direction, Space>();
        
        public void CreateNeighbors(ref Space neighbor, @enum.Direction dir)
        {
            //add the neighbor to the dictionary
            direction.Add(dir, neighbor);
        }
    }
}