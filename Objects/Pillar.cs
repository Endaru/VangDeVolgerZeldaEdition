using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VangDeVolger.Objects
{
    class Pillar : StaticObject
    {
        public bool passable { get; set; }

        public Pillar(bool passable)
        {
            if (!passable)
            {
                image = Image.FromFile(@"..\..\..\vangdevolger\Resources\pillar.png");
            }
            else
            {
                image = Image.FromFile(@"..\..\..\vangdevolger\Resources\Pillar_hammerd.png");
            }
        }
    }
}
