using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CoolWall.Class
{
    class FrameConfig
    {
        //  Frame Outlook
        public FrameImage Image { get; set; }
        public FrameBorder Border { get; set; }
        //  Frame Info
        //  Frame Size = Image Size * SizeRate
        public double SizeRate { get; set; }
        public Point Location { get; set; }
        public double Opacity { get; set; }
        public bool Visible { get; set; }
        public bool TopMost { get; set; }
        public bool Locked { get; set; }
    }
}
