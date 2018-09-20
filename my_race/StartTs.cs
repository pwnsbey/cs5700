using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race
{
    class StartTs
    {
        static void Main(string[] args)
        {
            TrackingServer ts = new TrackingServer();
            ts.MainLoop();
        }
    }
}
