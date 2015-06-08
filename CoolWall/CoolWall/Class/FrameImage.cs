using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolWall.Class
{
    class FrameImage
    {
        //  Image in Base64String format
        public string Base64String { get; set; }
        //  Image Original Orientation
        public int OriginalOrientation { get; set; }
        //  Image Placement Orientation
        public int PlacementOrientation { get; set; }
    }
}
