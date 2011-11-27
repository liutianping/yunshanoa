using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.DataAccess.Mapping;
using NUnit.Framework;
using YunShanOA.DALFactory;
using YunShanOA.IDAL.MeetingInterface;

namespace YunShanOA.Test
{
    [TestFixture]
    public class MeetingRoomTest
    {
        YunShanOADataContext dc = null;
        [TestFixtureSetUp]
        public void Init()
        {
            dc = new YunShanOADataContext();
        }
        [Test]
        public void TestMeetingRoomForInsert()
        {
            YunShanOA.Model.MeetingRoom meetingRoom = new Model.MeetingRoom();
            meetingRoom.MeetingTypeID = 1;
            meetingRoom.MeetingRoomStatus = 1;
            meetingRoom.MeetingRoomName = "隆汇大厦1201室";
            meetingRoom.MeetingRoomCapacity = 50;
            IMeetingRoom imr=YunShanOA.DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance();
            Assert.IsNotNull(imr);
            int LastMeetingRoomID= imr.SaveMeetingRoom(meetingRoom);
            Assert.AreEqual(LastMeetingRoomID,GetLastMeetingRoomID());
            DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().DeleteMeetingRoom(meetingRoom);
        }


        [Test]
        public void TestMeetingRoomForUpdate()
        {
            YunShanOA.Model.MeetingRoom meetingRoom = new Model.MeetingRoom();
            meetingRoom.MeetingTypeID = 1;
            meetingRoom.MeetingRoomStatus = 1;
            meetingRoom.MeetingRoomName = "隆汇大厦1201室";
            meetingRoom.MeetingRoomCapacity = 30;
            meetingRoom.MeetingRoomID = GetLastMeetingRoomID();
            int LastMeetingRoomID = YunShanOA.DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().SaveMeetingRoom(meetingRoom);
            Assert.AreEqual(LastMeetingRoomID, GetLastMeetingRoomID());
            DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().DeleteMeetingRoom(meetingRoom);
        }

        [Test]
        public void TestMeetingRoomDelete()
        {
            YunShanOA.Model.MeetingRoom meetingRoom = new Model.MeetingRoom();

            IMeetingRoom imr = DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance();
            YunShanOA.Model.MeetingRoom meetingroom = new Model.MeetingRoom();
            meetingroom.MeetingRoomName = "汇景大厦4层401";
            meetingroom.MeetingRoomStatus = 1;
            meetingroom.MeetingTypeID = 1;
            meetingroom.MeetingRoomCapacity = 50;
            imr.SaveMeetingRoom(meetingroom);
            meetingRoom.MeetingRoomID = GetLastMeetingRoomID();
            bool result = YunShanOA.DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().DeleteMeetingRoom(meetingRoom);
            Assert.AreEqual(true,result);
        }

        [Test]
        public void TestGetListMeetingRoom()
        {
            IMeetingRoom imr=DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance();
            List<Model.MeetingRoom> list1 = imr.GetListMeetingRoom();

            YunShanOA.Model.MeetingRoom meetingroom = new Model.MeetingRoom();
            meetingroom.MeetingRoomName ="汇景大厦4层401";
            meetingroom.MeetingRoomStatus = 1;
            meetingroom.MeetingTypeID = 1;
            meetingroom.MeetingRoomCapacity = 50;
            imr.SaveMeetingRoom(meetingroom);
            meetingroom.MeetingRoomID = GetLastMeetingRoomID();
            list1.Add(meetingroom);

            List<Model.MeetingRoom> list2 = imr.GetListMeetingRoom();

            for (int i = 0; i < list1.Count; i++)
            {
                Compare(list1[i],list2[i]);
            }

            imr.DeleteMeetingRoom(meetingroom);
        }

        [Test]
        public void TestQueryMeetingRoomByName()
        {
            IMeetingRoom imr = DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance();
            YunShanOA.Model.MeetingRoom meetingroom = new Model.MeetingRoom();
            meetingroom.MeetingRoomName = "汇景大厦4层401";
            meetingroom.MeetingRoomStatus = 1;
            meetingroom.MeetingTypeID = 1;
            meetingroom.MeetingRoomCapacity = 50;
            imr.SaveMeetingRoom(meetingroom);
            meetingroom.MeetingRoomID = GetLastMeetingRoomID();

            Model.MeetingRoom meetingroom2 = imr.QueryMeetingRoomByName(meetingroom.MeetingRoomName);
            Compare(meetingroom,meetingroom2);
            imr.DeleteMeetingRoom(meetingroom);
        }

        private void Compare(Model.MeetingRoom mr1,Model.MeetingRoom mr2)
        {
            Assert.AreEqual(mr1.MeetingRoomID,mr2.MeetingRoomID);
            Assert.AreEqual(mr1.MeetingRoomCapacity,mr2.MeetingRoomCapacity);
            Assert.AreEqual(mr1.MeetingRoomName,mr2.MeetingRoomName);
            Assert.AreEqual(mr1.MeetingRoomStatus,mr2.MeetingRoomStatus);
            Assert.AreEqual(mr1.MeetingTypeID,mr2.MeetingTypeID);
        }

        private int GetLastMeetingRoomID()
        {
            int result = int.Parse((from meeting in dc.MeetingRoom orderby meeting.MeetingRoomID descending select meeting.MeetingRoomID).First().ToString());
            return result;
        }
    }
}
