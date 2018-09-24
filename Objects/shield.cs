using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger.Objects
{
    class Shield : Pickup
    {
        public Shield()
        {
            image = Image.FromFile(@"..\..\..\vangdevolger\Resources\Shield.png");
        }
    }
}
