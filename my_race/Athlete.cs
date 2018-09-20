using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race
{
    public struct Status
    {
        double Time;
        double Distance;
        int CurrStatus;
    }

    public class Athlete
    {
        public int BibNumber;
        public string FirstName;
        public string LastName;
        public char Gender;
        public int Age;
        public Status Status;
    }
}
