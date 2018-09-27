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
        private List<Client> Clients;
        private string RaceName;
        private string RaceLength;

        private Dictionary<int, string> STATUS_LOOKUP = new Dictionary<int, string>();
        
        public TrackingServer(IPEndPoint tsEndPoint)
        {
            serverEndPoint = tsEndPoint;
        }

        private void HandleRaceMessage(string raceName, string raceLength)
        {
            RaceName = raceName;
            RaceLength = raceLength;
        }

        private void HandleRegisteredMessage(int bibNumber, double time, string firstName, 
                                             string lastName, char gender, int age)
        {
            Athlete athlete = new Athlete(bibNumber, firstName, lastName, gender, age, time, 0, 0);
            Athletes.Add(athlete);
            foreach (Client c in Clients)
                SendAthleteMessage(athlete, c.EndPoint);
        }

        private void HandleDidNotStartMessage(int bibNumber, double time)
        {
            Athlete a = Athletes.Find(athlete => athlete.BibNumber == bibNumber);
            a.Status.CurrStatus = 1;
            a.Status.LastUpdateTime = time;
            SendStatus(a);
        }

        private void HandleStartedMessage(int bibNumber, double time)
        {
            Athlete a = Athletes.Find(athlete => athlete.BibNumber == bibNumber);
            a.Status.CurrStatus = 2;
            a.Status.StartTime = time;
            a.Status.LastUpdateTime = time;
            SendStatus(a);
        }

        private void HandleOnCourseMessage(int bibNumber, double time, double distance)
        {
            Athlete a = Athletes.Find(athlete => athlete.BibNumber == bibNumber);
            a.Status.CurrStatus = 3;
            a.Status.LastUpdateTime = time;
            a.Status.Distance = distance;
            SendStatus(a);
        }

        private void HandleDidNotFinishMessage(int bibNumber, double time)
        {
            Athlete a = Athletes.Find(athlete => athlete.BibNumber == bibNumber);
            a.Status.CurrStatus = 4;
            a.Status.LastUpdateTime = time;
            SendStatus(a);
        }

        private void HandleFinishedMessage(int bibNumber, double time)
        {
            Athlete a = Athletes.Find(athlete => athlete.BibNumber == bibNumber);
            a.Status.CurrStatus = 5;
            a.Status.LastUpdateTime = time;
            SendStatus(a);
        }

        private void HandleHelloMessage(IPEndPoint clientEndPoint)
        {
            Clients.Add(new Client(clientEndPoint));
            SendRaceMessage(clientEndPoint);
            foreach (Athlete a in Athletes)
                SendAthleteMessage(a, clientEndPoint);
        }

        private void HandleSubscribeMessage(int bibNumber, IPEndPoint clientEndPoint)
        {
            Client c = Clients.Find(client => client.EndPoint.Equals(clientEndPoint));
            c.SubbedAthletes.Add(bibNumber);
        }

        private void HandleUnsubscribeMessage(int bibNumber, IPEndPoint clientEndPoint)
        {
            Clients.Find(client => client.EndPoint.Equals(clientEndPoint)).SubbedAthletes.Remove(bibNumber);
        }

        private void SendRaceMessage(IPEndPoint clientEndPoint)
        {
            CommsBoi.Send("Race," + RaceName + "," + RaceLength, clientEndPoint);
        }

        private void SendAthleteMessage(Athlete newAthlete, IPEndPoint clientEndPoint)
        {
            CommsBoi.Send("Athlete," + newAthlete.BibNumber + "," + newAthlete.FirstName + "," + 
                          newAthlete.LastName + "," + newAthlete.Gender + "," + newAthlete.Age, clientEndPoint);
        }

        private void SendStatus(Athlete a)
        {
            List<IPEndPoint> targetClients = new List<IPEndPoint>();
            foreach (Client c in Clients)
            {
                if (c.SubbedAthletes != null)
                {
                    foreach (int b in c.SubbedAthletes)
                    {
                        if (b == a.BibNumber)
                            targetClients.Add(c.EndPoint);
                    }
                }
            }

            foreach (IPEndPoint c in targetClients)
                CommsBoi.Send("Status," + a.BibNumber + "," + STATUS_LOOKUP[a.Status.CurrStatus] + "," + a.Status.StartTime + 
                              "," + a.Status.Distance + "," + a.Status.LastUpdateTime + "," + a.Status.LastUpdateTime, c);
        }

        private void HandleMessage(string message, IPEndPoint endPoint)
        {
            Console.WriteLine("<<< " + message + " :: " + endPoint.ToString());

            if (message == "Hello")
            {
                HandleHelloMessage(endPoint);
            }
            string[] msgComps = message.Split(',');  // messageComponents
            switch (msgComps[0])
            {
                case "Race":
                    HandleRaceMessage(msgComps[1], msgComps[2]);
                    break;
                case "Registered":
                    HandleRegisteredMessage(int.Parse(msgComps[1]), double.Parse(msgComps[2]), 
                                            msgComps[3], msgComps[4], char.Parse(msgComps[5]), 
                                            int.Parse(msgComps[6]));
                    break;
                case "DidNotStart":
                    HandleDidNotStartMessage(int.Parse(msgComps[1]), double.Parse(msgComps[2]));
                    break;
                case "Started":
                    HandleStartedMessage(int.Parse(msgComps[1]), double.Parse(msgComps[2]));
                    break;
                case "OnCourse":
                    HandleOnCourseMessage(int.Parse(msgComps[1]), double.Parse(msgComps[2]),
                                          double.Parse(msgComps[3]));
                    break;
                case "DidNotFinish":
                    HandleDidNotFinishMessage(int.Parse(msgComps[1]), double.Parse(msgComps[2]));
                    break;
                case "Finished":
                    HandleFinishedMessage(int.Parse(msgComps[1]), double.Parse(msgComps[2]));
                    break;
                case "Subscribe":
                    HandleSubscribeMessage(int.Parse(msgComps[1]), endPoint);
                    break;
                case "Unsubscribe":
                    HandleUnsubscribeMessage(int.Parse(msgComps[1]), endPoint);
                    break;
                default:
                    break;
            }
        }

        public void MainLoop()
        {
            STATUS_LOOKUP.Add(0, "Registered");
            STATUS_LOOKUP.Add(1, "DidNotStart");
            STATUS_LOOKUP.Add(2, "Started");
            STATUS_LOOKUP.Add(3, "OnCourse");
            STATUS_LOOKUP.Add(4, "DidNotFinish");
            STATUS_LOOKUP.Add(5, "Finished");
            
            Athletes = new List<Athlete>();
            Clients = new List<Client>();
            CommsBoi = new Communicator(Port);
            

            while (true)
            {
                if (Console.KeyAvailable)
                    break;

                if (CommsBoi.IsMessageAvailable())
                {
                    HandleMessage(CommsBoi.GetMessage(out serverEndPoint), serverEndPoint);
                }
            }
        }
    }
}
