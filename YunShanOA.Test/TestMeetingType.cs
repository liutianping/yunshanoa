using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using YunShanOA.DataAccess.Mapping;
using YunShanOA.IDAL.MeetingInterface;
using YunShanOA.DataAccess.Meeting;

namespace YunShanOA.Test
{
    [TestFixture]
    public class TestMeetingType
    {
        YunShanOADataContext dc = null;
        MeetingTypeHelp mtHelp = null;
        [TestFixtureSetUp]
        public void Init()
        {
            dc = new YunShanOADataContext();
            mtHelp = new MeetingTypeHelp();
        }

        [Test]
        public void TestMeetingTypeSaveForInsert()
        {
            YunShanOA.Model.MeetingType mt = new Model.MeetingType();
            mt.MeetingTypeName = "datetime";
            int result = mtHelp.SaveMeetingType(mt);
            Assert.AreEqual(result, GetLastTypeID());
        }

        [Test]
        public void TestMeetingTypeSaveForUpdate()
        {
            YunShanOA.Model.MeetingType mt = new Model.MeetingType();
            mt.MeetingTypeName = "datetime";
            mt.MeetingTypeID = GetLastTypeID();
            mt.MeetingTypeDescription = "yes";
            int result = mtHelp.SaveMeetingType(mt);
            Assert.AreEqual(result, GetLastTypeID());
        }

        private int GetLastTypeID()
        {
            int result = 0;

            result = int.Parse((from type in dc.MeetingType orderby type.MeetingTypeID descending select type.MeetingTypeID).First().ToString());
            return result;
        }

        [Test]
        public void TestMeetingDelete()
        {
            YunShanOA.Model.MeetingType mt = new Model.MeetingType();
            mt.MeetingTypeID = GetLastTypeID();
            int org = mt.MeetingTypeID;
            Assert.AreEqual(true,mtHelp.DeleteMeetingType(mt));
            Assert.AreNotEqual(org, GetLastTypeID());
        }

        [Test]
        public void TestMeetingTypeByID()
        {
            YunShanOA.Model.MeetingType mt = new Model.MeetingType();
            mt.MeetingTypeName = "abc";
            mt.MeetingTypeDescription = "abc";
            mtHelp.SaveMeetingType(mt);
            mt.MeetingTypeID = GetLastTypeID();
            YunShanOA.Model.MeetingType mt1 = mtHelp.GetMeetingTypeByMtID(GetLastTypeID());
            Compare(mt, mt1);
            mtHelp.DeleteMeetingType(mt);
        }

        private void Compare(Model.MeetingType mt1,Model.MeetingType mt2)
        {
            Assert.AreEqual(mt1.MeetingTypeID, mt2.MeetingTypeID);
            Assert.AreEqual(mt1.MeetingTypeName, mt2.MeetingTypeName);
            Assert.AreEqual(mt1.MeetingTypeDescription, mt2.MeetingTypeDescription);
        }
    }
}
