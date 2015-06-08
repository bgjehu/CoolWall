using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolWall.Class
{
    class AppConfig
    {
        public int OpenCount { get; set; }
        public bool AutoStart { get; set; }
        public AppConfig(int openCount, bool autoStart)
        {
            OpenCount = openCount;
            AutoStart = autoStart;
        }
    }
}
