using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model;

namespace YunShanOA.IDAL.MeetingInterface
{
    public interface IMeetingType
    {
        int SaveMeetingType(MeetingType mt);

        bool DeleteMeetingType(MeetingType mt);

        List<MeetingType> GetMeetingType();

        MeetingType GetMeetingTypeByMtID(int mtID);
    }
}
