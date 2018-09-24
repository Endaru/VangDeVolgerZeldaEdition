using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VangDeVolger.Objects
{
    abstract class GameObject
    {
        public Image image { get; set; }
        public Space myPosition { get; set; }
    }
}
