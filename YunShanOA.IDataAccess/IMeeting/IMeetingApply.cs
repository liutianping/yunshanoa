using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model;

namespace YunShanOA.IDAL.MeetingInterface
{
    public interface IMeetingApply
    {

        List<YunShanOA.Model.Meeting> ListMeetingByStatus(int status);
        int SaveMeetingApply(Meeting meetingAndApply);

        bool DeleteMeetingApply(Meeting meetingAndApply);

        List<Meeting> GetListMeetingApply();

        List<Meeting> GetListMeetingApplyByStatus(int status);
    }
}
