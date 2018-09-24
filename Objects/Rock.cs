using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VangDeVolger.Objects
{
    class Rock : StaticObject
    {
        bool passable { get; set; }

        public Rock()
        {
            passable = false;
            image = Image.FromFile(@"..\..\..\vangdevolger\Resources\pillar.png");
        }
    }
}
