using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using YunShanOA.DataAccess.Mapping;
using YunShanOA.IDAL.MeetingInterface;

namespace YunShanOA.Test
{
    [TestFixture]
    public class MeetingEquipment
    {
        YunShanOADataContext dc = null;
        IMeetingEquipment ime = null;
        [TestFixtureSetUp]
        public void Init()
        {
            ime = DALFactory.MeetingInstanceFactory.GetMeetingEquipmentInstance();
            dc = new YunShanOADataContext();
        }



    }
}
