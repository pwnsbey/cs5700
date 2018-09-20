using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race
{
    public struct Status
    {
        public double Time;
        public double Distance;
        public int CurrStatus;
    }

    public class Athlete
    {
        public int BibNumber;
        public string FirstName;
        public string LastName;
        public char Gender;
        public int Age;
        public Status Status;

        public Athlete(int bibNumber, string firstName, string lastName, char gender, int age,
                       double time, double distance, int currStatus)
        {
            BibNumber = bibNumber;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
            Status = new Status() { Time = time, Distance = distance, CurrStatus = currStatus };
        }
    }
}
