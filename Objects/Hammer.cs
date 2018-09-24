using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger.Objects
{
    class Hammer : Pickup
    {
        private int uses { get; set; }

        //You can't touch this. STOP...
        public bool hammerTime()
        {
            uses--;
            if (uses <= 0)
            {
                return true;
            }
            return false;
        }
        public Hammer()
        {
            uses = 3;
            image = Image.FromFile(@"..\..\..\vangdevolger\Resources\Hammer.png");
        }
    }
}
