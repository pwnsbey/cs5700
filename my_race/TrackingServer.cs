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
            SendAthleteMessage(athlete);
        }

        private void HandleDidNotStartMessage(int bibNumber, double time)
        {
            Athletes.Find(athlete => athlete.BibNumber == bibNumber).Status.CurrStatus = 1;
            SendStatus(bibNumber);
        }

        private void HandleStartedMessage(int bibNumber, double time)
        {
            Athletes.Find(athlete => athlete.BibNumber == bibNumber).Status.CurrStatus = 2;
            SendStatus(bibNumber);
        }

        private void HandleOnCourseMessage(int bibNumber, double time, double distance)
        {
            Athletes.Find(athlete => athlete.BibNumber == bibNumber).Status.CurrStatus = 3;
            SendStatus(bibNumber);
        }

        private void HandleDidNotFinishMessage(int bibNumber, double time)
        {
            Athletes.Find(athlete => athlete.BibNumber == bibNumber).Status.CurrStatus = 4;
            SendStatus(bibNumber);
        }

        private void HandleFinishedMessage(int bibNumber, double time)
        {
            Athletes.Find(athlete => athlete.BibNumber == bibNumber).Status.CurrStatus = 5;
            SendStatus(bibNumber);
        }

        private void HandleHelloMessage(IPEndPoint clientEndPoint)
        {
            // add client to list
            // sent all previously registered athletes to client (foreach -> SendAthleteMessage)
        }

        private void HandleSubscribeMessage(int bibNumber, IPEndPoint clientEndPoint)
        {
            return;
        }

        private void HandleUnsubscribeMessage(int bibNumber, IPEndPoint clientEndPoint)
        {
            return;
        }

        private void SendRaceMessage()
        {
            return;
        }

        private void SendAthleteMessage(Athlete newAthlete)
        {
            return;
        }

        private void SendStatus(int athleteBib)
        {
            // search client list and send messages updating each of them (find, foreach)
            return;
        }

        private void HandleMessage(string message, IPEndPoint endPoint)
        {
            Console.WriteLine(message);

            if (message == "Hello")
            {
                return;
            }
            string[] msgComps = message.Split(',');  //messageComponents
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
            serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
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
