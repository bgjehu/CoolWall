using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoolWall.Class
{
    class FrameBorder
    {
        //  Border Color
        public Color Color { get; set; }
        //  Border Width
        public int Width { get; set; }
        //  Border Radius
        public int Radius { get; set; }
        //  Border Theme
        public FrameBorderTheme Theme { get; set; }
    }
}
