using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using race;
using System.Net;

namespace raceTest
{
    [TestClass]
    public class RaceTest
    {
        TrackingServer trackerMan;
        IPEndPoint tsEndPoint = new IPEndPoint(IPAddress.Any, 0);
        Communicator CommsBoi;

        private void SendMessage(string message)
        {
            CommsBoi.Send(message, new IPEndPoint(IPAddress.Any, 0));
        }

        private String GetMessage()
        {
            while (true)
            {
                if (CommsBoi.IsMessageAvailable())
                {
                    return CommsBoi.GetMessage(out tsEndPoint);
                }
            }
        }

        [TestMethod]
        public void TestRaceStarted()
        {
            CommsBoi = new Communicator();
            trackerMan = new TrackingServer(tsEndPoint);
            trackerMan.MainLoop();

            SendMessage("Race,MemeRun 2018,1337");
            SendMessage("Hello");

            Assert.AreEqual(GetMessage(), "Race,MemeRun 2018,1337");
        }

        [TestMethod]
        public void TestAthlete()
        {
            SendMessage("Registered,0,0,Water,Guy,m,12");
            Assert.AreEqual(GetMessage(), "Athlete,0,0,Water,Guy,m,12");
        }

        [TestMethod]
        public void TestDidNotStart()
        {
            SendMessage("Registered,1,0,Haha,Yes,m,22");
            GetMessage();
            SendMessage("Subscribe,1");
            SendMessage("DidNotStart,1");
            Assert.AreEqual(GetMessage(), "Status,1,1,0,1,1");
        }

        [TestMethod]
        public void TestStarted()
        {
            SendMessage("Registered,2,0,Pepe,Frog,m,18");
            GetMessage();
            SendMessage("Subscribe,2");
            SendMessage("Started,0,2");
            Assert.AreEqual(GetMessage(), "Status,0,2,0,2,0");
        }

        [TestMethod]
        public void TestDidNotFinish()
        {
            SendMessage("Started,2,2");
            GetMessage();
            SendMessage("DidNotFinish,2,3");
            Assert.AreEqual(GetMessage(), "Status,2,3,2,32,3,0");
        }

        [TestMethod]
        public void TestOnCourse()
        {
            SendMessage("OnCourse,0,4,5,256");
            Assert.AreEqual(GetMessage(), "Status,0,4,2,256,5,0");
        }

        [TestMethod]
        public void TestFinished()
        {
            SendMessage("Finished,0,6");
            Assert.AreEqual(GetMessage(), "Status,0,5,2,1337,6,6");
        }
    }
}
