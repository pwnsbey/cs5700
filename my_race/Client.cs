using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace race
{
    public class Client
    {
        public List<int> SubbedAthletes;
        public IPEndPoint EndPoint;

        public Client(IPEndPoint endPoint)
        {
            EndPoint = endPoint;
            SubbedAthletes = new List<int>();
        }
    }
}
