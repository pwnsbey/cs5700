using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace race
{
    public class TrackingServer
    {
        private static IPEndPoint serverEndPoint;
        private static int Port = 12000;
        private static Communicator CommsBoi;
        private List<Athlete> Athletes;

        static void Main(string[] args)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
            CommsBoi = new Communicator(Port);

            while (true)
            {
                if (Console.KeyAvailable)
                    break;

                if (CommsBoi.IsMessageAvailable())
                {
                    Console.WriteLine(CommsBoi.GetMessage(out serverEndPoint));
                }
            }
        }
    }
}
