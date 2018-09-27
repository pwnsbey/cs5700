using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace race
{
    class StartTs
    {
        static void Main(string[] args)
        {
            TrackingServer ts = new TrackingServer(new IPEndPoint(IPAddress.Any, 0));
            ts.MainLoop();
        }
    }
}
